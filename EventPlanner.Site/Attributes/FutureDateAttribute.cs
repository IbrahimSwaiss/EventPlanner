using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EventPlanner.Site.Attributes {
    public sealed class FutureDateAttribute : ValidationAttribute, IClientValidatable {
        //const string errorMessage = ;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var selectedDate = Convert.ToDateTime(value);

            return selectedDate > DateTime.Now
                ? ValidationResult.Success
                : new ValidationResult("Date should be in the future");
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context) {
            yield return new ModelClientValidationRule {
                ValidationType = "future",
                ErrorMessage = "Date should be in the future"
            };
        }
    }
}
