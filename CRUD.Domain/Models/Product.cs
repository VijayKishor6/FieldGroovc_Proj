using System.ComponentModel.DataAnnotations;

namespace CRUD.Domain.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
    
}
