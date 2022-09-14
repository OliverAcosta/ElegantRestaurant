using Commons.Entities.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models.Entities.Base
{
    public abstract class GenericEntityBase<T>:  IGenericIdentity<T>
    {
        public virtual T Id { get; set; }
    }
}
