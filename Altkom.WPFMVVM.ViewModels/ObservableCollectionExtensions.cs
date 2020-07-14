using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Altkom.WPFMVVM.ViewModels
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> AsObservable<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }
    }
}
