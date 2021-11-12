using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greenglobal.Erp.Models
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }

        public DateTime ExpiresIn { get; set; }
    }
}
