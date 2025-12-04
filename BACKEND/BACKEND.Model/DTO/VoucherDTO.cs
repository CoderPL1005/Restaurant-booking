using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.DTO
{
    public class VoucherDTO
    {
        public int VoucherId { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public string DiscountType { get; set; }
        public decimal? DiscountValue { get; set; }
        public int? MaxUsage { get; set; }
        public int? MaxUsagePerUser { get; set; }
        public decimal MinSpend { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
