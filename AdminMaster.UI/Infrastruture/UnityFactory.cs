using DataAccessLayer;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace AdminMaster.UI.Infrastruture
{
    public class UnityFactory
    {
        private static IUnityContainer container = null;
        static UnityFactory()
        {
            //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            //fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");//找配置文件的路径
            //Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            //UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            //container = new UnityContainer();
            //section.Configure(container, "ruanmouContainer");
            container = new UnityContainer();
            container.RegisterType<IInvCollectionRepository, InvCollectionRepository>();
        }
        public static IUnityContainer CreateContainer()
        {
            return container;
        }
    }
}