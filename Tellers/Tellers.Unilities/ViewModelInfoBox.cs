using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.Utilities.Interfaces;

namespace Tellers.Utilities
{
    public class ViewModelInfoBox<T> : IViewModelInfoBox<T>
    {
        public string ModelIndicator { get; set; } = null!;

        public T? ViewModel { get; set; } 
    }
}
