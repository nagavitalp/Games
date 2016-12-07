using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace SampleMazeClient
{
    public static class DependencyFactory
    {
        static DependencyFactory()
        {
            var container = new UnityContainer();
            var section = (UnityConfigurationSection) ConfigurationManager.GetSection("unity");
            section?.Configure(container);
            Container = container;
        }


        public static IUnityContainer Container { get; }

        public static T Resolve<T>()
        {
            var ret = default(T);

            if (Container.IsRegistered(typeof (T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }
    }
}