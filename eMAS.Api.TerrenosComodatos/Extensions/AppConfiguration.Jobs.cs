using Hangfire;
using Microsoft.AspNetCore.Builder;
using System;
using Microsoft.Extensions.DependencyInjection;
using eMAS.Api.TerrenosComodatos.IServices;
using Microsoft.Extensions.Configuration;

namespace eMAS.Api.TerrenosComodatos.Extensions
{
    public static partial class AppConfiguration
    {
        public static void AddJobConfiguration(this IApplicationBuilder app
            , IRecurringJobManager recurringJobManager
            , IServiceProvider serviceProvider
            , IConfiguration configuration)
        {
            // Notificacion Job 1
            var _notificationJob = serviceProvider.GetService<INotificationTramiteOficioJob>();
            int hourNotificationJob = Convert.ToInt32(configuration["NotificationJob1:hour"].ToString());
            int minuteNotificationJob = Convert.ToInt32(configuration["NotificationJob1:minute"].ToString());
            
            recurringJobManager.RemoveIfExists("NOT_JOB_1");
            
            recurringJobManager.AddOrUpdate(
                "NOT_JOB_1",
                () => _notificationJob.Execute(),
                    Cron.Daily(hourNotificationJob, minuteNotificationJob)
                );
        }
    }
}
