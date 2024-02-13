using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGlobalError.GlobalExceptionHandler
{
    public class ApiResponse<T>
    {
        //A propriedade Data que mantém os dados retornados do servidor;
        public T Data { get; set; }
        //A propriedade booleana Succeded que indica se a requisição foi feita com sucesso;
        public bool Succeeded { get; set; }
        //A propriedade Message que pode conter qualquer exceção ou mensagem de informação;
        public string Message { get; set; }

        //Os métodos Fail e Success vão tratar os casos de erro e de sucesso;
        public static ApiResponse<T> Fail(string errorMessage)
        {
            return new ApiResponse<T> { Succeeded = false, Message = errorMessage };
        }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T> { Succeeded = true, Data = data };
        }
    }
}
