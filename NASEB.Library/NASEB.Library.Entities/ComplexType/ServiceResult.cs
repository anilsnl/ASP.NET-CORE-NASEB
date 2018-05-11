using System.Collections.Generic;

namespace NASEB.Entities.ComplexType
{
    public class ServiceResult
    {
        public bool isSuccess { get; set; }
        public List<string> Errors { get; set; }

        public ServiceResult()
        {
            Errors=new List<string>();
        }

        public ServiceResult(bool status)
        {
            isSuccess = status;
            Errors=new List<string>();
        }
    }
}