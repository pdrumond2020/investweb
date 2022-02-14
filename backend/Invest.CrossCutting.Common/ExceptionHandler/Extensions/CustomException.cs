using Invest.CrossCutting.Common.ExceptionHandler.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Invest.CrossCutting.Common.ExceptionHandler.Extensions
{
    [Serializable]
    public class CustomException : Exception
    {
        public IEnumerable<ItemValidationFailedViewModel> Errors { get; set; }

        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CustomException(IEnumerable<ItemValidationFailedViewModel> errors)
        {
            Errors = errors;
        }

        public CustomException(string message, IEnumerable<ItemValidationFailedViewModel> errors) : base(message)
        {
            Errors = errors;
        }

        public CustomException(string message, IEnumerable<ItemValidationFailedViewModel> errors, Exception exception) : base(message, exception)
        {
            Errors = errors;
        }
    }
}