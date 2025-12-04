using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class ReservationTables
    {
        public int ReservationTableId { get; set; }
        public int ReservationId { get; set; }
        public int TableId { get; set; }

        // Navigation
        public Reservations Reservation { get; set; }
        public RestaurantTables Table { get; set; }
    }
}
