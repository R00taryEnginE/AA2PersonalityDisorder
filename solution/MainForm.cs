using AA2PersonalityDisorder.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AA2PersonalityDisorder.Dialog02EditorPage;

namespace AA2PersonalityDisorder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Services.EventHub.Subscribe<StatusMessage>(msg =>
            {
                globalStatusLabel.Text = msg.Text;
            });
            
            dialog02EditorPage.BindContext(Services.EditorContext);
        }

        private void open02DialogButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "LST files (*.lst)|*.lst|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);

                    try
                    {
                        var validationResult = Services.FileValidation.ValidateFile(filePath, "02dialog");

                        if (!validationResult.IsValid)
                        {
                            Services.EventHub.Publish(new StatusMessage($"Failed to load file {fileName} due to validation errors!"));
                            MessageBox.Show($"File validation failed:\n{validationResult.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Services.EditorContext.Dialog02FilePath = filePath;
                        dialog02DataLabel.Text = "Loaded dialog data from " + fileName;
                        dialog02DataLabel.ForeColor = Color.Green;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error parsing file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            globalStatusLabel.Text = "Ready";
        }

        private void saveProjectButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult = folderBrowserDialog.ShowDialog();

                if (DialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // Check if project.json already exists
                    string projectFilePath = Path.Combine(folderBrowserDialog.SelectedPath, Constants.ProjectFileName);
                    if (File.Exists(projectFilePath))
                    {
                        var overwriteResult = MessageBox.Show("A project already exists in this directory. Do you want to overwrite it?", "Confirm Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (overwriteResult != DialogResult.Yes)
                        {
                            return;
                        }
                    }

                    try
                    {
                        ProjectHandler.SaveProject(folderBrowserDialog.SelectedPath);
                        Services.EditorContext.ProjectDirectory = folderBrowserDialog.SelectedPath;
                        Services.EventHub.Publish(new StatusMessage($"Project saved to {folderBrowserDialog.SelectedPath}"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void loadProjectButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the project directory containing the project.json file"; 
                DialogResult = folderBrowserDialog.ShowDialog();

                if (DialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    string projectFilePath = Path.Combine(folderBrowserDialog.SelectedPath, Constants.ProjectFileName);
                    if (!File.Exists(projectFilePath))
                    {
                        MessageBox.Show("No project found in the selected directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try
                    {
                        var project = ProjectHandler.LoadProject(folderBrowserDialog.SelectedPath);

                        // Apply loaded project to editor context
                        Services.EditorContext.ProjectDirectory = folderBrowserDialog.SelectedPath;

                        string dialog02Path;
                        if (project.Files != null && project.Files.TryGetValue("Dialog02", out dialog02Path) && !string.IsNullOrWhiteSpace(dialog02Path))
                        {
                            if (File.Exists(dialog02Path))
                            {
                                string dialog02FileName = Path.GetFileName(dialog02Path);
                                var validationResult = Services.FileValidation.ValidateFile(dialog02Path, "02dialog");

                                if (!validationResult.IsValid)
                                {
                                    Services.EventHub.Publish(new StatusMessage($"Failed to load file {dialog02FileName} due to validation errors!"));
                                    MessageBox.Show($"File validation failed:\n{validationResult.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                Services.EditorContext.Dialog02FilePath = dialog02Path;
                                dialog02DataLabel.Text = "Loaded dialog data from " + dialog02FileName;
                                dialog02DataLabel.ForeColor = Color.Green;
                            }
                            else
                            {
                                MessageBox.Show($"Dialog file referenced by project was not found: {dialog02Path}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Services.EditorContext.Dialog02FilePath = null;
                                dialog02DataLabel.Text = "No data loaded";
                                dialog02DataLabel.ForeColor = Color.Black;
                            }
                        }

                        string audioDirPath;
                        if (project.Files != null && project.Files.TryGetValue("DialogAudioPath", out audioDirPath) && !string.IsNullOrWhiteSpace(audioDirPath))
                        {
                            if (!Directory.Exists(audioDirPath))
                            {
                                MessageBox.Show($"Audio directory referenced by project was not found: {audioDirPath}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            Services.EditorContext.AudioDirectoryPath = audioDirPath;
                            audioDirTextbox.Text = audioDirPath;

                            // TODO: Load audio files if found
                        }

                        Services.EventHub.Publish(new StatusMessage($"Project loaded from {folderBrowserDialog.SelectedPath}"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void setAudioDirButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult = folderBrowserDialog.ShowDialog();
                if (DialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    if (Directory.Exists(folderBrowserDialog.SelectedPath))
                    {
                        Services.EditorContext.AudioDirectoryPath = folderBrowserDialog.SelectedPath;
                        audioDirTextbox.Text = folderBrowserDialog.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show("Selected directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
