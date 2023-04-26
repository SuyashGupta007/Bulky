using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }

        [Required(ErrorMessage = "Medicine is required.")]
        public string? CarId { get; set; }

        public string? CatName { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
