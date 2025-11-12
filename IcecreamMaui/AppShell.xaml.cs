using IcecreamMaui.Pages;
using IcecreamMaui.Services;
using System.Runtime.CompilerServices;


namespace IcecreamMaui;
public partial class AppShell : Shell
{
    private readonly AuthService _authService;
   public AppShell(AuthService authService)
   {
     InitializeComponent();
        RegisterRoutes();
        _authService = authService;
   }

    private readonly static Type[] _routablePageTypes =
        [
            typeof(SignInPage),
            typeof(SignUpPage),
            typeof(MyOrdersPage),
            typeof(OrderDetailsPage),
            typeof(DetailsPage),
            typeof(HomePage),
            typeof(OnboardingPage),
        ];

    private static void RegisterRoutes()
    {
        foreach(var pageType in _routablePageTypes)
        {
            Routing.RegisterRoute(pageType.Name, pageType);
        }
        //Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
        //Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
    }

    private async void SignoutMenuItem_Clicked(object sender, EventArgs e)
    {
        // await Shell.Current.DisplayAlert("Alert", "Signout menu Item clicked", "Ok");
        _authService.Signout();
        await Shell.Current.GoToAsync($"//{nameof(OnboardingPage)}");
    }
}

