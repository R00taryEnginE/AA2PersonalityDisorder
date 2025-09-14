using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA2PersonalityDisorder.Classes
{
    public class EditorContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Project data
        private string _projectDirectory;

        // Personality files
        private string _dialog02FilePath;
        private string _audioDirectoryPath;

        // Runtime data
        private List<Dialog02Line> _loadedDialog02Lines;

        public string ProjectDirectory
        {
            get => _projectDirectory;
            set
            {
                if (_projectDirectory != value)
                {
                    _projectDirectory = value;
                    OnPropertyChanged(nameof(ProjectDirectory));
                }
            }
        }

        public string Dialog02FilePath
        {
            get => _dialog02FilePath;
            set
            {
                if (_dialog02FilePath != value)
                {
                    _dialog02FilePath = value;
                    OnPropertyChanged(nameof(Dialog02FilePath));
                }
            }
        }

        public string AudioDirectoryPath
        {
            get => _audioDirectoryPath;
            set
            {
                if (_audioDirectoryPath != value)
                {
                    _audioDirectoryPath = value;
                    OnPropertyChanged(nameof(AudioDirectoryPath));
                }
            }
        }

        public List<Dialog02Line> LoadedDialog02Lines
        {
            get => _loadedDialog02Lines;
            set
            {
                if (_loadedDialog02Lines != value)
                {
                    _loadedDialog02Lines = value;
                    OnPropertyChanged(nameof(LoadedDialog02Lines));
                }
            }
        }
    }
}
