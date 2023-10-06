using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_App.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }



        [ForeignKey("Id")]
        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }


        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public List<Product> Products { get; set; }

        public double TotalPrice { get; set; }
    }
}
