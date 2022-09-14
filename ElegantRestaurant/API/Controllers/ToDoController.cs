using Microsoft.AspNetCore.Mvc;
using ScheduleApi.Controllers.Derivatives;
using ScheduleDb.Models;
using Microsoft.EntityFrameworkCore;
using ScheduleApi.Helper;
using ScheduleApi.Filters;
using ScheduleApi.Filters.Roles;

namespace ScheduleApi.Controllers 
{
    
    public class ToDoController : IntegerAppBaseController<ToDo>
    {
        public ToDoController(ILogger<ToDoController> logger)
        {
            this.logger = logger;
        }

       
    }
}
