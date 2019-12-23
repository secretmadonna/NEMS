using log4net;
using log4net.Config;
using SecretMadonna.NEMS.UI.TestLibrary;
using System;
using System.Reflection;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace SecretMadonna.NEMS.UI.TestConsole
{
    /// <summary>
    /// 面向对象三大特性：封装、继承、多态（静态多态性（编译时）、动态多态性（运行时））
    /// </summary>
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));
        private static int numberIndex = 0;

        static Program()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public Program()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~Program()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        static void Main(string[] args)
        {
            var type = typeof(BaseClass);
            Console.ReadKey();
        }
    }
}
