using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.ViewModel
{
    public class KeyValueParam
    {
        public string key1 { get; set; }
        public string target { get; set; }
    }
    public class KeyValueSelect : GenericKeyValueSelect
    {
        
    }
    public class StructKeyValueSelect
    {
        public string key { get; set; }
        public string target { get; set; }
        public List<KeyValueSelect> datasource { get; set; }
    }
    public abstract class GenericKeyValueSelect
    {
        public string key { get; set; }
        public string value { get; set; }
    }
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
            dataresult = default(T);
        }
    }
    public class RespuestaViewModel<T> : IDisposable
    {
        public RespuestaViewModel() 
        {
            this.Resultado = new ResultadoViewModel();
        }
        public T DataResult { get; set; }
        public ResultadoViewModel Resultado { get; set; }

        public void Dispose()
        {
            if (Resultado != null)
                Resultado.Dispose();
        }
    }
    public class ResultadoViewModel :IDisposable
    {
        public ResultadoViewModel() 
        {
            this.Ok = true;
            this.ErrorValidacion = false;
            this.Mensajes = new List<string>();
        }

        public bool Ok { get; set; }
        public string Titulo { get; set; }
        public int TipoMensaje { get; set; }
        public List<string> Mensajes { get; set; }
        public bool ErrorValidacion { get; set; }
        public int StatusCode { get; set; }

        public void Dispose()
        {
            this.Mensajes = null;
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
    public class MailSettings
    {
        public string? DisplayName { get; set; }
        public string? From { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public bool UseStartTls { get; set; }
    }
    public class MailData
    {
        // Receiver
        public List<string> To { get; }
        public List<string> Bcc { get; }

        public List<string> Cc { get; }

        // Sender
        public string? From { get; }

        public string? DisplayName { get; }

        public string? ReplyTo { get; }

        public string? ReplyToName { get; }

        // Content
        public string Subject { get; }

        public string? Body { get; }

        public MailData(List<string> to, string subject, string? body = null, string? from = null, string? displayName = null, string? replyTo = null, string? replyToName = null, List<string>? bcc = null, List<string>? cc = null)
        {
            // Receiver
            To = to;
            Bcc = bcc ?? new List<string>();
            Cc = cc ?? new List<string>();

            // Sender
            From = from;
            DisplayName = displayName;
            ReplyTo = replyTo;
            ReplyToName = replyToName;

            // Content
            Subject = subject;
            Body = body;
        }
    }
}
