using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcecreamMAUI.Shared.DTOS
{

    public record struct IcecreamOptionDTO(string Flavor, string Topping);



    public record IcecreamDTO(int Id, string Name, string Image, Double Price, IcecreamOptionDTO[] Options);

   
    
}
