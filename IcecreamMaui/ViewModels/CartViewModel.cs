using IcecreamMaui.Models;
using IcecreamMAUI.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcecreamMaui.ViewModels
{
   public partial class CartViewModel : BaseViewModel
    {
        public ObservableCollection<CartItem> CartItems { get; set; } = [];

        public static int TotalCartCount {  get; set; }
        public static event EventHandler<int>? TotalCartCountChanged;

        public async Task AddItemCart(IcecreamDTO icecream, int Quantity, string Flavor, string Topping)
        {
            var existingItem = CartItems.FirstOrDefault(ci => ci.IcecreamId == icecream.Id);
            if (existingItem is not null)
            {
                if(Quantity <= 0)
                {
                    //user wants to remove this item from cart
                    CartItems.Remove(existingItem);
                    await ShowToastAsync("Icecream removed from Cart");
                }
                else
                {
                    existingItem.Quantity = Quantity;
                    await ShowToastAsync("Quantity Updated in Cart");
                }
            }
            else
            {
                var CartItem = new CartItem
                {
                    FlavorName = Flavor,
                    IcecreamId = icecream.Id,
                    Name = icecream.Name,
                    price = icecream.Price,
                    Quantity = Quantity,
                    ToppingName = Topping
                };

                CartItems.Add(CartItem);
                await ShowToastAsync("Icecreams added to Cart");
            }

            TotalCartCount = CartItems.Sum(i=> i.Quantity);
            TotalCartCountChanged?.Invoke (null, TotalCartCount);
        }
    }
}
