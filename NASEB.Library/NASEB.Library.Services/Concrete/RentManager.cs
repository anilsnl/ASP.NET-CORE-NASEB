using NASEB.Entities.ComplexType;
using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NASEB.Library.Services.Concrete
{
    public class RentManager : IRentService
    {
        private IUnitOfWork unitOfWork;
        public RentManager(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<ServiceResult> AddAsync(RentHistory entity)
        {
            var result = new ServiceResult();
            try
            {
                if (!await unitOfWork.Users.AnyExistAsync(a => a.UserID == entity.UserID))
                    throw new Exception("Yetkili bilgilerine ulaşılamiyor!");

                var member = await unitOfWork.Members.GetAsync(a => a.MemberID == entity.MemberID);
                if (member == null)
                    result.Errors.Add("Üye bulunamadı!");
                else if (member.AwaableToRent == false || member.RemainedRentConut < 1)
                    result.Errors.Add("Üye kiralama için uygun değil!");

                var book = await unitOfWork.Books.GetAsync(a => a.BookID == entity.BookID);
                if (book == null)
                    result.Errors.Add("Kitap bulanamadı");
                else if (book.AvailableQuantity < 1)
                    result.Errors.Add("Seçilen kitap kıralama inin uygun değil!");

                if (result.Errors.Count()==0)
                {
                    member.RemainedRentConut -= 1; 
                    book.AvailableQuantity -= 1;
                    unitOfWork.Rents.Add(entity);
                    unitOfWork.Books.Update(book);
                    unitOfWork.Members.Update(member);
                    if (await unitOfWork.SaveChangesAsync()>0)
                    {
                        result.isSuccess = true;
                        result.Errors.Add("Kira kaydı başarıyla tamamlandı!");
                    }
                }
                
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.Errors.Add(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult> ComplateRentByIDAsync(int rentid)
        {
            var model = new ServiceResult(true);
            try
            {
                var rent = await unitOfWork.Rents.GetAsync(a => a.RentID == rentid);
                if (rent == null)
                    throw new NullReferenceException("Kira bilgisine ulaşılamiyor");
                if (rent.isRentingCompleted)
                    throw new Exception("Bu kira zaten tamamlanmış");
                rent.isRentingCompleted = true;
                rent.DeliveredDate = DateTime.Now;
                rent.LastUpdatedDate = DateTime.Now;
                double delayFine= Convert.ToInt32((DateTime.Now - rent.RentEndDate).TotalDays) * 5.5;
                rent.DelayFine = delayFine > 0 ? delayFine : 0.0;
                unitOfWork.Rents.Update(rent);
                var member = await unitOfWork.Members.GetAsync(a => a.MemberID == rent.MemberID);
                var book = await unitOfWork.Books.GetAsync(a => a.BookID == rent.BookID);
                member.RemainedRentConut += 1;
                book.AvailableQuantity += 1;
                unitOfWork.Books.Update(book);
                unitOfWork.Members.Update(member);

                model.isSuccess = await unitOfWork.SaveChangesAsync() > 0;
                if (!model.isSuccess)
                    throw new Exception("Kira tamamlama işlemi başarısız oldu");
                model.Errors.Add("Kiralama tamamlandı! Gecikme cezası: " + rent.DelayFine.ToString());
            }
            catch (Exception ex)
            {
                model.Errors.Add(ex.Message);
            }
            return model;
        }

        public async Task<ServiceResult> DeleteAsync(RentHistory entity)
        {
            var result = new ServiceResult(false);
            try
            {
                var rent = await unitOfWork.Rents.GetAsync(a => a.RentID == entity.RentID);
                if (rent == null)
                    throw new NullReferenceException("Kira bilgisine ulaşılamityor!");
                var datedif = DateTime.Now - rent.CreatedDate;
                if (datedif.TotalHours > 24)
                    throw new Exception("Kira kayıdı eklendiği zamandan sadece 24 saat sonraya kadar silinebilir");
                unitOfWork.Rents.Delete(rent);
                result.isSuccess = await unitOfWork.SaveChangesAsync() > 0;
                if (result.isSuccess)
                    result.Errors.Add("Kira kaydı başarıyla silindi");
                else
                    result.Errors.Add("Kira kaydı silinemedi");

            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }
            return result;
        }

        public RentHistory Get(Expression<Func<RentHistory, bool>> expression)
        {
            return unitOfWork.Rents.Get(expression);
        }

        public IQueryable<RentHistory> GetAll()
        {
            return unitOfWork.Rents.GetAll();
        }

        public async Task<RentHistory> GetAsync(Expression<Func<RentHistory, bool>> expression)
        {
            return await unitOfWork.Rents.GetAsync(expression);
        }

        public IQueryable<RentHistory> GetList(Expression<Func<RentHistory, bool>> expression)
        {
            return unitOfWork.Rents.GetList(expression);
        }

        public async Task<ServiceResult> GetRentableByUserIDAsync(int userid)
        {
            throw new NullReferenceException();
        }

        public IQueryable<RentOverviewView> GetRentOverview(Expression<Func<RentOverviewView, bool>> expression)
        {
            return unitOfWork.Rents.GetRentOverviewView(expression);
        }

        public IQueryable<RentStatuus> GetRentStatus()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> UpdateAsync(RentHistory entity)
        {
            var result = new ServiceResult();
            try
            {
                unitOfWork.Rents.Update(entity);
                await unitOfWork.SaveChangesAsync();
                result.Errors.Add("Kira güncellendi");
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }
            return result;
        }


        public async Task<ServiceResult> ExpandRentingEndDate(int rendID, int day = 0)
        {
            var result = new ServiceResult();
            try
            {
                if (day < 1)
                    throw new Exception("Girdiğiniz uzatma süresi 1'den büyük olmalıdır.");
                var rent = await unitOfWork.Rents.GetAsync(a => a.RentID == rendID);
                if (rent == null)
                    throw new NullReferenceException("Kira bulunamadı");
                if (rent.isRentingCompleted)
                    throw new Exception("Bu kira zaten tamamlanmış");
                rent.RentEndDate = rent.RentEndDate.AddDays(day);
                rent.LastUpdatedDate = DateTime.Now;
                unitOfWork.Rents.Update(rent);
                result.isSuccess = await unitOfWork.SaveChangesAsync() > 0;
                if (result.isSuccess)
                {
                    result.Errors.Add("Kira teslim tarihi " + rent.RentEndDate.ToString("dd/MM/yyyy") + " olarak güncellendi!");
                }
                else
                {
                    throw new Exception("Kira güncelle işlemi başarısız");
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }
            return result;
        }

        public async Task<int> CountAsync(Expression<Func<RentHistory, bool>> expression = null)
        {
            return await unitOfWork.Rents.GetCountAsync(expression);
        }

        public int Count(Expression<Func<RentHistory, bool>> expression = null)
        {
            return unitOfWork.Rents.GetCount(expression);
        }

        public IQueryable<RentHistoryView> GetRentHistories(Expression<Func<RentHistoryView, bool>> expression=null)
        {
            return unitOfWork.Rents.GetRentHistoryView(expression);
        }
    }
}
