using Commons.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models.Entities.Base
{
    public class StateValid : GenericEntityBase<int>
    {
        public bool State { get; set; }
    }
}
