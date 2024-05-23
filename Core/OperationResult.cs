using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// used to get CRUD function's Status
    /// </summary>
    public class OperationResult
    {
        public int Status {  get; set; }
        public string Message { get; set; }
        public object ObjectValue { get; set; }
        public OperationResult(int status, string message, object objectValue = null) {
            Status = status;
            Message = message;
            ObjectValue = objectValue;
        }
    }

    public enum OperationStatus
    {
        Success =1, Failure =2
    }
}
