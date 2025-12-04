using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.DTO
{
    public class TableHoldDTO
    {
        public Guid HoldId { get; set; }
        public string SessionId { get; set; }
        public int? UserId { get; set; }
        public DateTime StartTime { get; set; }
        public string HoldStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpireAt { get; set; }
    }

}
