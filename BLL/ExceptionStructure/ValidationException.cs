
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ExceptionStructure
{
    public class CustomValidationException : Exception
    {
        public string Property { get; protected set; }
        public CustomValidationException(string message, string property) : base(message)
        {
            Property = property;
        }
    }
}
