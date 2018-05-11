using NASEB.DAL.Abstruck.Entities;
using NASEB.Entities.ComplexType;
using NASEB.Entities.Concrete;
using System.Linq;

namespace NASEB.DAL.Concrete.EF
{
    public class EFCarDAL : EFBaseDAL<Car>, ICarDAL
    {
        private EFNASEBDBContext _context;
        public EFCarDAL(EFNASEBDBContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<CarBranchView> GetBranchNameOfCars()
        {
            var result = (from r in _context.Cars
                          join branchw in _context.Branches on r.ExistingBranchID equals branchw.BranchID
                          select new CarBranchView()
                          {
                              CarID = r.CarID,
                              CarName = r.CarName,
                             Details = r.Detail,
                             BranchID = r.ExistingBranchID,
                             BranchName = branchw.BranchName,
                             LicenseInfo = r.LicenseInfo,
                             Plate = r.Plate,
                             Status = r.Status,
                             RegisterDate = r.RegisterDate
                         });
            return result;
        }
       
    }
}
