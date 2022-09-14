using Commons.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models.Entities.Base
{
    public class StateBase<T>: IState
    {
        public T Id { get; set; }
        public int StateId { get; set; }
    }
}
