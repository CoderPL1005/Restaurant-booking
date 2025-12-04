using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class Reservations
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public string ReservationCode { get; set; }
        public DateTime? ReservedAt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int GuestCount { get; set; }
        public string Status { get; set; } = "Confirmed";
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; }

        // Navigation
        public Users User { get; set; }
        public ICollection<ReservationTables> ReservationTables { get; set; } = new List<ReservationTables>();
        public ICollection<ReservationOrders> ReservationOrders { get; set; } = new List<ReservationOrders>();
        public ICollection<Payments> Payments { get; set; } = new List<Payments>();
    }
}
