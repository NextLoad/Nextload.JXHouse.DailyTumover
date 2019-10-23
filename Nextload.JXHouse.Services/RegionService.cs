using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nextload.JXHouse.IServices;
using Nextload.JXHouse.Models;

namespace Nextload.JXHouse.Services
{
    public class RegionService : BaseService<Region>, IRegionService
    {
        public RegionService(DbContext context) : base(context)
        {
        }

        public long GetByName(string name)
        {
            var region = base.Context.Set<Region>().Where(r => r.Name == name).FirstOrDefault();
            if(region == null) throw new Exception($"不存在的区域名称：{name}");
            return region.Id;
        }
    }
}
