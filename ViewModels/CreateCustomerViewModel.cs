using System.ComponentModel.DataAnnotations;

namespace MyCustomer.ViewModels
{
    public class CreateCustomerViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}