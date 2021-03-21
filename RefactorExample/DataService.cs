using RefactorExample.Interfaces;
using System;

namespace RefactorExample
{
    public class DataService : IDataService
    {
        public void CreateLog(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void CreateLog(string messages)
        {
            throw new NotImplementedException();
        }
    }
}
