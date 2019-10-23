using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nextload.JXHouse.Framework;
using Nextload.JXHouse.IServices;
using Nextload.JXHouse.JsonModel;
using Nextload.JXHouse.Models;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace Nextload.JXHouse.DailyTumover.Quartz
{
    public class GetTumoverJob : IJob
    {
        private Logger _logger = Logger.CreateLogger(typeof(GetTumoverJob));
        private static IHouseUsage2Service houseUsage2Service;
        private static IHouseUsageService houseUsageService;
        private static ITotalTumoverService totalTumoverService;
        private static ITumoverService tumoverService;
        private static IRegionService regionService;
        public GetTumoverJob() { }
        //public GetTumoverJob(IHouseUsage2Service houseUsage2Service,
        //    IHouseUsageService houseUsageService,
        //    ITotalTumoverService totalTumoverService,
        //    ITumoverService tumoverService,
        //    IRegionService regionService)
        //{
        //    this.houseUsage2Service = houseUsage2Service;
        //    this.houseUsageService = houseUsageService;
        //    this.totalTumoverService = totalTumoverService;
        //    this.tumoverService = tumoverService;
        //    this.regionService = regionService;
        //}

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var response = HttpHelper.HttpPost("http://wg.jxbuild.gov.cn/CurrentDeal", "");
                string content = response.Result.Content.ReadAsStringAsync().Result;
                JXSpf jxSpf = JsonConvert.DeserializeObject<JXSpf>(content);
                List<Tumover> tumoverList = new List<Tumover>();
                foreach (var item in jxSpf.spfcjbyqy)
                {
                    if (item.qymc == "合计") continue;
                    Tumover zzTumover = new Tumover()
                    {
                        Area = Convert.ToDouble(item.zzcjmj),
                        Count = Convert.ToInt32(item.zzcjts),
                        HouseUsageId = 1,
                        RegionId = regionService.GetByName(item.qymc),
                        ScDateTime = Convert.ToDateTime(jxSpf.scdatetime),
                    };
                    tumoverList.Add(zzTumover);
                    Tumover fzzTumover = new Tumover()
                    {
                        Area = Convert.ToDouble(item.fzzcjmj),
                        Count = Convert.ToInt32(item.fzzcjts),
                        HouseUsageId = 3,
                        RegionId = regionService.GetByName(item.qymc),
                        ScDateTime = Convert.ToDateTime(jxSpf.scdatetime),
                    };
                    tumoverList.Add(fzzTumover);

                }

                List<TotalTumover> totalTumoverList = new List<TotalTumover>();

                TotalTumover zzTotalTumover = new TotalTumover()
                {
                    Area = Convert.ToDouble(jxSpf.spfcjbylx.zzcjmj),
                    Count = Convert.ToInt32(jxSpf.spfcjbylx.zzcjts),
                    HouseUsage2Id = 1,
                    ScDateTime = Convert.ToDateTime(jxSpf.scdatetime)
                };
                totalTumoverList.Add(zzTotalTumover);

                TotalTumover syTotalTumover = new TotalTumover()
                {
                    Area = Convert.ToDouble(jxSpf.spfcjbylx.sycjmj),
                    Count = Convert.ToInt32(jxSpf.spfcjbylx.sycjts),
                    HouseUsage2Id = 2,
                    ScDateTime = Convert.ToDateTime(jxSpf.scdatetime)
                };
                totalTumoverList.Add(syTotalTumover);

                TotalTumover bgTotalTumover = new TotalTumover()
                {
                    Area = Convert.ToDouble(jxSpf.spfcjbylx.bgcjmj),
                    Count = Convert.ToInt32(jxSpf.spfcjbylx.bgcjts),
                    HouseUsage2Id = 3,
                    ScDateTime = Convert.ToDateTime(jxSpf.scdatetime)
                };
                totalTumoverList.Add(bgTotalTumover);

                TotalTumover qtTotalTumover = new TotalTumover()
                {
                    Area = Convert.ToDouble(jxSpf.spfcjbylx.qtcjmj),
                    Count = Convert.ToInt32(jxSpf.spfcjbylx.qtcjts),
                    HouseUsage2Id = 4,
                    ScDateTime = Convert.ToDateTime(jxSpf.scdatetime)
                };
                totalTumoverList.Add(qtTotalTumover);

                tumoverService.Insert(tumoverList);
                totalTumoverService.Insert(totalTumoverList);
                Console.WriteLine($"*****************时间：{DateTime.Now.ToString()},已成功获取数据*******************");
            }
            catch (Exception e)
            {
                _logger.Error(ex: e);
            }
        }


        public static void StartSchedul(IHouseUsage2Service houseUsage2,
            IHouseUsageService houseUsage,
            ITotalTumoverService totalTumover,
            ITumoverService tumover,
            IRegionService region)
        {
            houseUsage2Service = houseUsage2;
            houseUsageService = houseUsage;
            totalTumoverService = totalTumover;
            tumoverService = tumover;
            regionService = region;

            IScheduler sched = new StdSchedulerFactory().GetScheduler();
            JobDetailImpl jdBossReport = new JobDetailImpl("getTumoverJob", typeof(GetTumoverJob));

            CronScheduleBuilder cronScheduleBuilder = CronScheduleBuilder.CronSchedule("0 30 * * * ? *");

            //CronScheduleBuilder cronScheduleBuilder = CronScheduleBuilder.CronSchedule("* * * * * ? *");
            IMutableTrigger triggerBossReport = cronScheduleBuilder.Build();
            triggerBossReport.Key = new TriggerKey("getTumoverTrigger");
            sched.ScheduleJob(jdBossReport, triggerBossReport);
            sched.Start();
        }




    }
}
