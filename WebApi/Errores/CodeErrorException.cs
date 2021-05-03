using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Errores
{
    public class CodeErrorException : CodeErrorsResponse
    {
        public CodeErrorException(int pStatusCode, string pMessage = null, string pDetails = null) : base(pStatusCode, pMessage)
        {
            Details = pDetails;
        }

        public string Details { get; set; }
    }
}
