using RefactorExample.Common;
using RefactorExample.Interfaces;
using System;

namespace RefactorExample
{
    public class EventBusService : IEventBusService
    {
        public void RegisterForNotification(GeneralService generalService, EventTypes exception, Action<Exception> handleException)
        {
            throw new NotImplementedException();
        }

        public void UnRegisterForNotification(GeneralService generalService)
        {
            throw new NotImplementedException();
        }
    }
}
