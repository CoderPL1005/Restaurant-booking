using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class ReservationOrders
    {
        public int OrderId { get; set; }
        public int ReservationId { get; set; }
        public string OrderType { get; set; } = "PreOrder";
        public string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public string? Notes { get; set; }

        // Navigation
        public Reservations Reservation { get; set; }
        public Users CreatedByUser { get; set; }
        public ICollection<ReservationOrderItems> Items { get; set; } = new List<ReservationOrderItems>();
    }
}
