using IcecreamMAUI.API.Data;
using IcecreamMAUI.Shared.DTOS;
using Microsoft.EntityFrameworkCore;

namespace IcecreamMAUI.API.Services
{
    public class IcecreamService(DataContext context)
    {
        private readonly DataContext _context = context;

        public async Task<IcecreamDTO[]> GetIcecreamsAsync() =>
            await _context.Icecreams.AsNoTracking()
            .Select(i=> 
            new IcecreamDTO(
                i.Id,
                i.Name,
                i.Image,
                i.Price,
                i.Options
                   .Select(o=> new IcecreamOptionDTO(o.Flavor,o.Topping))
                .ToArray()))
            .ToArrayAsync();
    }
}
