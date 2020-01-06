using log4net;
using log4net.Config;
using Quartz;
using Quartz.Impl;
using System;
using System.Reflection;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace SecretMadonna.NEMS.UI.TestQuartz
{
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
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);

            var scheduler = StdSchedulerFactory.GetDefaultScheduler();
            var jobDetail = JobBuilder.Create<TestJob1>()
                .WithIdentity("statistic1", "statistic")
                .Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("statistic1", "statistic")
                .WithSimpleSchedule(ssb => ssb.WithIntervalInSeconds(3).RepeatForever())
                .Build();
            var triggers = new Quartz.Collection.HashSet<ITrigger>();
            triggers.Add(trigger);
            scheduler.ScheduleJob(jobDetail, triggers, true);
            scheduler.Start();
            Console.ReadKey();
        }
    }
}