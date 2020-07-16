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

    public static class INotifyPropertyChangedExtensions
    {
        public static void ExecuteOnPropertyChanged(this INotifyPropertyChanged item, string propname, System.Action action)
        {
           item.PropertyChanged += (s, e) =>
           {
               if (e.PropertyName == propname)
               {
                   action?.Invoke();
               };

               return;
           };

        }
    }
}
