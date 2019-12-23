using log4net;
using System.Reflection;

namespace SecretMadonna.NEMS.UI.TestConsole
{
    abstract class Animal
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

        #region 嵌套类
        /// <summary>
        /// 嵌套类修饰符（默认 private）
        ///   7、protected : 
        ///   8、protected internal 或 internal protected : 
        ///   9、private : 
        /// </summary>
        internal protected class NestFatcherClass
        {

        }
        #endregion
    }
}
