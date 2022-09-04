using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Web.Services
{
    public static class MessagesApp
    {
        public static string GetMessageByStatusCode(int code)
        {
            string answer = "";
            if (code == 404)
            {
                answer = "La página solicitada no existe, por favor haga click en el botón Regresar o vuelva a iniciar sesión en el aplicativo, también puede cerrar y volver abrir el navegador.";
            }
            else 
            {
                answer = $"Se ha producido un inconveniente con el código {code} en el aplicativo.";
            }
            return answer;
        }
    }
}
