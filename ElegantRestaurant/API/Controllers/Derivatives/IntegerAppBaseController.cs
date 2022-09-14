

using Commons.Entities.Models.Interfaces;
using Commons.Models.Entities.Base;
using Commons.Models.Entities.Interfaces;
using Commons.Web.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleApi.Controllers.Bases;
using System.Reflection;

namespace ScheduleApi.Controllers.Derivatives
{
    [Route("api/[controller]")]
    [ApiController]

    public class IntegerAppBaseController<T> : AbstractBaseController where T : EntityBase<int>
    {
        protected IntegerAppBaseController() { 
            SetDb(); 
          
        protected void SetDb()
        {
            if (!IsConfigured)
            {
               
            }            
        }
        
        [ProducesResponseType(typeof(RequestResult), 400)]
        [ProducesResponseType(typeof(RequestResult), 200)]
        [HttpPost("add")]
        public async Task<ActionResult<RequestResult>> Add(T entity)
        {
            try
            {
               
                if(entity is IUser)
                {
                     ((IUser)entity).UserId = GetUserId();
                }
                if(entity is ICreated)
                {
                    ((ICreated)entity).Created = DateTime.Now;
                }
                if (entity is IState)
                {
                    ((IState)entity).StateId = StatesConst.Active;
                }

                await db.AddAsync(entity);
                await db.SaveChangesAsync();
                return Ok(new RequestResult
                {
                    Success = true,
                    Data = entity
                });
            }
            catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }

       
        [HttpPost("add-range")]
        public async Task<ActionResult<RequestResult>> AddRange([FromBody] T[] entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    if (entity is IUser)
                    {
                        ((IUser)entity).UserId = GetUserId();
                    }
                    if (entity is ICreated)
                    {
                        ((ICreated)entity).Created = DateTime.Now;
                    }
                    if (entity is IState)
                    {
                        ((IState)entity).StateId = StatesConst.Active;
                    }
                }
                await db.AddRangeAsync(entities);
                await db.SaveChangesAsync();
                return Ok(new RequestResult
                {
                    Success = true,
                    Data = entities
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
               var entity = await db.Set<T>().FirstOrDefaultAsync(m=> m.Id == id);
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
                    Data = db.Set<T>().AsAsyncEnumerable(),
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
                if (page < 0) { page = 0; }
                if(pageSize <= 0) { pageSize = 1; }
                if(pageSize > 100) { pageSize = 100; }
                int skip =  pageSize * page;


                var entity = await db.Set<T>().Skip(skip).Take(pageSize).ToArrayAsync();
                if (entity.Length == 0) return NotFound(RequestResult.NotDataFound);

                return Ok(new RequestResult
                {
                    Success = true,
                    Data = entity,
                    Message = "Entity found"
                });

            }
            catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }
        //working in it, not implmented yet
       // [HttpPost("search")]
        private async Task<ActionResult<RequestResult>> Search(SearchByProperty search)
        {
            try
            {
                
               

                var entity = await db.Set<T>().Skip(search.Page * search.PageSize).Take(search.PageSize).ToArrayAsync();
                if (entity.Length == 0) return NotFound(RequestResult.NotDataFound);

                return Ok(new RequestResult
                {
                    Success = true,
                    Data = entity,
                    Message = "Entity found"
                });

            }
            catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }


        [HttpGet("entity-info")]
        public async Task<ActionResult<RequestResult>> GetProperties()
        {
            try
            {
                var name = db.Model.FindEntityType(typeof(T)).GetTableName();
                var entity = Activator.CreateInstance(typeof(T));
                var Properties = await Task.Run(() =>{
                   return entity.GetType().GetProperties()
                        .Where(m => m.PropertyType.IsPrimitive || m.PropertyType == typeof(string))
                        .Select(m => new { m.Name, Type = m.PropertyType.Name });

                });

                return Ok(new RequestResult
                {
                    Success = true,
                    Data = new
                    {
                        Name = name,
                        Properties
                    },
                    Message = "Base info of model"
                });
            }
            catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<RequestResult>> Update(T entity)
        {
            try
            {
                if (entity is IUser)
                {
                    ((IUser)entity).UserId = GetUserId();
                }
                
                db.Update(entity);
                await db.SaveChangesAsync();
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

        [HttpPost("update-properties")]
        public async Task<ActionResult<RequestResult>> ChangeProperty(PropertiesUpdater<int> model)
        {
            try
            {
               
                if (model.Id == 0 || model.Properties.Length == 0) return BadRequest(new RequestResult
                {
                    Message = "Not properties to update was found"
                });
                var entity = await db.Set<T>().FirstOrDefaultAsync(m => m.Id == model.Id);
                if (entity == null) return NotFound(new RequestResult());
                var typeProperties = entity.GetType().GetProperties();

                PropertiesChanged[] propertiesChanged = Array.ConvertAll(model.Properties, x => (PropertiesChanged)x);
                PropertyInfo prop = null;
                for (int i = 0; i < model.Properties.Length; i++)
                {
                    prop = typeProperties.FirstOrDefault(m => m.Name.Equals(model.Properties[i].Name,StringComparison.OrdinalIgnoreCase));
                    if (prop != null )
                    {
                        prop.SetValue(entity, ObjUtility.GetObject(prop.PropertyType, model.Properties[i].Value));
                        propertiesChanged[i].Updated = true;
                    }
                    else
                    {
                        propertiesChanged[i].Updated = false;
                    }
                }
                
                db.Update(entity);
                await db.SaveChangesAsync();
                prop = null;
                typeProperties = null;
                return Ok(new RequestResult
                {
                    Success = true,
                    Data = new
                    {
                        Entity = entity,
                        Info = propertiesChanged
                    },
                    Message = "Updated completed!"
                });
            }catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }


        [HttpPost("counts")]
        public virtual async Task<ActionResult<RequestResult>> Counts()
        {
            try
            {
                int counts = await db.Set<T>().CountAsync();

                return Ok(new RequestResult
                {
                    Success = true,
                    Message = counts + " object counts ",
                    Data = counts
                });
            }
            catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }

        [HttpPost("change-state")]
        public virtual async Task<ActionResult<RequestResult>> ChangeState(StateBase<int> stateBase)
        {
            try
            {
                var entity = await db.Set<T>().Where(m => m.Id == stateBase.Id).FirstOrDefaultAsync();
                if (entity == null)
                {
                    return NotFound(RequestResult.NotDataFound);
                }
                IState state = ((IState)entity);
                state.StateId = stateBase.StateId;
                // entity.StateId = stateBase.StateId;
                db.Update(state).Property(m => m.StateId).IsModified = true;
                await db.SaveChangesAsync();
                
                return Ok(new RequestResult
                {
                    Success = true,
                    Data = entity,
                    Message = "State updated"
                });
            }catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }

        [HttpDelete("delete/{id}")]
        public virtual async Task<ActionResult<RequestResult>> Delete(int id)
        {
            try
            {
                var entity = await db.Set<T>().Where(m => m.Id == id).FirstOrDefaultAsync();
                if (entity == null)
                {
                    return NotFound(RequestResult.NotDataFound);
                }
                if (entity is IDeletable)
                {
                    db.Remove(entity);
                    await db.SaveChangesAsync();
                    return Ok(new RequestResult
                    {
                        Success = true,
                        Data = entity,
                        Message = "Entity deleted"
                    });
                }
                if (entity is IState)
                {
                    ((IState)entity).StateId = StatesConst.Inactive;
                }

                return Ok(new RequestResult
                {
                    Success = true,
                    Data = entity,
                    Message = "State updated"
                });


            }
            catch (Exception ex)
            {
                return GetBadRequest(ex);
            }
        }

    }
}
