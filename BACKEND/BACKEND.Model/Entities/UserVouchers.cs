using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class UserVouchers
    {
        public int UserVoucherId { get; set; }
        public int UserId { get; set; }
        public int VoucherId { get; set; }
        public DateTime AssignedDate { get; set; }
        public bool IsUsed { get; set; } = false;
        public DateTime? UsedDate { get; set; }

        // Navigation
        public Users User { get; set; }
        public Vouchers Voucher { get; set; }
    }
}
