using System;
using System.Collections.Generic;
using System.Text;

namespace ARQ_App.ExceptionManager
{
    public class OperationValidationException: Exception
    {
        public Dictionary<string, string> StackMsg { get; } = new Dictionary<string, string>();

        public void Add(string key, string msg) => StackMsg.Add(key, msg);
        public OperationValidationException()
        {
        }
      
        public OperationValidationException(int id, string msg)
        {
            StackMsg.Add($"{id})", msg);
        }
    }
}
