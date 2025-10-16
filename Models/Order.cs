using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagerMvc.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Status is required")]
        [StringLength(40)]
        public string Status { get; set; } = "Draft";

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        [NotMapped]
        [DataType(DataType.Currency)]
        public decimal Total => Items.Sum(i => i.Quantity * i.UnitPrice); // Use Quantity * UnitPrice
    }
}