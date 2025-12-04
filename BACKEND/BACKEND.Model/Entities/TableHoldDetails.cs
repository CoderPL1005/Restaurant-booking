using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class TableHoldDetails
    {
        public int HoldDetailId { get; set; }
        public Guid HoldId { get; set; }
        public int TableId { get; set; }

        // Navigation
        public TableHolds TableHold { get; set; }
        public RestaurantTables Table { get; set; }
    }
}
