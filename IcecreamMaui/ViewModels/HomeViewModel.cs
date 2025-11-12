using CommunityToolkit.Mvvm.ComponentModel;
using IcecreamMAUI.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IcecreamMaui.Services;
using IcecreamMaui.Pages;
using CommunityToolkit.Mvvm.Input;

namespace IcecreamMaui.ViewModels
{
     public partial class HomeViewModel(IIcecreamApi icecreamApi, AuthService authService) : BaseViewModel
    {
        private readonly IIcecreamApi _icecreamApi = icecreamApi;
        private readonly AuthService _authService = authService;

        [ObservableProperty]
        private IcecreamDTO[] _icecreams = [];

        [ObservableProperty]
        private string _userName = string.Empty;

        private bool _isInitialize;
        public async Task InitializeAsync()
        {
            _userName = _authService.User!.Name;
            if (_isInitialize)
                return;

            IsBusy = true;

            try
            { 
                _isInitialize = true;
                Icecreams  = await _icecreamApi.GetIcecreamsAsync();
            }
            catch(Exception ex) 
            {
                _isInitialize = false;
               await ShowErrorAlertAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoToDetailsPageAsync(IcecreamDTO icecream)
        {
            var parameter = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Icecream)]= icecream,
            };
            await GoToAsync(nameof(DetailsPage), animate: true, parameter);
        }
    }
}
