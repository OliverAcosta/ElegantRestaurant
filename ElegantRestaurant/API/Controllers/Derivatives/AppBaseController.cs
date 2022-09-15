

using Commons.Entities.Models.Interfaces;
using Commons.Web.Results;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.Entities.Base;
using Infrastructure.Entities.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.Controllers.Bases;

namespace ScheduleApi.Controllers.Derivatives
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppBaseController<T> : AbstractBaseController where T : EntityBase<int>
    {
        protected readonly IGenericRepository<T> repository;
        protected IValidator<T> validator;
        protected AppBaseController( )
        {
            repository = new GenericRepository<T>();
        }
          

        
        [ProducesResponseType(typeof(RequestResult), 400)]
        [ProducesResponseType(typeof(RequestResult), 200)]
        [HttpPost("add")]
        public async Task<ActionResult<RequestResult>> Add(T entity)
        {
            try
            {
                var validation = await validator.ValidateAsync(entity);
                
                if (!validation.IsValid)
                {
                    return BadRequest(new RequestResult
                    {
                        Errors = new ErrorResult
                        {
                            Details = validation.Errors.Select(e=> new
                            {
                                e.PropertyName,
                                e.ErrorMessage
                            }).ToArray()
                        }
                    });
                }
                if (entity is IState e) {
                    if (e.StateId == 0)
                    {
                        ((IState)entity).StateId = 1;
                    }
                }
                var model = await repository.Add(entity);
                return Ok(new RequestResult
                {
                    Success = true,
                    Data = model
                });
            }
            catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }

       
        [HttpGet("get/{id}")]
        public async Task<ActionResult<RequestResult>> Get(int id)
        {
            try
            {
               var entity = await repository.Get(id);
               if(entity == null) return NotFound(RequestResult.NotDataFound);

               return Ok(new RequestResult 
               { 
                   Success = true,
                   Data= entity,
                   Message = "Entity found"
               });

            }
            catch (Exception ex)
            {
               return GetBadRequest(ex);
            }
        }

        
        [HttpGet("data")]
        public async Task<ActionResult<RequestResult>> Data()
        {
            try
            {
                return Ok(new RequestResult
                {
                    Success = true,
                    Data = repository.GetAll(),
                    Message = "This method always return success"
                });
            }
            catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }

        [HttpGet("pagination/{page}/{pageSize}")]
        public async Task<ActionResult<RequestResult>> Pagination(int page = 0, int pageSize = 10)
        {
            try
            {
                var entities =  repository.Pagination(page, pageSize);

                return Ok(new RequestResult
                {
                    Success = true,
                    Data = entities,
                    Message = "Entity found"
                });

            }
            catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<RequestResult>> Update(T model)
        {
            try
            {
                //if (model is IUser)
                //{
                //    ((IUser)model).UserId = GetUserId();
                //}
                
                var entity = await repository.Update(model);
               
                return Ok(new RequestResult
                {
                    Success = true,
                    Data = entity,
                    Message = "Updated completed!"
                });
            }
            catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }



        [HttpDelete("delete/{id}")]
        public virtual async Task<ActionResult<RequestResult>> Delete(int id)
        {
            try
            {
                var entity = await repository.Delete(id);
                if (entity != null)
                {
                    return Ok(new RequestResult
                    {
                        Success = true,
                        Data = entity,
                        Message = "Entity deleted"
                    });
                }
                return NotFound(new RequestResult
                {
                    Success = false,
                    Message = "entity was not found"
                });


            }
            catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }

    }
}
