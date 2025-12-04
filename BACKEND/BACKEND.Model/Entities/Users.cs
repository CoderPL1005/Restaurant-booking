using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class Users
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int RoleId { get; set; }
        public string? LanguagePref { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; }

        // Navigation
        public Roles Role { get; set; }
        public ICollection<BankAccounts> BankAccounts { get; set; } = new List<BankAccounts>();
        public ICollection<UserVouchers> UserVouchers { get; set; } = new List<UserVouchers>();
        public UserPoints UserPoints { get; set; }
        public ICollection<Reservations> Reservations { get; set; } = new List<Reservations>();
        public ICollection<ReservationOrders> ReservationOrders { get; set; } = new List<ReservationOrders>();
        public ICollection<TableHolds> TableHolds { get; set; } = new List<TableHolds>();
        public ICollection<WaittingList> WaittingList { get; set; } = new List<WaittingList>();
    }

}
