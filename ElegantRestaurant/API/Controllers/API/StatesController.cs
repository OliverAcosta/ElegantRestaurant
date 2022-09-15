using Infrastructure.Entities;
using ScheduleApi.Controllers.Derivatives;

namespace API.Controllers.API
{
    public class StatesController:AppBaseController<States>
    {
        public StatesController(ILogger<StatesController> logger)
        {
            this.logger = logger;
        }
    }
}
