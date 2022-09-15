using Infrastructure.Entities;
using ScheduleApi.Controllers.Derivatives;

namespace API.Controllers.API
{
    public class SalesController:AppBaseController<Sales>
    {
        public SalesController(ILogger<SalesController> logger)
        {
            this.logger = logger;
        }
    }
}
