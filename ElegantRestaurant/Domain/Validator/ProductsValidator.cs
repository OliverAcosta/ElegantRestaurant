using FluentValidation;
using Infrastructure.Entities;

namespace Domain.Validator
{
    public class ProductsValidator:AbstractValidator<Products>
    {
        public ProductsValidator()
        {
            RuleFor(model => model.Name).NotNull().WithMessage("Name cannot be null");
            RuleFor(model => model.Name).NotEmpty().WithMessage("You cannot add a product without a name!");
            RuleFor(model => model.Name).MinimumLength(3).WithMessage("The name must be at lest 3 characters!");
            RuleFor(model => model.Price).GreaterThan(0).WithMessage("The price cannot be zero or less!");
            RuleFor(model => model.Description).NotEmpty().WithMessage("You have to add a description!");
        }

        
      
    }
}
