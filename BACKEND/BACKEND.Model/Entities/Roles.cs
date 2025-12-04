using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        // Navigation
        public ICollection<Users> Users { get; set; } = new List<Users>();
    }
}
