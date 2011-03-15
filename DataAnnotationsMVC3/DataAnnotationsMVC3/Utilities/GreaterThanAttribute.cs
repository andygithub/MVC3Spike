using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataAnnotationsMVC3.Utilities
{
    public class GreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        public GreaterThanAttribute(string otherProperty)
        {
            ErrorMessage = "{0} must be greater than {1}.";
            OtherProperty = otherProperty;
        }

        public string OtherProperty { get; private set; }

        string FormatErrorMessage(string thisPropertyDisplayName, string otherPropertyDisplayName)
        {
            return String.Format(ErrorMessageString, thisPropertyDisplayName, otherPropertyDisplayName);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var otherPropertyMetadata = ModelMetadataProviders.Current.GetMetadataForProperty(null, metadata.ContainerType, OtherProperty);

            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(
                    metadata.GetDisplayName(),
                    otherPropertyMetadata.GetDisplayName()
                ),
                ValidationType = "greater",
            };

            rule.ValidationParameters["other"] = "*." + OtherProperty;

            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(this.OtherProperty);
            //Type _type = validationContext.ObjectType.GetProperty(this.OtherProperty).GetType();
            var otherValue = (int)otherProperty.GetValue(validationContext.ObjectInstance, null);
            var thisValue = (int)value;

            if (thisValue > otherValue)
                return null;

            var otherPropertyMetadata = ModelMetadataProviders.Current.GetMetadataForProperty(() => validationContext.ObjectInstance, validationContext.ObjectType, OtherProperty);

            return new ValidationResult(
                FormatErrorMessage(
                    validationContext.DisplayName,
                    otherPropertyMetadata.GetDisplayName()
                )
            );
        }
    }
}