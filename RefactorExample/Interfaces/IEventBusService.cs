using RefactorExample.Common;
using System;

namespace RefactorExample.Interfaces
{
    public interface IEventBusService
    {
        void RegisterForNotification(GeneralService generalService, EventTypes exception, Action<Exception> handleException);
        void UnRegisterForNotification(GeneralService generalService);
    }
}
