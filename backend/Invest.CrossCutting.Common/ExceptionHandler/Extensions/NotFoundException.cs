using Invest.CrossCutting.Common.ExceptionHandler.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Invest.CrossCutting.Common.ExceptionHandler.Extensions
{
    [Serializable]
    public class NotFoundException : CustomException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(IEnumerable<ItemValidationFailedViewModel> errors) : base(errors)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotFoundException(string message, IEnumerable<ItemValidationFailedViewModel> errors) : base(message, errors)
        {
        }

        public NotFoundException(string message, IEnumerable<ItemValidationFailedViewModel> errors, Exception exception) : base(message, errors, exception)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}