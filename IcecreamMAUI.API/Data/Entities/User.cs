using System.ComponentModel.DataAnnotations;

namespace IcecreamMAUI.API.Data.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required,MaxLength (100)]
        public string Email { get; set; }
        [Required, MaxLength (150)]
        public string Address {  get; set; }
        [Required, MaxLength(50)]
        public string Salt {  get; set; }
        [Required, MaxLength(150)]
        public string Hash { get; set; }  
    }
}
