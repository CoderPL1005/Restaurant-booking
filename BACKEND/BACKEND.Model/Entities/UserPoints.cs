using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class UserPoints
    {
        public int UserId { get; set; }
        public long TotalPoints { get; set; } = 0;
        public DateTime LastUpdated { get; set; }

        // Navigation
        public Users User { get; set; }
    }
}
