using System;
using System.Diagnostics;
using RefactorExample.Common;
using RefactorExample.Interfaces;

namespace RefactorExample
{
    public class GeneralService : IDisposable
    {
        private readonly ILoggingService _loggingService;
        private readonly IDataService _dataService;
        private readonly IEventBusService _eventBusService;

        public GeneralService(ILoggingService loggingService, IDataService dataService, IEventBusService eventBusService)
        {
            _loggingService = loggingService;
            _dataService = dataService;
            _eventBusService = eventBusService;

            _eventBusService.RegisterForNotification(this, EventTypes.Exception, HandleException);
        }

        public void Dispose()
        {
            _eventBusService.UnRegisterForNotification(this);
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
