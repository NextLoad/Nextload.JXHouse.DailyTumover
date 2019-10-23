using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nextload.JXHouse.Models;

namespace Nextload.JXHouse.WebApi.ViewModels
{
    public class TumoverInfos
    {
        public Tumover[] Tumovers { get; set; }
        public TotalTumover[] TotalTumovers { get; set; }
        public DateTime ScDatetime { get; set; }
    }
}