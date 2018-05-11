using NASEB.Entities.ComplexType;
using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.Helper.Security;
using NASEB.Library.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NASEB.Library.Services.Concrete
{
    public class UserManager:IUserService
    {
        private readonly IUnitOfWork UnitOfWork;

        public UserManager(IUnitOfWork work)
        {
            UnitOfWork = work;
        }

        public Task<ServiceResult> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ChangePasswordAsync(User user, string currentPassword, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> ChangePasswordAsync(string email, string currentPassword, string password)
        {
            var result=new ServiceResult();
            result.Errors=new List<string>();
            try
            {
                var user = UnitOfWork.Users.Get(a => a.EMail.Equals(email)&&a.PasswordHash.Equals(Hasher.HashPassword(currentPassword)));
                if(user==null)
                    throw new NullReferenceException("Kullanıcı bulunamadı!");
                user.PasswordHash=NASEB.Library.Helper.Security.Hasher.HashPassword(password);
                UnitOfWork.Users.Update(user);
                await UnitOfWork.SaveChangesAsync();
                result.isSuccess = true;
            }
            catch (Exception e)
            {
                result.Errors.Add(e.Message);
            }

            return result;
        }

        public Task<ServiceResult> ChangePasswordAsync(User user, string password)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Role> GetRolesByUserID(int userid)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResult> CheckForLoginAsync(User user, string password)
        {
            var hshedPassword = Hasher.HashPassword(password);
            var eMail = user.EMail;
            var cUser = UnitOfWork.Users.Get(a => a.EMail.Equals(eMail) && a.PasswordHash.Equals(hshedPassword));
            if (cUser == null)
            {
                return new LoginResult()
                {
                    isSuccess = false,
                    Result = LoginResults.InvalidUser
                };
            }
           
            return new LoginResult()
            {
                isSuccess = true,
                Result = LoginResults.isSuccess
            };
        }

        public async Task<ServiceResult> CreateUserAsync(User user, string pasword)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                user.PasswordHash = Hasher.HashPassword(pasword);
                UnitOfWork.Users.Add(user);
                await UnitOfWork.SaveChangesAsync();
                result.Errors.Add("Kullanıcı kaydı başarıyla tamamlandı;");
                result.isSuccess = true;               
            }
            catch (Exception ex)
            {
                result.isSuccess = true;
                result.Errors.Add(ex.Message);
            }
            return result;

        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            return UnitOfWork.Users.Get(expression);
        }

        public IQueryable<User> GetAll()
        {
            return UnitOfWork.Users.GetAll();
        }

        public IQueryable<User> GetList(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> UpdateAsync(User user)
        {
            var result = new ServiceResult(false);

            try
            {
                var currentUser = await UnitOfWork.Users.GetAsync(a => a.UserID == user.UserID);
                currentUser.NameSurname = user.NameSurname;
                currentUser.EMail = currentUser.EMail;
                currentUser.LastUpdatedDate = user.LastUpdatedDate;
                UnitOfWork.Users.Update(currentUser);

                result.isSuccess = await UnitOfWork.SaveChangesAsync() >0;
                if (result.isSuccess)
                {
                    result.Errors.Add("Kayıt güncellendi");
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            return await UnitOfWork.Users.GetAsync(expression);
        }

        public async Task<ServiceResult> ResetPasswordAsync(int userID, string newPassword)
        {
            var result = new ServiceResult(false);
            try
            {
                var user = await UnitOfWork.Users.GetAsync(a => a.UserID == userID);
                if (user == null)
                    throw new NullReferenceException("Kullanıcı bulunamadı");
                user.PasswordHash = NASEB.Library.Helper.Security.Hasher.HashPassword(newPassword);
                user.LastUpdatedDate = DateTime.Now;
                UnitOfWork.Users.Update(user);
                await UnitOfWork.SaveChangesAsync();
                result.isSuccess = true;
                result.Errors.Add("Parala başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }
            return result;
        }

        public Task<int> CountAsync(Expression<Func<User, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<User, bool>> expression = null)
        {
            return UnitOfWork.Users.GetCount(expression);
        }
    }
}
