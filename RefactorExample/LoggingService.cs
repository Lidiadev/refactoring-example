using RefactorExample.Interfaces;
using System;

namespace RefactorExample
{
    public class LoggingService : ILoggingService
    {
        public void LogInformation(string message)
        {
            throw new NotImplementedException();
        }

        public void LogException(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
