using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.JXHouse.Models
{
    public class BaseModel
    {
        public long Id { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public long? CreateUser { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public long? LastModifyUser { get; set; }
        public bool IsDelete { get; set; }
    }
}
