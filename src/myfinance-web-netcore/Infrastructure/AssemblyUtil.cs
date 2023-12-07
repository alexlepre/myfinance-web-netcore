using System.Collections.Generic;
using System.Reflection;

namespace myfinance_web_netcore.Infrastructure
{
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {
            return new Assembly[]
            {
            Assembly.Load("myfinance-web-netcore"),
            };

        }
    }
}