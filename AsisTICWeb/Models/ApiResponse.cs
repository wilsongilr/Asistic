using System.Net;

namespace AsisTICWeb.Models
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsExitoso { get; set; } = true;
        public List<string> ErrorMessage { get; set; }
        public object Resultado { get; set; }

    }
}
