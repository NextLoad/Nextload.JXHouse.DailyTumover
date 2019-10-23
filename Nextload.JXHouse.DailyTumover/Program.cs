using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.Configuration;
using Newtonsoft.Json;
using Nextload.JXHouse.DailyTumover.Quartz;
using Nextload.JXHouse.Framework;
using Nextload.JXHouse.IServices;
using Nextload.JXHouse.JsonModel;
using Nextload.JXHouse.Models;
using Nextload.JXHouse.Models.Context;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Unity;

namespace Nextload.JXHouse.DailyTumover
{
    class Program
    {
        public static IUnityContainer container;
        static void Main(string[] args)
        {
            try
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");//找配置文件的路径
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                container = new UnityContainer();
                section.Configure(container, "tumoverContainer");
                IHouseUsage2Service houseUsage2Service = container.Resolve<IHouseUsage2Service>();
                IHouseUsageService houseUsageService = container.Resolve<IHouseUsageService>();
                ITotalTumoverService totalTumoverService = container.Resolve<ITotalTumoverService>();
                ITumoverService tumoverService = container.Resolve<ITumoverService>();
                IRegionService regionService = container.Resolve<IRegionService>();

                //GetTumoverJob getTumoverJob = new GetTumoverJob(houseUsage2Service, houseUsageService, totalTumoverService, tumoverService, regionService);
                GetTumoverJob.StartSchedul(houseUsage2Service, houseUsageService, totalTumoverService, tumoverService, regionService);
                

                Console.WriteLine($"时间：{DateTime.Now}，已成功开启定时获取");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            Console.ReadKey();
        }

       
    }
}
