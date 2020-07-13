using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Altkom.WPFMVVM.Models
{
    public abstract class Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

            //if (PropertyChanged!=null)
            //{
            //    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
            //}


        }

    }
}
