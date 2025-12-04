using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.DTO
{
    public class UserPointDTO
    {
        public int UserId { get; set; }
        public long TotalPoints { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
