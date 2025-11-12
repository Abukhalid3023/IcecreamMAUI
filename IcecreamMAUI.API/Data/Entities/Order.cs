using System.ComponentModel.DataAnnotations;


namespace IcecreamMAUI.API.Data.Entities
{
  public class Order
  {
    public long Id { get; set; }

    public DateTime OrederAt { get; set; } = DateTime.Now;

    public Guid CustomerId { get; set; }

    [Required, MaxLength(50)]
    public Guid CustomerName { get; set; }

    [Required, MaxLength(100)]
    public Guid CustomerEmail { get; set; }

    [Required, MaxLength(150)]
    public Guid CustomerAddress { get; set; }

    [Range(0.1, double.MaxValue)]
    public double TotalPrice {  get; set; }

    public ICollection<OrderItem> Items { get; set; }

  }
}
