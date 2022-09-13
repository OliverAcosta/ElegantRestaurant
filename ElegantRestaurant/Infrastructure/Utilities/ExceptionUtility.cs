using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utilities
{
    public class ExceptionUtility
    {

        public static string GetMessage(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ex.ToString());
            sb.Append(Environment.NewLine);
            Exception e = ex.InnerException;
            while (e != null)
            {
                sb.Append(e.ToString() + Environment.NewLine);
                e = e.InnerException;
            }

            return sb.ToString();
        }


    }
}
