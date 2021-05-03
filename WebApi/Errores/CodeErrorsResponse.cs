using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Errores
{
    public class CodeErrorsResponse
    {
        public CodeErrorsResponse(int pStatusCode, string pMessage = null)
        {
            statusCode = pStatusCode;
            Message = pMessage ?? GetDefaultMessageStatusCode(pStatusCode);
        }
        

        public int statusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageStatusCode(int pStatusCode)
        {
            return statusCode switch
            {
                400 => "El request enviado tiene errores.",
                401 => "No tiene autorización para este recurso.",
                404 => "El item no existe.",
                500 => "Se produjeron errores en el servidor.",
                _ => null

            };
        }
    }
}
