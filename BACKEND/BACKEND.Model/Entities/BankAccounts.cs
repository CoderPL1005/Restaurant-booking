using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class BankAccounts
    {
        public int BankAccountId { get; set; }
        public int UserId { get; set; }
        public string BankAccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? AccountHolderName { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public Users User { get; set; }
    }
}
