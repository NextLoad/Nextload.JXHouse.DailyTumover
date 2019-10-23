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
    public class HouseUsageService : BaseService<HouseUsage>, IHouseUsageService
    {
        public HouseUsageService(DbContext context) : base(context)
        {
        }
    }
}
