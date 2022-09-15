using FluentValidation;
using Infrastructure.Entities;
using ScheduleApi.Controllers.Derivatives;

namespace API.Controllers.API
{
    public class ProductsController: AppBaseController<Products>
    {
        public ProductsController(IValidator<Products> validator, ILogger<ProductsController> logger)
        {
            this.validator = validator;
            this.logger = logger;
        }
    }
}
