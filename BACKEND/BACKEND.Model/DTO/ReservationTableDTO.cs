using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.DTO
{
    public class ReservationTableDTO
    {
        public int ReservationTableId { get; set; }
        public int ReservationId { get; set; }
        public int TableId { get; set; }
    }
}
