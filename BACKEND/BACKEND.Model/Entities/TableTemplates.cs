using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class TableTemplates
    {
        public int TemplateId { get; set; }
        public string TemplateCode { get; set; }
        public int Seats { get; set; } = 6;
        public string? Description { get; set; }

        // Navigation
        public ICollection<RestaurantTables> RestaurantTables { get; set; } = new List<RestaurantTables>();
    }
}
