using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModel.Validations
{
    public class SalesViewModel_EnsureProperQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;

            if (salesViewModel != null)
            {
                if(salesViewModel.QuantityToSell <= 1)
                {
                    return new ValidationResult("The quantity to sell has to be greater than zero");
                } 
                else
                {
                    var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
                    if (product != null)
                    {
                        //The whole point of creating a custom Validation is here.
                        //If Quantity to sell is GREATER than Quantity itself for product we have to return a error.
                        if(product.Quantity < salesViewModel.QuantityToSell)
                        {
                            return new ValidationResult($"{product.Name} only has {product.Quantity} left.");
                        }
                    }
                    else
                    {
                        return new ValidationResult("Selected Product Doesn't Exist.");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
