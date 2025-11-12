using IcecreamMAUI.API.Services;
using IcecreamMAUI.Shared.DTOS;
using System.Threading.Tasks;

namespace IcecreamMAUI.API.Endpoints
{
    public static class Endpoints
    {
        public static async Task<IEndpointRouteBuilder>MapEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/signup", 
                async (SignupRegisterDT0 dto, AuthService authService) =>
                TypedResults.Ok(await authService.SignupAsync(dto)));

            app.MapPost("/api/signin",
                async (SigninRequestDTO dto, AuthService authService) =>
                TypedResults.Ok(await authService.SigninAsync(dto)));

            app.MapGet("/api/icecreams",
                async(IcecreamService icecreamService) =>
                TypedResults.Ok(await icecreamService.GetIcecreamsAsync()));

            return app;
                

        }
    }
}
