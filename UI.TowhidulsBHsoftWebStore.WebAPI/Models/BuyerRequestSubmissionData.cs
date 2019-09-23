using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.TowhidulsBHsoftWebStore.WebAPI.Models
{
    public class BuyerRequestSubmissionData
    {
        public int RequestId { get; set; }
        public string ReuestDetails { get; set; }
        public int BuyerId { get; set; }
        public int SupplierId { get; set; }
        public int CompanyId { get; set; }
    }
}
