using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utilities
{
    public class JWTBearerParam
    {
        public bool ValidateIssuerSigningKey { get; set; }
        public SymmetricSecurityKey SymmetricSecurityKey { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool SaveToken { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public TimeSpan TokenDuration { get; set; }
    }
}
