using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowhidulsBHsoftWebStore.WebAPI.Models
{
    public class CompanyContext: DbContext
    {
        public CompanyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Buyer> Buyer { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierProcessNpractice> SupplierProcessNpractice { get; set; }
        public DbSet<BuyerRequestSubmission> BuyerRequestSubmission { get; set; }
    }
}
