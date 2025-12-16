using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class Inventory
    {
        public int No { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Desription is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
    }
}
