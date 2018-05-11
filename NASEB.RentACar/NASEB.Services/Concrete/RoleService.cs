using NASEB.DAL.Abstruck;
using NASEB.Entities.Concrete;
using NASEB.Services.Abstruck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NASEB.Services.Concrete
{
    public class RoleService : IRoleService
    {

        private IUnitOfWork unitOfWork;
        public RoleService(IUnitOfWork work)
        {
            unitOfWork = work;
        }
        public bool Add(NASEBRole entity)
        {
            unitOfWork.Roles.Add(entity);

            return unitOfWork.SaveChnages() > 0;
        }

        public async Task<bool> AddAsync(NASEBRole entity)
        {
           
            unitOfWork.Roles.Add(entity);
            return await unitOfWork.SaveChangesAsync() > 0;
        }

      

        public bool Delete(NASEBRole entity)
        {
            unitOfWork.Roles.Delete(entity);
            return unitOfWork.SaveChnages() > 0;
        }

        public async Task<bool> DeleteAsync(NASEBRole entity)
        {
            unitOfWork.Roles.Delete(entity);
            return await unitOfWork.SaveChangesAsync() > 0;
        }

        public NASEBRole Get(Expression<Func<NASEBRole, bool>> expression)
        {
            return unitOfWork.Roles.Get(expression);
        }

        public IQueryable<NASEBRole> GetAll()
        {
            return unitOfWork.Roles.GetAll();
        }

        public Task<NASEBRole> GetAsync(Expression<Func<NASEBRole, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<NASEBRole> GetList(Expression<Func<NASEBRole, bool>> expression = null)
        {
            return unitOfWork.Roles.GetList(expression);
        }

        public IQueryable<NASEBRole> GetUserRolesByUserID(int id)
        {
            var user = new NASEBUser() { UserID = id };
            return unitOfWork.Roles.GetRolesByUser(user);
        }

        public bool Update(NASEBRole entity)
        {
            unitOfWork.Roles.Update(entity);
            return unitOfWork.SaveChnages() > 0;
        }

        public async Task<bool> UpdateAsync(NASEBRole entity)
        {
            unitOfWork.Roles.Update(entity);
            return await unitOfWork.SaveChangesAsync() > 0;
        }

    }
}
