using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nextload.JXHouse.Models;

namespace Nextload.JXHouse.IServices
{
    public interface ITotalTumoverService:IBaseService<TotalTumover>
    {
        TotalTumover[] GetTotalTumover(DateTime date);
    }
}
