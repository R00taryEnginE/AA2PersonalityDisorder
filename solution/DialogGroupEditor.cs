using AA2PersonalityDisorder.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AA2PersonalityDisorder
{
    public partial class DialogGroupEditor : UserControl
    {
        [Description("Text for the group box"), Category("Appearance")]
        public string GroupText
        {
            get => dialogGroupBox.Text;
            set => dialogGroupBox.Text = value;
        }

        private Dialog02Group originalData;
        private Dialog02Group currentData;

        public event EventHandler<DialogGroupChangedEventArgs> DialogGroupChanged;

        public Dialog02Group CurrentData
        {
            get => currentData;
            set
            {
                currentData = value;
            }
        }

        private void RaisePropertyChanged(string propertyName, object oldValue, object newValue)
        { 
            DialogGroupChanged?.Invoke(this, new DialogGroupChangedEventArgs(propertyName, oldValue, newValue));
            UpdatePropertyLabel(propertyName);
        }

        private void UpdatePropertyLabel(string propertyName)
        {
            // Get the label control for this property
            var labelName = propertyName + "Label";
            var label = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
            if (label != null)
            {
                // Compare with original value to determine color
                var originalValue = typeof(Dialog02Group).GetProperty(propertyName).GetValue(originalData);
                var currentValue = typeof(Dialog02Group).GetProperty(propertyName).GetValue(currentData);

                label.ForeColor = !originalValue.Equals(currentValue) ? Color.Red : SystemColors.ControlText;
            }
        }

        public string AudioFile
        {
            get { return audioFileTextbox.Text; }
            set { audioFileTextbox.Text = value; }
        }

        public string DialogText
        {
            get { return dialogTextbox.Text; }
            set { dialogTextbox.Text = value; }
        }

        public int CameraAngle
        {
            get { return (int)cameraAngleInput.Value; }
            set { cameraAngleInput.Value = value; }
        }

        public int Pose
        {
            get { return (int)poseInput.Value; }
            set { poseInput.Value = value; }
        }

        public int GazeDirection
        {
            get { return (int)gazeDirectionInput.Value; }
            set { gazeDirectionInput.Value = value; }
        }

        public int EyebrowState
        {
            get { return (int)eyebrowStateInput.Value; }
            set { eyebrowStateInput.Value = value; }
        }

        public int EyeState
        {
            get { return (int)eyesStateInput.Value; }
            set { eyesStateInput.Value = value; }
        }

        public int EyeOpenState
        {
            get { return (int)eyesOpenStateInput.Value; }
            set { eyesOpenStateInput.Value = value; }
        }

        public int PupilState
        {
            get { return (int)pupilStateInput.Value; }
            set { pupilStateInput.Value = value; }
        }

        public int MouthState
        {
            get { return (int)mouthStateInput.Value; }
            set { mouthStateInput.Value = value; }
        }

        public int BlushLineState
        {
            get { return (int)blushLineStateInput.Value; }
            set { blushLineStateInput.Value = value; }
        }

        public int BlushState
        {
            get { return (int)blushStateInput.Value; }
            set { blushStateInput.Value = value; }
        }

        public int TearsState
        {
            get { return (int)tearsInput.Value; }
            set { tearsInput.Value = value; }
        }

        public int EyeHighlight
        {
            get { return (int)eyeHighlightInput.Value; }
            set { eyeHighlightInput.Value = value; }
        }

        public float MaxMouthWidth
        {
            get { return (float)maxMouthWidthInput.Value; }
            set { maxMouthWidthInput.Value = (decimal)value; }
        }

        public float MinMouthWidth
        {
            get { return (float)minMouthWidthInput.Value; }
            set { minMouthWidthInput.Value = (decimal)value; }
        }

        public float MaxMouthHeight
        {
            get { return (float)maxMouthHeightInput.Value; }
            set { maxMouthHeightInput.Value = (decimal)value; }
        }

        public float MinMouthHeight
        {
            get { return (float)minMouthHeightInput.Value; }
            set { minMouthHeightInput.Value = (decimal)value; }
        }

        public void LoadDialogData(Dialog02Group origData, Dialog02Group newData)
        {
            originalData = origData;

            currentData = newData;

            audioFileTextbox.Text = newData.AudioFile;
            dialogTextbox.Text = newData.DialogText;
            cameraAngleInput.Value = newData.CameraAngle;
            poseInput.Value = newData.Pose;
            gazeDirectionInput.Value = newData.GazeDirection;
            eyebrowStateInput.Value = newData.EyebrowState;
            eyesStateInput.Value = newData.EyeState;
            eyesOpenStateInput.Value = newData.EyeOpenState;
            pupilStateInput.Value = newData.PupilState ? 1 : 0;
            mouthStateInput.Value = newData.MouthState;
            blushLineStateInput.Value = newData.BlushLineState;
            blushStateInput.Value = newData.BlushState;
            tearsInput.Value = newData.TearsState;
            eyeHighlightInput.Value = newData.EyeHighlight ? 1 : 0;
            maxMouthWidthInput.Value = (decimal)newData.MaxMouthWidth;
            minMouthWidthInput.Value = (decimal)newData.MinMouthWidth;
            maxMouthHeightInput.Value = (decimal)newData.MaxMouthHeight;
            minMouthHeightInput.Value = (decimal)newData.MinMouthHeight;
        }

        public void ClearData()
        {
            audioFileTextbox.Text = "";
            dialogTextbox.Text = "";
            cameraAngleInput.Value = 0;
            poseInput.Value = 0;
            gazeDirectionInput.Value = 0;
            eyebrowStateInput.Value = 0;
            eyesStateInput.Value = 0;
            eyesOpenStateInput.Value = 0;
            pupilStateInput.Value = 0;
            mouthStateInput.Value = 0;
            blushLineStateInput.Value = 0;
            blushStateInput.Value = 0;
            tearsInput.Value = 0;
            eyeHighlightInput.Value = 0;
            maxMouthWidthInput.Value = 0;
            minMouthWidthInput.Value = 0;
            maxMouthHeightInput.Value = 0;
            minMouthHeightInput.Value = 0;

            originalData = new Dialog02Group();
            currentData = new Dialog02Group();

            this.Enabled = false;
        }

        // Method isDirty to check if currentData differs from originalData
        public bool IsDirty()
        {
            return !originalData.AudioFile.Equals(currentData.AudioFile) ||
                   !originalData.DialogText.Equals(currentData.DialogText) ||
                   originalData.CameraAngle != currentData.CameraAngle ||
                   originalData.Pose != currentData.Pose ||
                   originalData.GazeDirection != currentData.GazeDirection ||
                   originalData.EyebrowState != currentData.EyebrowState ||
                   originalData.EyeState != currentData.EyeState ||
                   originalData.EyeOpenState != currentData.EyeOpenState ||
                   originalData.PupilState != currentData.PupilState ||
                   originalData.MouthState != currentData.MouthState ||
                   Math.Abs(originalData.MaxMouthWidth - currentData.MaxMouthWidth) > 0.001 ||
                   Math.Abs(originalData.MinMouthWidth - currentData.MinMouthWidth) > 0.001 ||
                   Math.Abs(originalData.MaxMouthHeight - currentData.MaxMouthHeight) > 0.001 ||
                   Math.Abs(originalData.MinMouthHeight - currentData.MinMouthHeight) > 0.001 ||
                   originalData.BlushLineState != currentData.BlushLineState ||
                   originalData.BlushState != currentData.BlushState ||
                   originalData.TearsState != currentData.TearsState ||
                   originalData.EyeHighlight != currentData.EyeHighlight;
        }

        public DialogGroupEditor()
        {
            InitializeComponent();
        }

        private void audioFileTextbox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.AudioFile;
            currentData.AudioFile = audioFileTextbox.Text;
            RaisePropertyChanged(nameof(AudioFile), oldValue, currentData.AudioFile);
        }

        private void dialogTextbox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.DialogText;
            currentData.DialogText = dialogTextbox.Text;
            RaisePropertyChanged(nameof(DialogText), oldValue, currentData.DialogText);
        }

        private void eyesStateInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.EyeState;
            currentData.EyeState = (int)eyesStateInput.Value;
            RaisePropertyChanged(nameof(EyeState), oldValue, currentData.EyeState);
        }

        private void cameraAngleInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.CameraAngle;
            currentData.CameraAngle = (int)cameraAngleInput.Value;
            RaisePropertyChanged(nameof(CameraAngle), oldValue, currentData.CameraAngle);
        }

        private void poseInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.Pose;
            currentData.Pose = (int)poseInput.Value;
            RaisePropertyChanged(nameof(Pose), oldValue, currentData.Pose);
        }

        private void gazeDirectionInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.GazeDirection;
            currentData.GazeDirection = (int)gazeDirectionInput.Value;
            RaisePropertyChanged(nameof(GazeDirection), oldValue, currentData.GazeDirection);
        }

        private void eyebrowStateInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.EyebrowState;
            currentData.EyebrowState = (int)eyebrowStateInput.Value;
            RaisePropertyChanged(nameof(EyebrowState), oldValue, currentData.EyebrowState);
        }

        private void eyesOpenStateInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.EyeOpenState;
            currentData.EyeOpenState = (int)eyesOpenStateInput.Value;
            RaisePropertyChanged(nameof(EyeOpenState), oldValue, currentData.EyeOpenState);
        }

        private void pupilStateInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.PupilState;
            currentData.PupilState = pupilStateInput.Value == 1;
            RaisePropertyChanged(nameof(PupilState), oldValue, currentData.PupilState);
        }

        private void mouthStateInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.MouthState;
            currentData.MouthState = (int)mouthStateInput.Value;
            RaisePropertyChanged(nameof(MouthState), oldValue, currentData.MouthState);
        }

        private void maxMouthWidthInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.MaxMouthWidth;
            currentData.MaxMouthWidth = (float)maxMouthWidthInput.Value;
            RaisePropertyChanged(nameof(MaxMouthWidth), oldValue, currentData.MaxMouthWidth);
        }

        private void minMouthWidthInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.MinMouthWidth;
            currentData.MinMouthWidth = (float)minMouthWidthInput.Value;
            RaisePropertyChanged(nameof(MinMouthWidth), oldValue, currentData.MinMouthWidth);
        }

        private void maxMouthHeightInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.MaxMouthHeight;
            currentData.MaxMouthHeight = (float)maxMouthHeightInput.Value;
            RaisePropertyChanged(nameof(MaxMouthHeight), oldValue, currentData.MaxMouthHeight);
        }

        private void minMouthHeightInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.MinMouthHeight;
            currentData.MinMouthHeight = (float)minMouthHeightInput.Value;
            RaisePropertyChanged(nameof(MinMouthHeight), oldValue, currentData.MinMouthHeight);
        }

        private void blushLineStateInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.BlushLineState;
            currentData.BlushLineState = (int)blushLineStateInput.Value;
            RaisePropertyChanged(nameof(BlushLineState), oldValue, currentData.BlushLineState);
        }

        private void blushStateInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.BlushState;
            currentData.BlushState = (int)blushStateInput.Value;
            RaisePropertyChanged(nameof(BlushState), oldValue, currentData.BlushState);
        }

        private void tearsInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.TearsState;
            currentData.TearsState = (int)tearsInput.Value;
            RaisePropertyChanged(nameof(TearsState), oldValue, currentData.TearsState);
        }

        private void eyeHighlightInput_ValueChanged(object sender, EventArgs e)
        {
            var oldValue = currentData.EyeHighlight;
            currentData.EyeHighlight = eyeHighlightInput.Value == 1;
            RaisePropertyChanged(nameof(EyeHighlight), oldValue, currentData.EyeHighlight);
        }
    }

    public class DialogGroupChangedEventArgs : EventArgs
    {
        public string PropertyName { get; }
        public object OldValue { get; }
        public object NewValue { get; }

        public DialogGroupChangedEventArgs(string propertyName, object oldValue, object newValue)
        {
            PropertyName = propertyName;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
