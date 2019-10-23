using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.JXHouse.Models
{
    public class Tumover : BaseModel
    {
        public long RegionId { get; set; }
        public virtual Region Region { get; set; }

        public long HouseUsageId { get; set; }
        public virtual HouseUsage HouseUsage { get; set; }

        public int Count { get; set; }
        public double Area { get; set; }

        /// <summary>
        /// 扫描记录时间
        /// </summary>
        public DateTime ScDateTime { get; set; }
    }
}
