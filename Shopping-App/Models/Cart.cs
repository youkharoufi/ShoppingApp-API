using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_App.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }



        [ForeignKey("Id")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<CartItems> CartItems { get; set; } = new List<CartItems>();


        public double TotalPrice { get; set; }
    }
}
