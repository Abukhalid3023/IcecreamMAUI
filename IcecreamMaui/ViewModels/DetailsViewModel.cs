using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IcecreamMaui.Models;
using IcecreamMAUI.Shared.DTOS;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcecreamMaui.ViewModels
{
    [QueryProperty(nameof(Icecream), nameof(Icecream))]
    public partial class DetailsViewModel : BaseViewModel
    {
        private readonly CartViewModel _cartViewModel;

            public DetailsViewModel(CartViewModel cartViewModel)
            {    
               _cartViewModel = cartViewModel;
            }
            [ObservableProperty]
            private IcecreamDTO? icecream;

            
            public DetailsViewModel()
            {
        
            }

        [ObservableProperty]
        private int _Quantity;

        [ObservableProperty]
        private IcecreamOption[] _options = [];
        private readonly CartViewModel cartViewModel;

        partial void OnIcecreamChanged(IcecreamDTO? value)
        {
            Options = [];
            if (value is null)
                return;

            Options = value.Options.Select(o => new IcecreamOption
            {
                Flavor = o.Flavor,
                Topping = o.Topping,
                IsSelected = false
            })
                .ToArray();
        }

        [RelayCommand]
        private void IncreaseQuantity() => Quantity++;

        [RelayCommand]
        private void DecreaseQuantity() => Quantity--;

        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..", animate: true);
        }

        [RelayCommand]
        private void SelectOption(IcecreamOption newOption)
        {
            var  newIsSelected = !newOption.IsSelected;
            //Deselect all options
            Options = [.. Options.Select(o => { o.IsSelected = false; return o; })];
            newOption.IsSelected = newIsSelected;
        }

        [RelayCommand]
        private async Task AddToCart()
        {
            if(Icecream is null)
                return;

            var selectedOption = Options.FirstOrDefault(o => o.IsSelected) ?? Options[0];
            await _cartViewModel.AddItemCart(Icecream, Quantity, selectedOption.Flavor, selectedOption.Topping);
        }
    }  
}

