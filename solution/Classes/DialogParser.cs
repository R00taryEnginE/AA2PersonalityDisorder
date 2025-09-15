using System;
using System.Collections.Generic;
using System.Globalization;
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
                // Tolerant parsing: never throw for malformed lines
                var parsedLines = Parse02Line(line);
                entries.AddRange(parsedLines);
            }
            return entries;
        }

        public IEnumerable<Dialog02Line> Parse02Line(string line)
        {
            // Split but tolerate fewer/more parts; we only read up to 54 expected ones.
            var parts = string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split('\t');

            var dialogLine = new Dialog02Line();

            for (int g = 0; g < 3; g++)
            {
                int baseIdx = g * 18;
                var group = dialogLine.Groups[g];

                // AudioFile (string or "0")
                if (IsMissing(parts, baseIdx))
                {
                    group.AudioFile = "0";
                    group.FlagImportDirty(nameof(Dialog02Group.AudioFile));
                }
                else
                {
                    string audio = parts[baseIdx];
                    if (string.IsNullOrWhiteSpace(audio))
                    {
                        group.AudioFile = "0";
                        group.FlagImportDirty(nameof(Dialog02Group.AudioFile));
                    }
                    else
                    {
                        group.AudioFile = audio;
                    }
                }

                // DialogText ("-1", "0", or string)
                if (IsMissing(parts, baseIdx + 1))
                {
                    group.DialogText = "-1";
                    group.FlagImportDirty(nameof(Dialog02Group.DialogText));
                }
                else
                {
                    string txt = parts[baseIdx + 1];
                    if (string.IsNullOrWhiteSpace(txt))
                    {
                        group.DialogText = "-1";
                        group.FlagImportDirty(nameof(Dialog02Group.DialogText));
                    }
                    else
                    {
                        group.DialogText = txt;
                    }
                }

                // Ints
                group.CameraAngle    = ParseIntOrDefault(parts, baseIdx + 2,  0, group, nameof(Dialog02Group.CameraAngle));
                group.Pose           = ParseIntOrDefault(parts, baseIdx + 3,  0, group, nameof(Dialog02Group.Pose));
                group.GazeDirection  = ParseIntOrDefault(parts, baseIdx + 4,  0, group, nameof(Dialog02Group.GazeDirection));
                group.EyebrowState   = ParseIntOrDefault(parts, baseIdx + 5,  0, group, nameof(Dialog02Group.EyebrowState));
                group.EyeState       = ParseIntOrDefault(parts, baseIdx + 6,  0, group, nameof(Dialog02Group.EyeState));
                group.EyeOpenState   = ParseIntOrDefault(parts, baseIdx + 7,  0, group, nameof(Dialog02Group.EyeOpenState));

                // PupilState (bool: "0"/"1")
                group.PupilState     = ParseBool01(parts, baseIdx + 8, false, group, nameof(Dialog02Group.PupilState));

                // More ints
                group.MouthState     = ParseIntOrDefault(parts, baseIdx + 9,  0, group, nameof(Dialog02Group.MouthState));

                // Floats (use group defaults for Max values)
                group.MaxMouthWidth  = ParseFloatOrDefault(parts, baseIdx + 10, 1f, group, nameof(Dialog02Group.MaxMouthWidth));
                group.MinMouthWidth  = ParseFloatOrDefault(parts, baseIdx + 11, 0f, group, nameof(Dialog02Group.MinMouthWidth));
                group.MaxMouthHeight = ParseFloatOrDefault(parts, baseIdx + 12, 1f, group, nameof(Dialog02Group.MaxMouthHeight));
                group.MinMouthHeight = ParseFloatOrDefault(parts, baseIdx + 13, 0f, group, nameof(Dialog02Group.MinMouthHeight));

                // Ints
                group.BlushLineState = ParseIntOrDefault(parts, baseIdx + 14, 0, group, nameof(Dialog02Group.BlushLineState));
                group.BlushState     = ParseIntOrDefault(parts, baseIdx + 15, 0, group, nameof(Dialog02Group.BlushState));
                group.TearsState     = ParseIntOrDefault(parts, baseIdx + 16, 0, group, nameof(Dialog02Group.TearsState));

                // EyeHighlight (bool: "0"/"1")
                group.EyeHighlight   = ParseBool01(parts, baseIdx + 17, false, group, nameof(Dialog02Group.EyeHighlight));
            }

            yield return dialogLine;
        }

        private static bool IsMissing(string[] parts, int idx)
        {
            return idx >= parts.Length || parts[idx] == null;
        }

        private static int ParseIntOrDefault(string[] parts, int idx, int @default, Dialog02Group group, string propertyName)
        {
            if (idx >= parts.Length || string.IsNullOrWhiteSpace(parts[idx]))
            {
                group.FlagImportDirty(propertyName);
                return @default;
            }
            int v;
            if (!int.TryParse(parts[idx], out v))
            {
                group.FlagImportDirty(propertyName);
                return @default;
            }
            return v;
        }

        private static float ParseFloatOrDefault(string[] parts, int idx, float @default, Dialog02Group group, string propertyName)
        {
            if (idx >= parts.Length || string.IsNullOrWhiteSpace(parts[idx]))
            {
                group.FlagImportDirty(propertyName);
                return @default;
            }
            float v;
            if (!float.TryParse(parts[idx], NumberStyles.Float, CultureInfo.InvariantCulture, out v) &&
                !float.TryParse(parts[idx], out v)) // fallback to current culture
            {
                group.FlagImportDirty(propertyName);
                return @default;
            }
            return v;
        }

        private static bool ParseBool01(string[] parts, int idx, bool @default, Dialog02Group group, string propertyName)
        {
            if (idx >= parts.Length || string.IsNullOrWhiteSpace(parts[idx]))
            {
                group.FlagImportDirty(propertyName);
                return @default;
            }
            var s = parts[idx].Trim();
            if (s == "0") return false;
            if (s == "1") return true;

            group.FlagImportDirty(propertyName);
            return @default;
        }
    }
}
