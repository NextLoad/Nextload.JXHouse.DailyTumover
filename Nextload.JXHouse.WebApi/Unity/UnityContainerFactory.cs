using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace Nextload.JXHouse.WebApi.Unity
{
    public class UnityContainerFactory
    {
        private static IUnityContainer container;
        static UnityContainerFactory()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");//找配置文件的路径
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            container = new UnityContainer();
            section.Configure(container, "tumoverContainer");
        }

        public static IUnityContainer GetUnityContainer()
        {
            return container;
        }
    }
}