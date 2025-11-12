using IcecreamMAUI.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace IcecreamMAUI.API.Data;


public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { 
    }
    public DbSet<User> Users { get; set; }

    public DbSet<Icecream> Icecreams { get; set; }

    public DbSet<IcecreamOption> IcecreamOptions { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IcecreamOption>()
                    .HasKey(io => new { io.IcecreamId, io.Flavor, io.Topping });

        AddSeedData(modelBuilder);
    }

    private static void AddSeedData(ModelBuilder modelBuilder)
    {
        Icecream[] icecreams = [

            new Icecream { Id = 1, Name = "Vanilla Dream", Image = "vanilla.png", Price = 5.0 },
            new Icecream { Id = 2, Name = "Chocolate Bliss", Image = "chocolate.png", Price = 7.90},
            new Icecream { Id = 3, Name = "Strawberry Swirl", Image = "strawberry.png", Price = 8.70},
            new Icecream { Id = 4, Name = "Mango Magic", Image = "mango.png", Price = 3.64},
            new Icecream { Id= 5, Name = "Blueberry Burst", Image = "blue_berry.png", Price = 9.78}
            ];
        IcecreamOption[] icecreamOptions = [

            new IcecreamOption { IcecreamId = 1, Flavor = "Classic Vanilla", Topping = "Choco Chips" },
            new IcecreamOption { IcecreamId = 2, Flavor = "Dark Chocolate", Topping = "Brownie Bits" },
            new IcecreamOption { IcecreamId = 3, Flavor = "Fresh Strawberry", Topping = "Whipped Cream" },
            new IcecreamOption { IcecreamId = 4, Flavor = "Alphonso Mango", Topping = "Honey Drizzle" },
            new IcecreamOption { IcecreamId = 5, Flavor = "Wild Blueberry", Topping = "Sprinkles" }
            ];

        modelBuilder.Entity<Icecream>()
            .HasData(icecreams);
        modelBuilder.Entity<IcecreamOption>() 
            .HasData(icecreamOptions);
    }
}
