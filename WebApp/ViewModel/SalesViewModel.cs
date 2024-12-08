using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class SalesViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int SelectedProductId { get; set; }

        [Display(Name = "Quantity")]
        [Required]
        [Range(1, int.MaxValue)]
        public int QuantityToSell { get; set; }
    }
}
