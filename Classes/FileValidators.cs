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

                if (lines.Length < 542)
                    return ValidationResult.Fail("Dialog file has too few lines.");

                foreach (var line in lines)
                {
                    var parts = line.Split('\t');
                    if (parts.Length != 54)
                        return ValidationResult.Fail($"Line has {parts.Length} parameters, expected 54.");

                    int groupCount = parts.Length / 18;
                    if (groupCount != 3)
                        return ValidationResult.Fail($"Expected 3 dialog groups per line, but got {groupCount}.");
                }

                return ValidationResult.Success();
            }
        }
    }
}
