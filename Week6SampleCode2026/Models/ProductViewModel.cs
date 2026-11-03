using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Week6SampleCode2026.Models
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Product ID is required")]
        
        public int ProductID { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Category ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Category ID must be Chosen from the Category options list")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Supplier ID is required")]
        [DisplayName("Supplier")]
        [Range(1, int.MaxValue, ErrorMessage = "Supplier ID must be chosen from the existing suppliers list")]
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Unit Price is required")]
        [DisplayName("Unit Price")]
        [Range(0.01, float.MaxValue, ErrorMessage = "Unit Price must be greater than 0")]
        public float UnitPrice { get; set; }

        [Required(ErrorMessage = "Date First Issued is required")]
        [DataType(DataType.Date)]
        [DisplayName("Date First Supplied")]
        public DateTime dateFirstIssued { get; set; }

        [Required(ErrorMessage = "Quantity In Stock is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity In Stock cannot be negative")]
        public int QuantityInStock { get; set; }
    }
}
