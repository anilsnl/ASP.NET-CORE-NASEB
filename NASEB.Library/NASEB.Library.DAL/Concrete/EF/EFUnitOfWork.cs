using NASEB.Library.DAL.Abstract;
using NASEB.Library.Helper.AppSettings;
using System;
using System.Threading.Tasks;

namespace NASEB.Library.DAL.Concrete.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private NASEBLibraryDbContext _ctx;

        public EFUnitOfWork(NASEBLibraryDbContext context)
        {
            _ctx = context;
        }

        private IUserDAL _users;
        private IAuthorDAL _authors;
        private IRentDAL _rents;
        private IBookDAL _books;
        private IPublisherDAL _publishers;
        private IBookTypeDAL _bookTypes;
        private IRoleDAL _roles;
        private IMemberDAL _members;
        private IAppSettings _appSettings;

        public IUserDAL Users
        {
            get { return _users ?? new EFUserDAL(_ctx); }
        }
        public IAuthorDAL Authors
        {
            get { return _authors ?? new EFAuthorDAL(_ctx); }
        }
        public IRentDAL Rents
        {
            get { return _rents ?? new EFRentDAL(_ctx,_appSettings); }
        }
        public IPublisherDAL Publishers
        {
            get { return _publishers ?? new EFPublisherDAL(_ctx); }
        }

        public int SaveChanges()
        {
            return _ctx.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _ctx.SaveChangesAsync();
        }

        public IBookDAL Books
        {
            get { return _books ?? new EFBookDAL(_ctx); }
        }
        public IBookTypeDAL BookTypes
        {
            get { return _bookTypes ?? new EFBookTypeDAL(_ctx); }
        }
        public IMemberDAL Members
        {
            get { return _members ?? new EFMemberDAL(_ctx); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
