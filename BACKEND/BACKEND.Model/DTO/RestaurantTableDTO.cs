using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.DTO
{
    public class RestaurantTableDTO
    {
        public int TableId { get; set; }
        public string TableCode { get; set; }
        public int? TemplateId { get; set; }
        public string? Zone { get; set; }
        public int? PosX { get; set; }
        public int? PosY { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; }
        public decimal? Price { get; set; }
    }
}
