using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.DTO
{
    public class MenuItemPriceDTO
    {
        public int PriceId { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}
