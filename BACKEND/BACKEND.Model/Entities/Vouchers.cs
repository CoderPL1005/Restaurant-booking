using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class Vouchers
    {
        public int VoucherId { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public string DiscountType { get; set; } // Percent / Fixed / FreeItem
        public decimal? DiscountValue { get; set; }
        public int? MaxUsage { get; set; }
        public int? MaxUsagePerUser { get; set; }
        public decimal MinSpend { get; set; } = 0;
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<UserVouchers> UserVouchers { get; set; } = new List<UserVouchers>();
    }
}
