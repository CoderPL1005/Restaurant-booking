using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Entities
{
    public class MenuItems
    {
        public int ItemId { get; set; }
        public int? CategoryId { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation
        public MenuCategories Category { get; set; }
        public ICollection<MenuItemPrices> Prices { get; set; } = new List<MenuItemPrices>();
        public ICollection<ReservationOrderItems> OrderItems { get; set; } = new List<ReservationOrderItems>();
    }
}
