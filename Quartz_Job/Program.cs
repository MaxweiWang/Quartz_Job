using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz_Job
{
    class Program
    {
        static void Main(string[] args)
        {
            RunScheduler();
            Console.ReadLine();
        }

        private static async Task RunScheduler()
        {
            // 创建作业调度器    
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            // 启动调度器
            await scheduler.Start();
            // 创建作业 
            IJobDetail job = JobBuilder.Create<HelloJob>() .WithIdentity("job1", "group1") .Build();
            // 创建触发器，每10s执行一次 
            ITrigger trigger = TriggerBuilder.Create() .WithIdentity("trigger1", "group1") .StartNow() .WithSimpleSchedule(x => x .WithIntervalInSeconds(10) .RepeatForever()) .Build();
            // 加入到作业调度器中 
            await scheduler.ScheduleJob(job, trigger); } 

    }
}
