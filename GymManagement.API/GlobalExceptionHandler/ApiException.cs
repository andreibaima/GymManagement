using System;
using System.Globalization;

namespace ApiGlobalError.GlobalExceptionHandler
{
    //Esta classe herda de Exception e define 3 construtores para o tratamento de exceções.
    public class ApiException : Exception
    {
        public ApiException() : base()
        {
        }
        public ApiException(string message) : base(message)
        {
        }
        public ApiException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
