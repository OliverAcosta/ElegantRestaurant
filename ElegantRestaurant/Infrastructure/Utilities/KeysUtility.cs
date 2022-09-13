using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utilities
{
    public class KeysUtility
    {
       public static SymmetricSecurityKey GetSymmetricSecurityKey(string key)
        {
            if(string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
    }
}
