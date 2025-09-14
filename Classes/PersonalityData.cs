using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA2PersonalityDisorder.Classes
{
    public class PersonalityData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _gender;
        private int _slot;
        private string _name;
    }
}
