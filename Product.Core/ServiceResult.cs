using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Core
{
    public class ServiceResult
    {
        public interface IServiceResult<T> where T : class
        {
            List<string> Messages { get; set; }
            bool IsValid { get; set; }
           // ValidationStatus? Status { get; set; }
        }
        public class ServiceResultDetail<T> : IServiceResult<T> where T : class
        {
            public ServiceResultDetail()
            {
                IsValid = true;
                Messages = new List<string>();
            }
            public T Model { get; set; }
            public List<string> Messages { get; set; }
            public bool IsValid { get; set; }
            public long SubTotalCount { get; set; }
           // public ValidationStatus? Status { get; set; }
        }
        public class ServiceResultList<T> : IServiceResult<T> where T : class
        {
            public ServiceResultList()
            {
                IsValid = true;
                Messages = new List<string>();
            }
            public List<T> Model { get; set; }
            public List<string> Messages { get; set; }
            public bool IsValid { get; set; }
            public long Count { get; set; }
          //  public ValidationStatus? Status { get; set; }
        }
    }
}
