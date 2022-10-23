using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Common;

namespace Udemy.AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError>ConvertToCustomValdiatonError(this ValidationResult validationResult) {
            List<CustomValidationError> errors = new();
            foreach (var item in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage=item.ErrorMessage,
                    PropertyName=item.PropertyName
                });

            }
            return errors;

        }
    }
}
