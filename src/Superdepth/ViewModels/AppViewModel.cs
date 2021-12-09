using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Superdepth
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _InputFilePath;
        public string InputFilePath
        {
            get => _InputFilePath;
            set => SetProperty(ref _InputFilePath, value);
        }

        

        private void SetProperty<T> (ref T stg, T value, [CallerMemberName] string propertyName = null)
        {
            // type check?  type? stg=value
            stg=value;
            RaisePropertyChanged (propertyName);
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
