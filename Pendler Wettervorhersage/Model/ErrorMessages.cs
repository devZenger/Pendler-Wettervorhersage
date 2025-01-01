using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    public class ErrorMessages
    {
        public List<ErrorMessage> MessageErrors { get; set; } //= new List<ErrorMessage>();

        public ErrorMessages()
        {
            MessageErrors = new List<ErrorMessage>();
            MessageErrors.Add(new ErrorMessage(false, "Die Uhrzeitangabe im ersten Eingabefeld vom Heimatort ist falsch"));
            MessageErrors.Add(new ErrorMessage(false, "Die Uhrzeitangabe im zweiten Eingabefeld vom Heimatort ist falsch"));
            MessageErrors.Add(new ErrorMessage(false, "Die Uhrzeitangabe im ersten Eingabefeld vom Arbeitsplatz ist falsch"));
            MessageErrors.Add(new ErrorMessage(false, "Die Uhrzeitangabe im zweiten Eingabefeld vom Arbeitsplatz ist falsch"));
        }
        
    }

    public class ErrorMessage
    {
        public bool IsError { get; set; }
        public string Message { get; set; } = string.Empty;

        
        public ErrorMessage(bool isError, string message)
        {
            IsError = isError;
            Message = message;

        }
        /*
        public ErrorMessage(bool isError)
        {
            IsError = isError;
        }*/
    }
}
