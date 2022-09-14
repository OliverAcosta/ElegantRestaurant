using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models.Web.Paginations
{
    public class BasePagination
    {
        
        protected int _page = 0;
        public int Page
        {
            get { return _page * PageSize; }
            set { _page = value; }
        }

        public int PageSize { get; set; } = 1;
    }
}
