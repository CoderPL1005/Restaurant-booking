using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.DTO
{
    public class ReservationOrderDTO
    {
        public int OrderId { get; set; }
        public int ReservationId { get; set; }
        public string OrderType { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public string? Notes { get; set; }
    }
}
