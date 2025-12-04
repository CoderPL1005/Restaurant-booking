using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.DTO
{
    public class WaitingListDTO
    {
        public int WaitingId { get; set; }
        public int? UserId { get; set; }
        public string? GuestName { get; set; }
        public string? Phone { get; set; }
        public int GuestCount { get; set; }
        public TimeSpan RequestedAt { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? SeatedAt { get; set; }
        public string? Notes { get; set; }
    }
}
