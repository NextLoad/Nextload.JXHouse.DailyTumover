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
    public class HouseUsage2Service : BaseService<HouseUsage2>, IHouseUsage2Service
    {
        public HouseUsage2Service(DbContext context) : base(context)
        {
        }
    }
}
