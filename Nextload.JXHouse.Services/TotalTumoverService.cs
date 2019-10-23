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
    public class TotalTumoverService : BaseService<TotalTumover>, ITotalTumoverService
    {
        public TotalTumoverService(DbContext context) : base(context)
        {
        }

        public TotalTumover[] GetTotalTumover(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            return Context.Set<TotalTumover>()
                .Where(t => t.ScDateTime.Year == year && t.ScDateTime.Month == month && t.ScDateTime.Day == day)
                .OrderByDescending(t => t.ScDateTime).Take(4).ToArray();
        }
    }
}
