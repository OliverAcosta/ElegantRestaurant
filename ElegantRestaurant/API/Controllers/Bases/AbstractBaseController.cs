
using Commons.Utilities;
using Commons.Web.Results;
using Microsoft.AspNetCore.Mvc;

namespace ScheduleApi.Controllers.Bases
{
    public abstract class AbstractBaseController : ControllerBase
    {
        public AbstractBaseController() { }
        
        protected static bool IsConfigured = false;
        protected bool ShowAdministratorMessage { get; set; } = true;

        protected static string DefaultConnectionString { get; set; }

        protected ILogger<ControllerBase> logger;


        protected virtual ActionResult<RequestResult> GetBadRequest(Exception ex)
        {
             Task.Run(() => logger.LogError(ExceptionUtility.GetMessage(ex)));
            if (ShowAdministratorMessage)
                return BadRequest(RequestResult.ContactTheAdministrator);

            return BadRequest(new RequestResult
            {
                Errors = new ErrorResult
                {
                    Details = ex,
                    Message = ExceptionUtility.GetMessage(ex)
                }
            });
        }

        protected bool IsAuth()
        {
            return HttpContext.Items["User"] != null;
        }
        //protected int GetUserId() {
        //    var user = (AppUser) HttpContext.Items["User"];
        //    if(user != null)
        //    {
        //        return user.Id;
        //    }
        //    return 1;
        //}

        //protected RequestResult GetUser()
        //{
        //    var user = (AppUser)HttpContext.Items["User"];
        //    return new RequestResult
        //    {
        //        Success = user != null,
        //        Message = user == null ? "The user is not authenticated" : "The user is authenticated",
        //        Data = user
        //    };

        //}

        protected string GetRol()
        {
            return Convert.ToString(HttpContext.Items["Roles"]);
        }
    }
}
