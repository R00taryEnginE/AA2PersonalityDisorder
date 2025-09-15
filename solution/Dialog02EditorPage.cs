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

namespace AA2PersonalityDisorder
{
    public partial class Dialog02EditorPage : UserControl
    {
        private List<DialogConditionListItem> dialogConditionsList;
        private List<DialogConditionListItem> filteredDialogConditionsList;
        private List<Dialog02Line> loadedDialogLines;
        private Dictionary<int, List<string>> dialogTextDict;

        private Color EditTrackingColor = Color.LightYellow;
        private BindingSource _dialogGroupsBindingSource = new BindingSource();

        public Dialog02EditorPage()
        {
            InitializeComponent();
        }

        // Expose loaded dialog lines for external use
        public List<Dialog02Line> LoadedDialogLines => loadedDialogLines;

        // Contenxt binding for data
        public void BindContext(EditorContext context)
        {
            context.PropertyChanged += (s, e) =>
            {
                // Load dialog file
                if (e.PropertyName == nameof(EditorContext.Dialog02FilePath))
                {
                    string filePath = context.Dialog02FilePath;
                    if (File.Exists(filePath))
                    {
                        string fileName = Path.GetFileName(filePath);

                        loadedDialogLines = null;
                        dialogConditionsList = null;

                        try
                        {
                            loadedDialogLines = new DialogParser().Parse02DialogFile(filePath);

                            if (loadedDialogLines.Count > 0 && loadedDialogLines != null)
                            {
                                // Load conditions list
                                string conditionsFilePath = Path.Combine(Environment.CurrentDirectory, "data/02DialogConditions.txt");
                                string[] conditions = File.ReadAllLines(conditionsFilePath);
                                dialogConditionsList = new List<DialogConditionListItem>();

                                if (conditions.Length != loadedDialogLines.Count)
                                {
                                    if (loadedDialogLines.Count < conditions.Length)
                                    {
                                        // Add default entries for missing dialog lines
                                        int diff = conditions.Length - loadedDialogLines.Count;
                                        for (int i = 0; i < diff; i++)
                                        {
                                            loadedDialogLines.Add(new Dialog02Line());
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Warning: The conditions file has fewer entries ({conditions.Length}) than the dialog lines ({loadedDialogLines.Count}). Some dialog lines will not have associated conditions.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }

                                for (int i = 0; i < conditions.Length; i++)
                                {
                                    var item = new DialogConditionListItem
                                    {
                                        ItemId = i,
                                        DisplayText = conditions[i].Trim(),
                                        Line = loadedDialogLines[i]
                                    };

                                    item.BindToLine();
                                    dialogConditionsList.Add(item);
                                }

                                // Set as data source
                                dialogConditionsGridView.DataSource = new BindingList<DialogConditionListItem>(dialogConditionsList);

                                // Reset dirty tracking to consider loaded values as original,
                                // then re-apply import dirty flags so missing/invalid fields stay highlighted.
                                foreach (var line in loadedDialogLines)
                                {
                                    foreach (var group in line.Groups)
                                    {
                                        bool hasImportIssues = group.ImportDirtyProperties != null && group.ImportDirtyProperties.Any();
                                        group.AcceptChanges();
                                        if (hasImportIssues)
                                        {
                                            group.ReapplyImportDirty();
                                        }
                                    }
                                }

                                // Add loaded lines to context for external access
                                context.LoadedDialog02Lines = loadedDialogLines;
                            }

                            Services.EventHub.Publish(new StatusMessage($"Loaded {fileName} with {loadedDialogLines.Count} dialog lines."));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error parsing file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };
        }

        public class DialogConditionListItem : INotifyPropertyChanged
        {
            public int ItemId { get; set; }
            public string DisplayText { get; set; }

            // Direct link to the corresponding data
            [Browsable(false)]
            public Dialog02Line Line { get; set; }

            [Browsable(false)]
            public bool IsDirty => Line?.IsDirty ?? false;

            public override string ToString() => DisplayText;

            public event PropertyChangedEventHandler PropertyChanged;

            internal void BindToLine()
            {
                if (Line != null)
                {
                    Line.PropertyChanged += (s, e) =>
                    {
                        if (e.PropertyName == nameof(Dialog02Line.IsDirty))
                            OnPropertyChanged(nameof(IsDirty));
                    };
                }
            }

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void exportDialogLstFileButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "List Files (*.lst)|*.lst|All Files (*.*)|*.*";
                saveFileDialog.Title = "Export Dialog .lst File";
                saveFileDialog.FileName = "dialog02.lst";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string exportPath = saveFileDialog.FileName;
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(exportPath, false, Encoding.GetEncoding("shift_jis")))
                        {
                            foreach (var line in loadedDialogLines)
                            {
                                var parts = new List<string>();
                                foreach (var group in line.Groups)
                                {
                                    parts.Add(group.AudioFile ?? "0");
                                    parts.Add(group.DialogText ?? "-1");
                                    parts.Add(group.CameraAngle.ToString());
                                    parts.Add(group.Pose.ToString());
                                    parts.Add(group.GazeDirection.ToString());
                                    parts.Add(group.EyebrowState.ToString());
                                    parts.Add(group.EyeState.ToString());
                                    parts.Add(group.EyeOpenState.ToString());
                                    parts.Add(group.PupilState ? "1" : "0");
                                    parts.Add(group.MouthState.ToString());
                                    parts.Add(group.MaxMouthWidth.ToString());
                                    parts.Add(group.MinMouthWidth.ToString());
                                    parts.Add(group.MaxMouthHeight.ToString());
                                    parts.Add(group.MinMouthHeight.ToString());
                                    parts.Add(group.BlushLineState.ToString());
                                    parts.Add(group.BlushState.ToString());
                                    parts.Add(group.TearsState.ToString());
                                    parts.Add(group.EyeHighlight ? "1" : "0");
                                }
                                string lineText = string.Join("\t", parts);
                                writer.WriteLine(lineText);
                            }
                        }
                        Services.EventHub.Publish(new StatusMessage($"Exported dialog to {exportPath}"));
                        MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExtractDialogTexts()
        {
            dialogTextDict = new Dictionary<int, List<string>>();
            for (int i = 0; i < loadedDialogLines.Count; i++)
            {
                var texts = loadedDialogLines[i].Groups
                    .Select(g => g.DialogText)
                    .Where(t => !string.IsNullOrWhiteSpace(t) && t != "0" && t != "-1")
                    .ToList();
                dialogTextDict[i] = texts;
            }
        }

        // Search by dialog text
        private void dialogSearchButton_Click(object sender, EventArgs e)
        {
            string searchText = dialogSearchInput.Text.Trim();

            if (loadedDialogLines == null || loadedDialogLines.Count == 0)
            {
                MessageBox.Show("No dialog loaded. Please open a .lst file first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(searchText))
            {
                dialogConditionsGridView.DataSource = dialogConditionsList;
                filteredDialogConditionsList = null;
                dialogConditionsGridView.Refresh();
                return;
            }

            ExtractDialogTexts();

            var foundIndices = dialogTextDict.Where(kvp => kvp.Value.Any(t => t.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0))
                .Select(kvp => kvp.Key)
                .ToList();

            filteredDialogConditionsList = dialogConditionsList.Where(item => foundIndices.Contains(item.ItemId)).ToList();
            dialogConditionsGridView.DataSource = filteredDialogConditionsList;
        }

        private void dialogGroupsGridView_SelectionChanged(object sender, EventArgs e)
        {
            Dialog02Group selectedGroup = dialogGroupsGridView.CurrentRow?.DataBoundItem as Dialog02Group;

            dialogGroupPropertyGrid.SelectedObject = selectedGroup;

            if (!string.IsNullOrEmpty(Services.EditorContext.AudioDirectoryPath))
            {
                var currentAudioFile = selectedGroup?.AudioFile;
                if (currentAudioFile != null || currentAudioFile != "0" || currentAudioFile != "-1")
                {
                    // Check if audio file exists
                    bool audioFileFound = false;
                    string audioDir = Services.EditorContext.AudioDirectoryPath;
                    string audioFileName = Path.GetFileNameWithoutExtension(currentAudioFile);

                    string wavPath = Path.Combine(audioDir, audioFileName + ".wav");
                    string opusPath = Path.Combine(audioDir, audioFileName + ".opus");
                    if (File.Exists(wavPath))
                    {
                        audioFileFound = true;
                        label1.Text = $"Audio file found: {audioFileName}.wav";
                        label1.ForeColor = Color.Green;
                        audioPlayButton.Tag = wavPath;
                    }
                    else if (File.Exists(opusPath))
                    {
                        audioFileFound = true;
                        label1.Text = $"Audio file found: {audioFileName}.opus";
                        label1.ForeColor = Color.Green;
                        audioPlayButton.Tag = opusPath;
                    }

                    if (audioFileFound)
                    {
                        audioPreviewGroupBox.Enabled = true;
                    }
                    else
                    {
                        label1.Text = $"Audio file not found: {currentAudioFile}";
                        label1.ForeColor = Color.Red;
                        audioPreviewGroupBox.Enabled = false;
                    }
                }
            }
            else
            {
                audioPreviewGroupBox.Enabled = false;
                label1.Text = "Set audio directory to enable preview";
                label1.ForeColor = Color.Gray;
            }
        }

        // Disable sorting
        private void dialogGroupsGridView_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dialogGroupsGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dialogGroupsGridView.Rows[e.RowIndex].DataBoundItem is Dialog02Group group)
            {
                var columnName = dialogGroupsGridView.Columns[e.ColumnIndex].DataPropertyName;

                if (group.DirtyProperties.Contains(columnName))
                {
                    e.CellStyle.BackColor = EditTrackingColor;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }
            }
        }

        private void dialogConditionsGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dialogConditionsGridView.Rows[e.RowIndex].DataBoundItem is DialogConditionListItem item)
            {
                bool dirty = item.IsDirty;
                e.CellStyle.BackColor = dirty ? EditTrackingColor : Color.White;
            }
        }

        private void dialogConditionsGridView_SelectionChanged(object sender, EventArgs e)
        {
            var currentItem = dialogConditionsGridView.CurrentRow?.DataBoundItem as DialogConditionListItem;

            if (currentItem != null)
            {
                _dialogGroupsBindingSource.DataSource = currentItem.Line.Groups;
                dialogGroupsGridView.DataSource = _dialogGroupsBindingSource;
                dialog02Textbox.DataBindings.Clear();
                dialog02Textbox.DataBindings.Add("Text", _dialogGroupsBindingSource, "DialogText", false, DataSourceUpdateMode.OnPropertyChanged);

                if (dialogGroupsGridView.Rows.Count > 0)
                {
                    dialogGroupsGridView.Rows[0].Selected = true;
                }
            }
        }

        private void dialogSearchInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dialogSearchButton.PerformClick();
                e.Handled = true; // Prevent the 'ding' sound
            }
        }

        private void audioPlayButton_Click(object sender, EventArgs e)
        {
            var selfButton = sender as Button;

            if (selfButton.Tag == null || string.IsNullOrEmpty(selfButton.Tag.ToString()))
            {
                return;
            }

            MessageBox.Show(selfButton.Tag.ToString());
        }
    }
}
