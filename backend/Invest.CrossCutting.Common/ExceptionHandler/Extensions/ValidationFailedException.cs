using Invest.CrossCutting.Common.ExceptionHandler.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Invest.CrossCutting.Common.ExceptionHandler.Extensions
{
    [Serializable]
    public class ValidationFailedException : CustomException
    {
        public ValidationFailedException()
        {
        }

        public ValidationFailedException(string message) : base(message)
        {
        }

        public ValidationFailedException(IEnumerable<ItemValidationFailedViewModel> errors) : base(errors)
        {
        }

        public ValidationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ValidationFailedException(string message, IEnumerable<ItemValidationFailedViewModel> errors) : base(message, errors)
        {
        }

        public ValidationFailedException(string message, IEnumerable<ItemValidationFailedViewModel> errors, Exception exception) : base(message, errors, exception)
        {
        }

        protected ValidationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}