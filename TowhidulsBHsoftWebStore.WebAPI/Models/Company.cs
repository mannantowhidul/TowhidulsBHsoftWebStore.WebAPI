using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static TowhidulsBHsoftWebStore.WebAPI.Models.Supplier;

namespace TowhidulsBHsoftWebStore.WebAPI.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Company = new HashSet<Company>();
            Permissions = new HashSet<Permissions>();
        }

        public int AdminId { get; set; }
        public string AdminName { get; set; }

        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<Permissions> Permissions { get; set; }
    }

    public partial class Company
    {
        public Company()
        {
            Buyer = new HashSet<Buyer>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int AdminId { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual ICollection<Buyer> Buyer { get; set; }
    }

    public partial class Buyer
    {
        public Buyer()
        {
            BuyerRequestSubmission = new HashSet<BuyerRequestSubmission>();
        }

        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<BuyerRequestSubmission> BuyerRequestSubmission { get; set; }
    }

    public partial class Supplier
    {
        public Supplier()
        {
            SupplierProcessNpractice = new HashSet<SupplierProcessNpractice>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int BuyerId { get; set; }

        public virtual ICollection<SupplierProcessNpractice> SupplierProcessNpractice { get; set; }
        public virtual ICollection<Buyer> Buyer { get; set; }
    }

    public partial class SupplierProcessNpractice
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string Practice { get; set; }
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
    }

    public partial class BuyerRequestSubmission
    {
        public int RequestId { get; set; }
        public string ReuestDetails { get; set; }
        public int BuyerId { get; set; }
        public int SupplierId { get; set; }
        public int CompanyId { get; set; }

        public virtual Buyer Buyer { get; set; }
    }

    public partial class Permissions
    {
        public int PermissionId { get; set; }
        public int BuyerNos { get; set; }
        public int SupplierNos { get; set; }
        public int UserId { get; set; }

        public virtual Admin User { get; set; }
    }
}
