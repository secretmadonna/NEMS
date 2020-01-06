using log4net;
using Quartz;
using System;
using System.Reflection;

namespace SecretMadonna.NEMS.UI.TestQuartz
{
    public class TestJob2 : IJob
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(TestJob2));
        private static int numberIndex = 0;

        static TestJob2()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public TestJob2()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~TestJob2()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        public void Execute(IJobExecutionContext context)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
    }
}
