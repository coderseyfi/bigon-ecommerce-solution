using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BigOn.Domain.AppCode.Extensions
{
    public static partial class Extension
    {
        public static IEnumerable<ValidationError> GetErrors(this ModelStateDictionary modelState)
        {
            var error = (from key in modelState.Keys
                         where modelState[key] != null && modelState[key].Errors.Count > 0
                         select new ValidationError(key, modelState[key].Errors[0].ErrorMessage)
                         ).ToList();
            return error;
        }
    }

    public class ValidationError
    {
        public string FieldName { get; set; }
        public string Message { get; set; }

        public ValidationError(string fieldName, string message)
        {
            this.FieldName = fieldName;
            this.Message = message;
        }
    }
}
