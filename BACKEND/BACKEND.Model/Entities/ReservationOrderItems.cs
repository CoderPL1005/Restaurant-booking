using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class ReservationOrderItems
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; } = "Ordered";
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public ReservationOrders Order { get; set; }
        public MenuItems Item { get; set; }
    }
}
