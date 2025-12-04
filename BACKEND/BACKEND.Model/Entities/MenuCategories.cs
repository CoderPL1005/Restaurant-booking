using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class MenuCategories
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int SortOrder { get; set; }
        public bool isDeleted { get; set; }

        // Navigation
        public ICollection<MenuItems> MenuItems { get; set; } = new List<MenuItems>();
    }
}
