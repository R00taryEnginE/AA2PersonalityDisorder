using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AA2PersonalityDisorder.Classes
{
    public class DialogParser
    {
        public List<Dialog02Line> Parse02DialogFile(string filePath)
        {
            var entries = new List<Dialog02Line>();
            var lines = File.ReadAllLines(filePath, Encoding.GetEncoding("shift_jis"));
            foreach (var line in lines)
            {
                try 
                {
                    var parsedLines = Parse02Line(line);
                    entries.AddRange(parsedLines);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"Error parsing line: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            return entries;
        }

        public IEnumerable<Dialog02Line> Parse02Line(string line)
        {
            var parts = line.Split('\t');

            // Expecting exactly 54 parts for 3 groups of 18 attributes each
            if (parts.Length != 54)
                throw new FormatException($"Expected 54 parts in line, but got {parts.Length}.");

            int groupCount = parts.Length / 18;
            if (groupCount != 3)
                throw new FormatException($"Expected 3 dialog groups per line, but got {groupCount}.");

            var dialogLine = new Dialog02Line();

            for (int g = 0; g < 3; g++)
            {
                int baseIdx = g * 18;
                if (baseIdx + 18 > parts.Length)
                    break;

                var group = dialogLine.Groups[g];

                // AudioFile and DialogText
                group.AudioFile = parts[baseIdx];
                group.DialogText = parts[baseIdx + 1];

                // CameraAngle
                int.TryParse(parts[baseIdx + 2], out int cameraAngle);
                group.CameraAngle = cameraAngle;

                // Pose
                int.TryParse(parts[baseIdx + 3], out int pose);
                group.Pose = pose;

                // GazeDirection
                int.TryParse(parts[baseIdx + 4], out int gazeDirection);
                group.GazeDirection = gazeDirection;

                // EyebrowState
                int.TryParse(parts[baseIdx + 5], out int eyebrowState);
                group.EyebrowState = eyebrowState;

                // EyeState
                int.TryParse(parts[baseIdx + 6], out int eyeState);
                group.EyeState = eyeState;

                // EyeOpenState
                int.TryParse(parts[baseIdx + 7], out int eyeOpenState);
                group.EyeOpenState = eyeOpenState;

                // PupilState
               group.PupilState = parts[baseIdx + 8] == "1";

                // MouthState
                int.TryParse(parts[baseIdx + 9], out int mouthState);
                group.MouthState = mouthState;

                // MaxMouthWidth
                float.TryParse(parts[baseIdx + 10], out float MaxMouthWidth);
                group.MaxMouthWidth = MaxMouthWidth;

                // MinMouthWidth
                float.TryParse(parts[baseIdx + 11], out float MinMouthWidth);
                group.MinMouthWidth = MinMouthWidth;

                // MaxMouthHeight
                float.TryParse(parts[baseIdx + 12], out float MaxMouthHeight);
                group.MaxMouthHeight = MaxMouthHeight;

                // MinMouthHeight
                float.TryParse(parts[baseIdx + 13], out float MinMouthHeight);
                group.MinMouthHeight = MinMouthHeight;

                // BlushLineState
                int.TryParse(parts[baseIdx + 14], out int blushLineState);
                group.BlushLineState = blushLineState;

                // BlushState
                int.TryParse(parts[baseIdx + 15], out int blushState);
                group.BlushState = blushState;

                // TearsState
                int.TryParse(parts[baseIdx + 16], out int tearsState);
                group.TearsState = tearsState;

                // EyeHighlight
                group.EyeHighlight = parts[baseIdx + 17] == "1";
            }

            yield return dialogLine;
        }
    }
}
