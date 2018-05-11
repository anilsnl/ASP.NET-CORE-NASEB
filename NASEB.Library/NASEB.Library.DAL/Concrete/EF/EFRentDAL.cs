using NASEB.Entities.ComplexType;
using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.Helper.AppSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NASEB.Library.DAL.Concrete.EF
{
    public class EFRentDAL : EFBaseDAL<RentHistory>,IRentDAL
    {
        private NASEBLibraryDbContext _context;
        private IAppSettings _appSettings;
        public EFRentDAL(NASEBLibraryDbContext context, IAppSettings appSett) : base(context)
        {
            _context = context;
            _appSettings = appSett;
        }

        public IQueryable<RentHistoryView> GetRentHistoryView(Expression<Func<RentHistoryView, bool>> expression=null)
        {
            var list= (from rent in _context.Rents
                    join membe in _context.Members on
                    rent.MemberID equals membe.MemberID
                    join book in _context.Books
                    on rent.BookID equals book.BookID
                    join cuser in _context.Users on
                    rent.UserID equals cuser.UserID
                    select new RentHistoryView()
                    {
                        BookID = book.BookID,
                        BookName = book.BookName,
                        CreatedInfo = rent.CreatedDate.ToString("dd/MM/yyyy") + " - " + cuser.NameSurname,
                        DelayFine = rent.DelayFine,
                        Durum = GetStatus(rent),
                        LastUpdatedInfo = rent.LastUpdatedDate.ToString("dd/MM/yyyy"),
                        MemberID = membe.MemberID,
                        MemberName = membe.Name + " " + membe.Surname,
                        RegistereedYear = rent.CreatedDate.Year,
                        RentID = rent.RentID

                    });
            return expression == null ? list : list.Where(expression);
        }

        public IQueryable<RentOverviewView> GetRentOverviewView(Expression<Func<RentOverviewView, bool>> expression)
        {
            return (from rent in _context.Rents
                    join membe in _context.Members on
                    rent.MemberID equals membe.MemberID
                    join book in _context.Books
                    on rent.BookID equals book.BookID
                    select new RentOverviewView()
                    {
                        ExpactedEndDate = rent.RentEndDate,
                        BookName=book.BookName,
                        MemberNameSurname = membe.Name + " " + membe.Surname,
                        MemberID = rent.MemberID,
                        StartDate = rent.RentDate,
                        MemberPhoneNumber = membe.PhoneNumber,
                        RentID = rent.RentID,
                        Status = GetStatus(rent),
                        isRentingCompleted=rent.isRentingCompleted
                    }).Where(expression);
        }

       private string GetStatus(RentHistory rent)
        {
            var result= new StringBuilder();
            if (rent.isRentingCompleted)
            {
                result.Append("Tamamlandı - "+rent.DeliveredDate.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm"));
               
            }
            else
            {
                result.Append("Devam Ediyor - ");
                var tempSpam = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) - rent.RentEndDate;
                if (tempSpam.TotalDays<=0)
                {
                    result.Append("Gecikme Yok");
                }
                else
                {
                    
                    result.Append("Gecikti Ceza: ₺"+(5.50*tempSpam.TotalDays).ToString());
                }
            }
            return result.ToString();
        }

    }
}
