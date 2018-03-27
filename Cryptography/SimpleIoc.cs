//////////////////////////////////////////////////////////////////////
//
// https://fengyh.cn
//
//////////////////////////////////////////////////////////////////////

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Cryptography
{
    class SimpleIoc
    {
        public IUnityContainer Container { get; set; } = null;

        private static SimpleIoc instance = null;

        private SimpleIoc()
        {
            Container = null;
        }

        /// <summary>
        /// 单例,静态方法
        /// </summary>
        public static SimpleIoc GetInstance()
        {
            if (instance == null || instance.Container == null)
            {
                instance = new SimpleIoc() { Container = GetContainer() };
            }

            return instance;
        }

        /// <summary>
        /// 从配置文件构建UnityContainer
        /// </summary>
        /// <param name="configFile">Unity配置文件名</param>
        /// <param name="sectionName">UnitySection名称</param>
        /// <param name="containerName">UnityContainer名称</param>
        private static IUnityContainer GetContainer(
            string configFile = "algorithm.config",
            string sectionName = "algorithmSection",
            string containerName = "algorithmContainer")
        {
            var container = new UnityContainer();
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configFile };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection(sectionName);
            container.LoadConfiguration(unitySection, containerName);

            return container;
        }

        /// <summary>
        /// 根据类型构建对象
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <returns>构建的目标</returns>
        public static T GetInstanceDAL<T>()
            where T : class
        {
            return GetInstance().Container.Resolve<T>();
        }
    }
}
