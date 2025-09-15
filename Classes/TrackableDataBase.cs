using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AA2PersonalityDisorder.Classes
{
    public class TrackableDataBase : INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> _originalValues = new Dictionary<string, object>();
        private readonly HashSet<string> _dirtyProperties = new HashSet<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            // Set old value BEFORE any changes
            T oldValue = field;

            if (!_originalValues.ContainsKey(propertyName))
                _originalValues[propertyName] = oldValue;

            // Commit the new value
            field = value;

            var originalValue = _originalValues[propertyName];

            // Type-safe comparison using EqualityComparer<T>
            bool isDifferent;
            try
            {
                isDifferent = !EqualityComparer<T>.Default.Equals((T)originalValue, value);
            }
            catch
            {
                // fallback to object equality if cast somehow fails
                isDifferent = !object.Equals(originalValue, value);
            }

            if (isDifferent)
                _dirtyProperties.Add(propertyName);
            else
                _dirtyProperties.Remove(propertyName);

            OnPropertyChanged(propertyName);
            OnPropertyChanged(nameof(IsDirty));
        }

        // Explicitly mark a property as dirty without changing its value (used to flag import issues)
        protected void MarkDirty(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                return;

            _dirtyProperties.Add(propertyName);
            OnPropertyChanged(propertyName);
            OnPropertyChanged(nameof(IsDirty));
        }

        [Browsable(false)]
        public bool IsDirty
        {
            get { return _dirtyProperties.Count > 0; }
        }

        [Browsable(false)]
        public IEnumerable<string> DirtyProperties
        {
            get { return _dirtyProperties; }
        }

        public void AcceptChanges()
        {
            foreach (var propName in _dirtyProperties)
            {
                PropertyInfo prop = this.GetType().GetProperty(propName);
                if (prop != null)
                {
                    var value = prop.GetValue(this, null);
                    _originalValues[propName] = value;
                }
            }
            _dirtyProperties.Clear();
            OnPropertyChanged("IsDirty");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object GetOriginalValue(string propertyName)
        {
            object value;
            if (_originalValues.TryGetValue(propertyName, out value))
                return value;
            return null;
        }
    }
}
