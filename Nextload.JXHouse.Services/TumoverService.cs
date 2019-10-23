using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Nextload.JXHouse.IServices;
using Nextload.JXHouse.Models;

namespace Nextload.JXHouse.Services
{
    public class TumoverService : BaseService<Tumover>, ITumoverService
    {
        public TumoverService(DbContext context) : base(context)
        {
            

        }

        public Tumover[] GeTumovers(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            return Context.Set<Tumover>()
                .Where(t => t.ScDateTime.Year == year && t.ScDateTime.Month == month && t.ScDateTime.Day == day)
                .OrderByDescending(t => t.ScDateTime).Take(6).ToArray();
        }
    }
}
