using System.Threading.Tasks;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.Services.Abstract
{
    public interface IPublisherService : IBaseService<Publisher>
    {
        Task<int> GetTotalBooksCountByPublisherIDAsync(int publisherid);
        Task<int> GetPublisherCount();
    }
}
