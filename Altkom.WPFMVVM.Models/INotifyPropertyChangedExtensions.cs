using System.ComponentModel;

namespace Altkom.WPFMVVM.Models
{
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
