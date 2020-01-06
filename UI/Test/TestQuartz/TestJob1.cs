using log4net;
using Quartz;
using System;
using System.Reflection;
using System.Threading;

namespace SecretMadonna.NEMS.UI.TestQuartz
{
    [DisallowConcurrentExecution]
    public class TestJob1 : IJob
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(TestJob1));
        private static int numberIndex = 0;

        static TestJob1()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public TestJob1()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~TestJob1()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        public void Execute(IJobExecutionContext context)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            var ctx = context;
            Thread.Sleep(7000);
        }
    }
}
