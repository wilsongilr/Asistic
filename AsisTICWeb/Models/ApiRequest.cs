using System.Security.Principal;
using static AsisTIC_Utilidad.DS;

namespace AsisTICWeb.Models
{
    public class ApiRequest
    {
        public APITipo APITipo { get; set; } = APITipo.GET;
        public string Url { get; set; }
        public Object Datos { get; set; }

    }
}
