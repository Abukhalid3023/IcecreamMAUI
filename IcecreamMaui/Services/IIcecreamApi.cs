using IcecreamMAUI.Shared.DTOS;
using Refit;

namespace IcecreamMaui.Services
{
    public interface IIcecreamApi
    {
        [Get("/api/icecreams")]
        Task<IcecreamDTO[]> GetIcecreamsAsync();
    }
}
