using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcecreamMaui.Models
{
    public partial class IcecreamOption : ObservableObject
    {
        public String Flavor { get; set; }

        public string Topping {  get; set; }

        [ObservableProperty]
        private bool _isSelected;
    }
}
