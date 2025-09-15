using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AA2PersonalityDisorder.Classes
{
    /*
     * Questions:
     * - 542 conditions vs 562 lines in lst dialog, missing 20 from nodim, how to define those?
     * - What are all the files required for a personality? Where to find them?
     * - Save a diff of the changes made to the lst file?
     * - What are the unknown float values?
     * - Generate AAU subtitles?'
     * - Dialog vars, @ - some other card, * - location, # - PC item, $ - card's own item, \ - club
     * 
     * - camera angle - 0 - 13
     * - eyebrows - 0 - 6
     * - mouth shape - 0 - 19
     * - eyeopenstate - 0 - 9
     * - eye shape - 0 - 9
     * - gaze - 0 - 16
     * - blush - 0 - 5
     * - blush lines - 0 - 10
     * - tears - 0 - 3
     * - hightlight - 0 - 1
     * - pupil - 0 - 1
     * - pose - 0 - 999
     * 
     * 
     */

    public class Dialog02Group : TrackableDataBase
    {
        private string _audioFile = "0";
        private string _dialogText = "-1";
        private int _cameraAngle; // Values: 0 - 13
        private int _pose; // Values: 0 - 999
        private int _gazeDirection; // Values: 0 - 16
        private int _eyebrowState; // Values: 0 - 6
        private int _eyeState; // Values: 0 - 9
        private int _eyeOpenState; // Values: 0 - 9
        private bool _pupilState; // Values: 0 - 1
        private int _mouthState; // Values: 0 - 19
        private float _maxMouthWidth = 1f;
        private float _minMouthWidth;
        private float _maxMouthHeight = 1f;
        private float _minMouthHeight;
        private int _blushLineState; // Values: 0 - 10
        private int _blushState; // Values: 0 - 5
        private int _tearsState; // Values: 0 - 3 - 0 = none, 1 = tears, 2 = eye shimmer, 3 = tears + eye shimmer
        private bool _eyeHighlight = true; // Values: 0 - 1

        // Tracks which properties were marked dirty due to import (missing/invalid values)
        private readonly HashSet<string> _importDirty = new HashSet<string>(StringComparer.Ordinal);

        [Browsable(false)]
        public IEnumerable<string> ImportDirtyProperties => _importDirty;

        // Call during parsing to tag a property as import-dirty and reflect it in UI
        public void FlagImportDirty(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                return;

            _importDirty.Add(propertyName);
            MarkDirty(propertyName);
        }

        // After AcceptChanges on load, call this to re-apply import-dirty flags without changing values
        public void ReapplyImportDirty()
        {
            foreach (var p in _importDirty)
            {
                MarkDirty(p);
            }
        }

        [Description("Audio file name, relative to the personality's audio folder.\nA value of 0 means no audio")]
        [Category("01. General")]
        [DisplayName("Audio File")]
        public string AudioFile
        {
            get => _audioFile;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    value = "0"; // No audio

                // Remove any whitespace to avoid issues
                value = value.Replace(" ", "");

                SetProperty(ref _audioFile, value, nameof(AudioFile));
            }
        }

        [Description("Dialog text, shown in subtitles")]
        [Category("01. General")]
        [DisplayName("Dialog Text")]
        public string DialogText
        {
            get => _dialogText;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    value = "-1"; // No dialog

                // Turn new lines into space to avoid issues
                value = value.Replace("\r", " ").Replace("\n", " ");

                // Limit to 95 characters to avoid screen overflow
                if (value.Length > 95)
                    value = value.Substring(0, 95);

                SetProperty(ref _dialogText, value, nameof(DialogText));
            }
        }

        [Description("Camera angle for the dialog.\nValues: 0 - 13")]
        [Category("02. Posing")]
        [DisplayName("Camera Angle")]
        public int CameraAngle
        {
            get => _cameraAngle;
            set
            {
                if (value < 0 || value > 13)
                    value = 0; // Default to 0 if out of range

                SetProperty(ref _cameraAngle, value, nameof(CameraAngle));
            }
        }

        [Description("Pose for the dialog.\nValues: 0 - 999")]
        [Category("02. Posing")]
        [DisplayName("Pose")]
        public int Pose
        {
            get => _pose;
            set
            {
                if (value < 0 || value > 999)
                    value = 0; // Default to 0 (T-Pose) if out of range.

                SetProperty(ref _pose, value, nameof(Pose));
            }
        }

        [Description("Gaze direction for the dialog.\nValues: 0 - 16")]
        [Category("03. Facial Expression")]
        [DisplayName("Gaze Direction")]
        public int GazeDirection
        {
            get => _gazeDirection;
            set
            {
                if (value < 0 || value > 16)
                    value = 0; // Default to 0 if out of range

                SetProperty(ref _gazeDirection, value, nameof(GazeDirection));
            }
        }

        [Description("Eyebrow shape for the dialog.\nValues: 0 - 6")]
        [Category("03. Facial Expression")]
        [DisplayName("Eyebrow Shape")]
        public int EyebrowState
        {
            get => _eyebrowState;
            set
            {
                if (value < 0 || value > 6)
                    value = 0; // Default to 0 if out of range

                SetProperty(ref _eyebrowState, value, nameof(EyebrowState));
            }
        }

        [Description("Eye shape for the dialog.\nValues: 0 - 9")]
        [Category("03. Facial Expression")]
        [DisplayName("Eye Shape")]
        public int EyeState
        {
            get => _eyeState;
            set
            {
                if (value < 0 || value > 9)
                    value = 0; // Default to 0 if out of range

                SetProperty(ref _eyeState, value, nameof(EyeState));
            }
        }

        [Description("Eye openess state for the dialog.\nValues: 0 - 9")]
        [Category("03. Facial Expression")]
        [DisplayName("Eye Open State")]
        public int EyeOpenState
        {
            get => _eyeOpenState;
            set
            {
                if (value < 0 || value > 9)
                    value = 0; // Default to 0 if out of range

                SetProperty(ref _eyeOpenState, value, nameof(EyeOpenState));
            }
        }

        [Description("Pupil state for the dialog. Makes eyes bigger.\nValues: 0 - 1 (false/true)")]
        [Category("03. Facial Expression")]
        [DisplayName("Pupil State")]
        public bool PupilState
        {
            get => _pupilState;
            set => SetProperty(ref _pupilState, value, nameof(PupilState));
        }

        [Description("Mouth shape for the dialog.\nValues: 0 - 19")]
        [Category("03. Facial Expression")]
        [DisplayName("Mouth Shape")]
        public int MouthState
        {
            get => _mouthState;
            set
            {
                if (value < 0 || value > 19)
                    value = 0; // Default to 0 if out of range

                SetProperty(ref _mouthState, value, nameof(MouthState));
            }
        }

        [Description("Maximum mouth width scale.\nNo negative values. Can be a float type (ex: 0.8)")]
        [Category("04. Facial Expression - Mouth scale")]
        [DisplayName("Mouth Width (Max)")]
        public float MaxMouthWidth
        {
            get => _maxMouthWidth;
            set
            {
                if (value < 0)
                    value = 0; // No negative values

                SetProperty(ref _maxMouthWidth, value, nameof(MaxMouthWidth));
            }
        }

        [Description("Minimum mouth width scale.\nNo negative values. Can be a float type (ex: 0.8)")]
        [Category("04. Facial Expression - Mouth scale")]
        [DisplayName("Mouth Width (Min)")]
        public float MinMouthWidth
        {
            get => _minMouthWidth;
            set
            {
                if (value < 0)
                    value = 0; // No negative values

                SetProperty(ref _minMouthWidth, value, nameof(MinMouthWidth));
            }
        }

        [Description("Maximum mouth height scale.\nNo negative values. Can be a float type (ex: 0.8)")]
        [Category("04. Facial Expression - Mouth scale")]
        [DisplayName("Mouth Height (Max)")]
        public float MaxMouthHeight
        {
            get => _maxMouthHeight;
            set
            {
                if (value < 0)
                    value = 0; // No negative values

                SetProperty(ref _maxMouthHeight, value, nameof(MaxMouthHeight));
            }
        }

        [Description("Minimum mouth height scale.\nNo negative values. Can be a float type (ex: 0.8)")]
        [Category("04. Facial Expression - Mouth scale")]
        [DisplayName("Mouth Height (Min)")]
        public float MinMouthHeight
        {
            get => _minMouthHeight;
            set
            {
                if (value < 0)
                    value = 0; // No negative values

                SetProperty(ref _minMouthHeight, value, nameof(MinMouthHeight));
            }
        }

        [Description("Blush lines state for the dialog.\nValues: 0 - 10")]
        [Category("03. Facial Expression")]
        [DisplayName("Blush Lines State")]
        public int BlushLineState
        {
            get => _blushLineState;
            set
            {
                if (value < 0 || value > 10)
                    value = 0; // Default to 0 if out of range

                SetProperty(ref _blushLineState, value, nameof(BlushLineState));
            }
        }

        [Description("Blush state (redness) for the dialog.\nValues: 0 - 5")]
        [Category("03. Facial Expression")]
        [DisplayName("Blush State")]
        public int BlushState
        {
            get => _blushState;
            set
            {
                if (value < 0 || value > 5)
                    value = 0; // Default to 0 if out of range

                SetProperty(ref _blushState, value, nameof(BlushState));
            }
        }

        [Description("Tears state for the dialog.\nValues: 0 - 3 (0 = none, 1 = tears, 2 = eye shimmer, 3 = tears + eye shimmer)")]
        [Category("03. Facial Expression")]
        [DisplayName("Tears State")]
        public int TearsState
        {
            get => _tearsState;
            set
            {
                if (value < 0 || value > 3)
                    value = 0; // Default to 0 if out of range

                SetProperty(ref _tearsState, value, nameof(TearsState));
            }
        }

        [Description("Eye highlight for the dialog.\nValues: 0 - 1 (false/true)")]
        [Category("03. Facial Expression")]
        [DisplayName("Eye Highlight")]
        public bool EyeHighlight 
        {
            get => _eyeHighlight;
            set => SetProperty(ref _eyeHighlight, value, nameof(EyeHighlight));
        }
    }

    public class Dialog02Line : INotifyPropertyChanged
    {
        public BindingList<Dialog02Group> Groups { get; set; }
        public bool IsDirty => Groups.Any(g => g.IsDirty);

        public event PropertyChangedEventHandler PropertyChanged;

        public Dialog02Line()
        {
            Groups = new BindingList<Dialog02Group>
            {
                new Dialog02Group(),
                new Dialog02Group(),
                new Dialog02Group()
            };

            foreach (var group in Groups)
            {
                group.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(Dialog02Group.IsDirty))
                    {
                        OnPropertyChanged(nameof(IsDirty));
                    }
                };
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
