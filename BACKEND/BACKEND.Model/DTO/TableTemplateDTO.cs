using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.DTO
{
    public class TableTemplateDTO
    {
        public int TemplateId { get; set; }
        public string TemplateCode { get; set; }
        public int Seats { get; set; }
        public string? TableType { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
