using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace RefactorExample
{
    public class GeneralService : IDisposable
    {
        private readonly LoggingService _loggingService;
        private readonly DataService _dataService;
        private readonly IServiceProvider _serviceProvider;

        public GeneralService(LoggingService loggingService, DataService dataService, IServiceProvider serviceProvider)
        {
            _loggingService = loggingService;
            _dataService = dataService;
            _serviceProvider = serviceProvider;

            var eventBusService = _serviceProvider.GetService<EventBusService>();
            eventBusService.RegisterForNotification(this, EventTypes.Exception, HandleException);
        }

        public void Dispose()
        {
            var eventBusService = _serviceProvider.GetService<EventBusService>();
            eventBusService.UnRegisterForNotification(this);
        }

        public void Execute(Action action)
        {
            LoggingService loggingService = _serviceProvider.GetService<LoggingService>();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            loggingService.LogInformation("Start executing");

            try
            {
                action();
            }
            catch(Exception exception)
            {
                loggingService.LogException(exception);
                return;
            }

            watch.Stop();

            _dataService.CreateLog($"{nameof(GeneralService)} - {nameof(Execute)}: {watch.ElapsedMilliseconds}");
        }

        private void HandleException(Exception exception)
        {
            var loggingService = new LoggingService();
            _dataService.CreateLog(exception);

            loggingService.LogInformation("Exception was logged");
        }
    }
}
