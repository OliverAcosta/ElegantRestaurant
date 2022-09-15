using Infrastructure.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Base
{
    public abstract class EntityBase<T> : IIdentity<T>
    {
        [Key]
        public T Id { get; set; }

        
    }
}
