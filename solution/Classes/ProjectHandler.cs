using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace AA2PersonalityDisorder.Classes
{
    public static class ProjectHandler
    {
        public const string CurrentProjectVersion = "1.0";

        public class ProjectFile
        {
            // Schema version of the project file
            public string Version { get; set; }

            public Dictionary<string, string> Files { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        public static void SaveProject(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
                throw new ArgumentException("directory is required", nameof(directory));

            var context = Services.EditorContext;

            var project = new ProjectFile
            {
                Version = CurrentProjectVersion,
            };

            // Save Dialog02 absolute path and data
            if (!string.IsNullOrWhiteSpace(context.Dialog02FilePath))
            {
                project.Files["Dialog02"] = Path.GetFullPath(context.Dialog02FilePath);

                // Serialize current dialog data as binary
                var dialogData = context.LoadedDialog02Lines;
                if (dialogData != null && dialogData.Count > 0)
                {
                    var dialogDataFilePath = Path.Combine(directory, "dialog02_data.dat");
                    
                    MemoryStream ms = new MemoryStream();
                    using (BsonDataWriter writer = new BsonDataWriter(ms))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(writer, dialogData);
                    }

                    File.WriteAllBytes(dialogDataFilePath, ms.ToArray());

                    project.Metadata["Dialog02DataFile"] = "dialog02_data.dat";
                }
            }

            // Save audio directory path if set
            if (!string.IsNullOrWhiteSpace(context.AudioDirectoryPath))
            {
                project.Files["DialogAudioPath"] = Path.GetFullPath(context.AudioDirectoryPath);
            }

            var serializedData = JsonConvert.SerializeObject(project, Formatting.Indented);

            var projectFilePath = Path.Combine(directory, Constants.ProjectFileName);
            File.WriteAllText(projectFilePath, serializedData);
        }

        public static ProjectFile LoadProject(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
                throw new ArgumentException("directory is required", nameof(directory));

            var projectFilePath = Path.Combine(directory, Constants.ProjectFileName);
            if (!File.Exists(projectFilePath))
                throw new FileNotFoundException("Project file not found.", projectFilePath);

            var projectJson = File.ReadAllText(projectFilePath);
            var project = JsonConvert.DeserializeObject<ProjectFile>(projectJson) ?? new ProjectFile();

            // Ensure version is set (backwards compatibility)
            if (string.IsNullOrWhiteSpace(project.Version))
                project.Version = "0.0";

            // Normalize file paths: relative -> absolute (relative to project directory),
            // absolute paths are normalized with GetFullPath.
            if (project.Files != null && project.Files.Count > 0)
            {
                var keys = project.Files.Keys.ToList();
                foreach (var key in keys)
                {
                    var value = project.Files[key];
                    if (string.IsNullOrWhiteSpace(value))
                        continue;

                    string resolved;
                    if (Path.IsPathRooted(value))
                    {
                        resolved = Path.GetFullPath(value);
                    }
                    else
                    {
                        resolved = Path.GetFullPath(Path.Combine(directory, value));
                    }

                    project.Files[key] = resolved;
                }
            }

            // Ensure metadata dictionary exists
            if (project.Metadata == null)
                project.Metadata = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            return project;
        }
    }
}
