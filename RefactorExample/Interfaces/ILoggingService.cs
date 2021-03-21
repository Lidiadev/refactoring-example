using System;

namespace RefactorExample.Interfaces
{
    public interface ILoggingService
    {
        void LogInformation(string message);
        void LogException(Exception exception);
    }
}
