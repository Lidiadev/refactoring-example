using System;

namespace RefactorExample
{
    public class EventBusService
    {
        internal void RegisterForNotification(GeneralService generalService, EventTypes exception, Action<Exception> handleException)
        {
            throw new NotImplementedException();
        }

        internal void UnRegisterForNotification(GeneralService generalService)
        {
            throw new NotImplementedException();
        }
    }
}
