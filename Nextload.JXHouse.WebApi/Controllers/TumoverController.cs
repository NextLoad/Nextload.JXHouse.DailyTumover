using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Nextload.JXHouse.IServices;
using Nextload.JXHouse.JsonModel;
using Nextload.JXHouse.Models;
using Nextload.JXHouse.WebApi.ViewModels;

namespace Nextload.JXHouse.WebApi.Controllers
{
    public class TumoverController : ApiController
    {
        private ITumoverService tumoverService;
        private ITotalTumoverService totalTumoverService;

        public TumoverController(ITumoverService tumoverService, ITotalTumoverService totalTumoverService)
        {
            this.tumoverService = tumoverService;
            this.totalTumoverService = totalTumoverService;
        }
        private Tumover[] GetTumovers()
        {
            return GetTumovers(DateTime.Now);
        }
        private Tumover[] GetTumovers(DateTime? date)
        {
            if (date == DateTime.MinValue)
            {
                date = DateTime.Now;
            }
            var model = tumoverService.GeTumovers(date.Value);
            return model;
        }
        [HttpPost]
        private TotalTumover[] GetTotalTumover()
        {
            return GetTotalTumover(DateTime.Now);
        }
        [HttpPost]
        private TotalTumover[] GetTotalTumover(DateTime? date)
        {
            if (date == DateTime.MinValue)
            {
                date = DateTime.Now;
            }
            var model = totalTumoverService.GetTotalTumover(date.Value);
            return model;
        }


        //[HttpPost]
        //public TumoverInfos GetJxSpf()
        //{
        //    return GetJxSpf(DateTime.Now);
        //}
        [HttpPost]
        public TumoverInfos GetJxSpf()
        {
            var request = HttpContext.Current.Request;
            DateTime date = Convert.ToDateTime(request.Form["date"]);
            if (date == DateTime.MinValue)
            {
                date = DateTime.Now;
            }
            var tumovers = GetTumovers(date);
            var totalTumovers = GetTotalTumover(date);
            TumoverInfos tumoverInfo = new TumoverInfos();
            tumoverInfo.ScDatetime = DateTime.Now;
            if (tumovers == null || totalTumovers == null || tumovers.Length == 0 || totalTumovers.Length == 0)
                return tumoverInfo;
            tumoverInfo.Tumovers = GetTumovers(date);
            tumoverInfo.TotalTumovers = GetTotalTumover(date);
            tumoverInfo.ScDatetime = tumoverInfo.Tumovers[0].ScDateTime;
            return tumoverInfo;
        }
    }
}
