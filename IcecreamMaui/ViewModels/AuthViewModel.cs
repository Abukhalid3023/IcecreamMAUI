using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IcecreamMaui.Pages;
using IcecreamMaui.Services;
using IcecreamMAUI.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IcecreamMaui.ViewModels
{
    public partial class AuthViewModel(IAuthApi authApi, AuthService authService) : BaseViewModel
    {
        private readonly IAuthApi _authApi = authApi; 
        private readonly AuthService _authService = authService;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _name;

        [ObservableProperty , NotifyPropertyChangedFor(nameof(CanSignin)),NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _email;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignin)),NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _password;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _address;

        public bool CanSignup => CanSignin &&
                                 !string.IsNullOrEmpty(Name) &&
                                 !string.IsNullOrEmpty(Address);

        public bool CanSignin => !string.IsNullOrEmpty(Email)&&
                                 !string.IsNullOrEmpty(Password);

        [RelayCommand]
        private async Task SignupAsync()
        {
            IsBusy = true;
            try
            {
                var signupDTO = new SignupRegisterDT0(Name, Email, Password, Address);
                //Make Api Call
                var result = await _authApi.SignupAsync(signupDTO);

                if (result.IsSuccess)
                {
                    _authService.Signin(result.Data);
                    await GoToAsync($"//{nameof(HomePage)}", animate: true);
                    //Navigate to HomePage
                }
                else
                {
                    await ShowErrorAlertAsync(result.ErrorMessage);
                    //Display Error Alert
                }
            }
            catch(Exception ex)
            {
                await ShowErrorAlertAsync(ex.Message ?? "Unknown error in signing up");
            }
            finally
            {
                IsBusy = false;
            }
        }


        [RelayCommand]
        private async Task SigninAsync()
        {
            IsBusy = true;
            try
            {
                var signinDTO = new SigninRequestDTO(Email, Password);
                //Make Api Call
                var result = await _authApi.SigninAsync(signinDTO);

                if (result.IsSuccess)
                {

                    _authService.Signin(result.Data);
                    await GoToAsync($"//{nameof(HomePage)}", animate: true);
                    //Navigate to HomePage
                }
                else
                {
                    await ShowErrorAlertAsync(result.ErrorMessage);
                    //Display Error Alert
                }
            }
            catch (Exception ex)
            {
                await ShowErrorAlertAsync(ex.Message ?? "Unknown error in signing in");
            }
            finally
            {
                IsBusy = false;
            }

        }
        
    }

}
