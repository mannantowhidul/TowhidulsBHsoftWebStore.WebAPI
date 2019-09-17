using System.ComponentModel.DataAnnotations;

namespace TowhidulsBHsoftWebStore.WebAPI.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }

    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required]
        public string AdminName { get; set; }
    }

    public class Buyer
    {
        [Key]
        public int BuyerID { get; set; }
        [Required]
        public string BuyerName { get; set; }
        [Required]
        public int CompanyID { get; set; }
    }

    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        public string SupplierName { get; set; }
    }

    public class SupplierProcessNpractice
    {
        [Key]
        public int ProcessID { get; set; }
        [Required]
        public string ProcessName { get; set; }
        [Required]
        public string Practice { get; set; }
        [Required]
        public int SupplierID { get; set; }
    }

    public class BuyerRequestSubmission
    {
        [Key]
        public int RequestID { get; set; }
        [Required]
        public string ReuestDetails { get; set; }
        [Required]
        public int BuyerID { get; set; }
        [Required]
        public int SupplierID { get; set; }
        [Required]
        public int CompanyID { get; set; }
    }


}
