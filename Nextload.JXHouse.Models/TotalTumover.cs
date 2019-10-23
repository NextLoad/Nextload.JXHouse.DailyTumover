using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.JXHouse.Models
{
    public class TotalTumover : BaseModel
    {
        public int Count { get; set; }
        public double Area { get; set; }
        public long HouseUsage2Id { get; set; }

        public virtual HouseUsage2 HouseUsage2 { get; set; }

        public DateTime ScDateTime { get; set; }
    }
}
