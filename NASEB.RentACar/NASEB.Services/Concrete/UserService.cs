using NASEB.DAL.Abstruck;
using NASEB.Entities.ComplexType;
using NASEB.Entities.Concrete;
using NASEB.Helper.Security;
using NASEB.Services.Abstruck;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NASEB.Services.Concrete
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork work)
        {
            unitOfWork = work;
        }
        public bool Add(NASEBUser entity)
        {
            entity.PasswordHash = Hasher.HashPassword(entity.PasswordHash);
            unitOfWork.Users.Add(entity);

            return unitOfWork.SaveChnages() > 0;
        }

        public async Task<bool> AddAsync(NASEBUser entity)
        {
            entity.PasswordHash = Hasher.HashPassword(entity.PasswordHash);
            unitOfWork.Users.Add(entity);
            return await unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> ChangePasswordAsync(NASEBUser user, string password)
        {
            var _user = unitOfWork.Users.Get(a => a.UserID== user.UserID && a.EMail.Equals(user.EMail));
            if (_user == null)
                return false;
            user.PasswordHash = Hasher.HashPassword(password);
            unitOfWork.Users.Update(_user);
            return await unitOfWork.SaveChangesAsync()>0;
        }

        public bool Delete(NASEBUser entity)
        {
            unitOfWork.Users.Delete(entity);
            return unitOfWork.SaveChnages() > 0;
        }

        public async Task<bool> DeleteAsync(NASEBUser entity)
        {
            unitOfWork.Users.Delete(entity);
            return await unitOfWork.SaveChangesAsync() > 0;
        }

        public NASEBUser Get(Expression<Func<NASEBUser, bool>> expression)
        {
            return unitOfWork.Users.Get(expression);
        }

        public IQueryable<NASEBUser> GetAll()
        {
            return unitOfWork.Users.GetAll();
        }

        public Task<NASEBUser> GetAsync(Expression<Func<NASEBUser, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<NASEBUser> GetList(Expression<Func<NASEBUser, bool>> expression = null)
        {
            return unitOfWork.Users.GetList(expression);
        }

        public bool Update(NASEBUser entity)
        {
            unitOfWork.Users.Update(entity);
            return unitOfWork.SaveChnages() > 0;
        }

        public async Task<bool> UpdateAsync(NASEBUser entity)
        {
            unitOfWork.Users.Update(entity);
            return await unitOfWork.SaveChangesAsync() > 0;
        }

        public IQueryable<UserBranchView> UserBranchName()
        {
            return unitOfWork.Users.ReachtoBranchFromUser();

        }

        public LoginResult VerifyForLogin(string email, string password)
        {
            var hshedPassword = Hasher.HashPassword(password);
            var user = unitOfWork.Users.Get(a => a.EMail.Equals(email) && a.PasswordHash.Equals(hshedPassword));
            if (user==null)
            {
                return new LoginResult()
                {
                    isSuccess = false,
                    Result = LoginResults.InvalidUser
                };
            }
            if(user.isActive==false)
                return new LoginResult()
                {
                    isSuccess = false,
                    Result = LoginResults.NotActiveAccount
                };
            return new LoginResult()
            {
                isSuccess = true,
                Result = LoginResults.isSuccess
            };
        }
    }
}
