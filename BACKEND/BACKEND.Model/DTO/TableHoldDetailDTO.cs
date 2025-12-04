using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.DTO
{
    public class TableHoldDetailDTO
    {
        public int HoldDetailId { get; set; }
        public Guid HoldId { get; set; }
        public int TableId { get; set; }
    }
}
