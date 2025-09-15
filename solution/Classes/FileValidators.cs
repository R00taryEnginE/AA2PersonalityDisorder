using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AA2PersonalityDisorder.Classes.ValidationHelper;

namespace AA2PersonalityDisorder.Classes
{
    public class FileValidators
    {
        public class Dialog02FileValidator : IFileValidator
        {
            public string FileType => "02dialog";

            public ValidationResult Validate(string filePath)
            {
                if (!File.Exists(filePath))
                    return ValidationResult.Fail("File does not exist.");

                var lines = File.ReadAllLines(filePath);
                if (lines.Length == 0)
                    return ValidationResult.Fail("File is empty.");

                // Make validation permissive: the parser now handles short/invalid lines and flags them.
                // We still succeed here so the file can be loaded.
                return ValidationResult.Success();
            }
        }
    }
}
