using log4net;
using System.Reflection;

namespace SecretMadonna.NEMS.UI.TestConsole
{
    public abstract class Animal
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Animal));
        private static int numberIndex = 0;
        static Animal()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public Animal()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~Animal()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 动物的名称
        /// </summary>
        protected string name;
    }
}
