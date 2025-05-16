using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shared.Application.Validation
{
    public class AllowedContentTypesAttribute : ValidationAttribute
    {
        private readonly string[] _allowedTypes;

        public AllowedContentTypesAttribute(params string[] allowedTypes)
        {
            _allowedTypes = allowedTypes;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (!_allowedTypes.Contains(file.ContentType))
                {
                    return new ValidationResult($"File type {file.ContentType} is not allowed.");
                }
            }

            return ValidationResult.Success;
        }
    }

}
