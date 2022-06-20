using System.Collections.Generic;


namespace eMAS.TerrenosComodatos.Domain.DTOs
{
    public class ResultadoViewJson
    {
        public bool cancontinue { get; set; }
        public string messagetype { get; set; }
        public string message { get; set; }
        public string content { get; set; }
        public ResultadoViewJson()
        {
            this.cancontinue = false;
            this.messagetype = "ADVERTENCIA";
            this.message = string.Empty;
            this.message = string.Empty;
        }
        public ResultadoViewJson(bool _cancontinue, string _messagetype, string _message, string _content)
        {
            this.cancontinue = _cancontinue;
            this.messagetype = _messagetype;
            this.message = _message;
            this.content = _content;
        }
        public void SetResultadoViewJson(bool _cancontinue, string _messagetype, string _message, string _content = "")
        {
            this.cancontinue = _cancontinue;
            this.messagetype = _messagetype;
            this.message = _message;
            this.content = _content;
        }
    }
    public class DataPagineada<T> where T : class
    {
        public IEnumerable<T> data { get; set; }
        public int totalpaginas { get; set; }
        public int paginaactual { get; set; }
        public string resultcontainer { get; set; }
    }
    /// <summary>
    /// Objeto de transferencia de resultados y mensajes entre capas
    /// Cada capa maneja su propio código
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultadoDTO<T>
    {
        public T dataresult { get; set; }
        public List<Mensaje> mensajes { get; set; }
        public string mensaje { get; set; }
        public string tipo { get; set; }
        public ResultadoDTO()
        {
            mensajes = new List<Mensaje>();
            this.tipo = "EXITO";
            this.mensaje = "OK";
        }
    }
    public class Mensaje 
    {
        public string codigo { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
    }
    public class AppSettings
    {
        public const string Titulo = "ConfApp";
        public string RutaBase { get; set; }
    }
}
