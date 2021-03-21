using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using RefactorExample.Interfaces;

namespace RefactorExample
{
    public class GeneralService : IDisposable
    {
        private readonly ILoggingService _loggingService;
        private readonly DataService _dataService;
        private readonly IServiceProvider _serviceProvider;

        public GeneralService(ILoggingService loggingService, DataService dataService, IServiceProvider serviceProvider)
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
            Stopwatch watch = new Stopwatch();
            watch.Start();
            _loggingService.LogInformation("Start executing");

            try
            {
                action();
            }
            catch(Exception exception)
            {
                _loggingService.LogException(exception);
                return;
            }

            watch.Stop();

            _dataService.CreateLog($"{nameof(GeneralService)} - {nameof(Execute)}: {watch.ElapsedMilliseconds}");
        }

        private void HandleException(Exception exception)
        {
            _dataService.CreateLog(exception);

            _loggingService.LogInformation("Exception was logged");
        }
    }
}
