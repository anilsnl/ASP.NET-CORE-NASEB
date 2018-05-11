using NASEB.Entities.ComplexType;
using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static TRIDVerification.KPSPublicSoapClient;

namespace NASEB.Library.Services.Concrete
{
    public class MemberManager : IMemberService
    {
        IUnitOfWork unitOfWork;
        public MemberManager(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<ServiceResult> AddAsync(Member entity)
        {
            var model = new ServiceResult();
            try
            {
                entity.Name = entity.Name.ToUpper();
                entity.Surname = entity.Surname.ToUpper();
                entity.Address = entity.Address.ToUpper();
                entity.EMail = entity.EMail.ToLower();

                if (entity.isTRCitezen)
                {
                    var tridCliend = new TRIDVerification.KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap12);
                    var verificetionResult = await tridCliend.TCKimlikNoDogrulaAsync(entity.TRIDNo, entity.Name, entity.Surname, entity.BirthDate.Year);
                    if (verificetionResult.Body.TCKimlikNoDogrulaResult)
                    {
                        unitOfWork.Members.Add(entity);
                        await unitOfWork.SaveChangesAsync();
                        model.isSuccess = true;
                        model.Errors.Add("Üye başarıyla eklendi!");
                    }
                    else
                        throw new Exception("Girilen kişi için vatandaşlık doğrulanamadığı için kayıt başarısız oldu!");
                }
                else
                {
                    unitOfWork.Members.Add(entity);
                    await unitOfWork.SaveChangesAsync();
                    model.isSuccess = true;
                    model.Errors.Add("Üye başarıyla eklendi!");
                }
            }
            catch (Exception ex)
            {
                model.isSuccess = false;
                model.Errors.Add(ex.Message);
            }
            return model;
        }

        public Task<ServiceResult> AddMemberWithVerifingTRIDAsync(Member member)
        {
            throw new NotImplementedException();
        }

        public async Task<IAuthorService> ChangeUserStatusAsync(int memberID, int status)
        {
            throw new NullReferenceException();
        }

        public async Task<ServiceResult> DeleteAsync(Member entity)
        {
            var result = new ServiceResult(false);
            try
            {
                var member = await unitOfWork.Members.GetAsync(a => a.MemberID == entity.MemberID);
                if (member==null)
                {
                    throw new NullReferenceException("Üye bulunamadı!");
                }
                unitOfWork.Members.Delete(member);
                if (await unitOfWork.Rents.AnyExistAsync(a => a.MemberID == entity.MemberID))
                    throw new Exception("Üye adına kira kaydı bulunduğu için bu üye silinemez!");
                
                result.isSuccess = await unitOfWork.SaveChangesAsync() > 0;
                
                if (result.isSuccess)
                {
                    result.Errors.Add(member.Name + " " + member.Surname + " kaydı silindi!");
                }

            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }
            return result;
        }

        public Member Get(Expression<Func<Member, bool>> expression)
        {
            return unitOfWork.Members.Get(expression);
        }

        public IQueryable<Member> GetAll()
        {
            return unitOfWork.Members.GetAll();
        }

        public async Task<Member> GetAsync(Expression<Func<Member, bool>> expression)
        {
            return await unitOfWork.Members.GetAsync(expression);
        }

        public IQueryable<Member> GetList(Expression<Func<Member, bool>> expression)
        {
            return unitOfWork.Members.GetList(expression);
        }

        public double GetTotalDeptByMemberID(int memberID)
        {
            throw new NullReferenceException();
        }

        public IQueryable<RentHistory> GetUserRentsByMemberID(int memberID)
        {
            return unitOfWork.Rents.GetList(a => a.MemberID == memberID);
        }

        public async Task<ServiceResult> UpdateAsync(Member entity)
        {
            var result = new ServiceResult(false);
            try
            {
                var member = await unitOfWork.Members.GetAsync(a => a.MemberID == entity.MemberID);
                if (member == null)
                    throw new NullReferenceException("Üye bulunamadı!");
                member.isAddressVerified = entity.isAddressVerified;
                member.isEMailVerified = entity.isEMailVerified;
                member.Status = entity.Status;
                member.PhoneNumber = entity.PhoneNumber;
                member.Address = entity.Address;
                
                member.RemainedRentConut = entity.TotalRentConut - unitOfWork.Rents.GetList(a => a.MemberID == member.MemberID && a.isRentingCompleted == false).Count();
                if (member.RemainedRentConut < 0)
                    throw new Exception("Üyenin aktif kira sayısı yeni limitten az olamaz. Limiti düşürmeden önce üye kiralamalarını tamamlamalı!");
                unitOfWork.Members.Update(member);
                await unitOfWork.SaveChangesAsync();
                result.isSuccess = true;
                result.Errors.Add("Üye başarıyla güncellendi!");
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.Errors.Add(ex.Message);
            }
            return result;

        }

        public IQueryable<BaseSelectModel> SearchForMembers(string searchingWord)
        {
            return  unitOfWork.Members.GetList(member=> member.Name.Contains(searchingWord) || member.Surname.Contains(searchingWord) ||
                    member.TRIDNo.ToString().Contains(searchingWord) || member.PhoneNumber.Contains(searchingWord) ||
                    member.EMail.Contains(searchingWord)).Select(member=>  new BaseSelectModel()                 
                    {
                        Key = member.MemberID.ToString(),
                        Value = member.Name + " " + member.Surname + " - " + member.TRIDNo.ToString()
                    });
        }

        public async Task<LoginResult> CheckForLoginAsync(string name, string surname, int birthYear, long TRIDNo, bool isTRCitizen)
        {
            var loginResult = new LoginResult();
            try
            {
                var member = await unitOfWork.Members.GetAsync(a => a.BirthDate.Year == birthYear && a.isTRCitezen == isTRCitizen);
                if (member==null)
                {
                    loginResult.Result = LoginResults.InvalidUser;
                }
                else
                {
                    loginResult.isSuccess = true;
                    loginResult.Result = LoginResults.isSuccess;
                }
            }
            catch (Exception ex)
            {
                loginResult.Result = LoginResults.InvalidUser;

            }
            return loginResult;
        }

        public async Task<int> CountAsync(Expression<Func<Member, bool>> expression = null)
        {
            return await unitOfWork.Members.GetCountAsync(expression);
        }

        public int Count(Expression<Func<Member, bool>> expression = null)
        {
            return  unitOfWork.Members.GetCount(expression);
        }
    }
}
