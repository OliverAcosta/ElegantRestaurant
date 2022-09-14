using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Web.Results
{
    public class ErrorResult
    {
        public string Message { get; set; }
        public object Details { get; set; }
    }
}
