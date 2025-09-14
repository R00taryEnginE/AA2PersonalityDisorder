using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA2PersonalityDisorder.Classes
{
    public class ValidationHelper
    {
        public class ValidationResult
        {
            public bool IsValid { get; }
            public string Message { get; }

            private ValidationResult(bool isValid, string message)
            {
                IsValid = isValid;
                Message = message;
            }

            public static ValidationResult Success() => new ValidationResult(true, "File is valid.");
            public static ValidationResult Fail(string message) => new ValidationResult(false, message);
        }

        public interface IFileValidator
        {
            string FileType { get; }
            ValidationResult Validate(string filePath);
        }
    }
}
