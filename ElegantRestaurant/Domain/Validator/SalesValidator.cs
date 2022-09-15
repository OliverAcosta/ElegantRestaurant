
using FluentValidation;

namespace Infrastructure.Entities
{
 
    public class SalesValidator: AbstractValidator<Sales>
    {
        public SalesValidator()
        {
            RuleFor(model => model.ProductId).GreaterThan(0).WithMessage("The productid has to be added!");
            RuleFor(model => model.Price).GreaterThan(0).WithMessage("The price cannot be zero or less!");
            RuleFor(model => model.Quantity).GreaterThan(0).WithMessage("The quantity cannot be zero or less!");
            RuleFor(model => model.SellTime).NotEmpty().WithMessage("The SellTime cannot be empty!");
        }
    }
}
