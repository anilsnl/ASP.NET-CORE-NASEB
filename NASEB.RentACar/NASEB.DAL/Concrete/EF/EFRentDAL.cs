using NASEB.DAL.Abstruck.Entities;
using NASEB.Entities.ComplexType;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NASEB.DAL.Concrete.EF
{
    public class EFRentDAL:EFBaseDAL<Rent>,IRentDAL
    {
        private EFNASEBDBContext _context;

        public EFRentDAL(EFNASEBDBContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<RentCustomerBranchUserView> GetRentRelationalTablesInfo()
        {
            var result = (from r in _context.Rents
                          join customer in _context.Customers on r.CustomerID equals customer.CustomerID
                          join branch in _context.Branches on r.RentBranchID equals branch.BranchID
                          join user in _context.Users on r.UserID equals user.UserID
                          join car in _context.Cars on r.CarID equals car.CarID
                          select new RentCustomerBranchUserView()
                          {
                              CarName=car.CarName,
                              RentID = r.RentID,
                              CarID=r.CarID,
                              BranchName = branch.BranchName,
                              CustomerName = customer.Name,
                              RemainDebt = r.RemaindDebt,
                              CustomerSurname=customer.Surname,
                              UserName=user.Name,
                              UserSurname=user.Surname,
                              BranchID =branch.BranchID,
                              UserID=user.UserID,
                              CustomerID=customer.CustomerID,
                              DamagePrice=r.DamagePrice,
                              DelayFine=r.DelayFine,
                              RentEndDate=r.RentEndDate,
                              RentStartDate=r.RentStartDate,
                              TotalRentPrice=r.TotalRentPrice
                          });
            return result;
       

        }
    }
}
