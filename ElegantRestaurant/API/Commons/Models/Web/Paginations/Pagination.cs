using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models.Web.Paginations
{
    public class Pagination:BasePagination
    {
        public int Max { get; set; } = 100;
    }
}
