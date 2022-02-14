using Invest.CrossCutting.Common.ExceptionHandler.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Invest.CrossCutting.Common.ExceptionHandler.Extensions
{
    [Serializable]
    public class NotAuthorizedException : CustomException
    {
        public NotAuthorizedException()
        {
        }

        public NotAuthorizedException(string message) : base(message)
        {
        }

        public NotAuthorizedException(IEnumerable<ItemValidationFailedViewModel> errors) : base(errors)
        {
        }

        public NotAuthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotAuthorizedException(string message, IEnumerable<ItemValidationFailedViewModel> errors) : base(message, errors)
        {
        }

        public NotAuthorizedException(string message, IEnumerable<ItemValidationFailedViewModel> errors, Exception exception) : base(message, errors, exception)
        {
        }

        protected NotAuthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}