using System;

namespace RefactorExample.Interfaces
{
    public interface IDataService
    {
        public void CreateLog(Exception exception);
        public void CreateLog(string messages);
    }
}
