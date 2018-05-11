using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace NASEB.DAL.Concrete.EF
{
    public class EFNASEBDBContext:DbContext
    {
        public EFNASEBDBContext(DbContextOptions<EFNASEBDBContext> options):base(options)
        {

        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }

        public virtual DbSet<NASEBUser> Users { get; set; }
        public virtual DbSet<NASEBRole> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //for userrole
            modelBuilder.Entity<UserRole>().HasKey(qk => new
            {
                qk.UserID,
                qk.RoleID
            });

            //unique tc için 
              modelBuilder.Entity<Customer>().HasIndex(a => a.TRIDNo).IsUnique(true);
            
        }
    }

   
}
