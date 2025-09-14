using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AA2PersonalityDisorder.Classes.FileValidators;
using static AA2PersonalityDisorder.Classes.ValidationHelper;

namespace AA2PersonalityDisorder.Classes
{
    public class FileValidationService
    {
        private readonly List<IFileValidator> _validators = new List<IFileValidator>();

        public FileValidationService()
        {
            // register all validators
            _validators.Add(new Dialog02FileValidator());
        }

        public ValidationResult ValidateFile(string filePath, string fileType)
        {
            var validator = _validators.FirstOrDefault(v => v.FileType == fileType);
            if (validator == null)
                return ValidationResult.Fail($"No validator registered for file type '{fileType}'.");

            return validator.Validate(filePath);
        }
    }

}
