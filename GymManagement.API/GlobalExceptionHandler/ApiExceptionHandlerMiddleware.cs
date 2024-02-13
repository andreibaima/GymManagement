using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiGlobalError.GlobalExceptionHandler
{
    /* O componente de middleware customizado é como qualquer outra classe.NET com o método Invoke(), 
    e para executar o próximo middleware em uma sequência, ele deve ter o parâmetro do tipo 
    RequestDelegate no construtor. */
    public class ApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        //O RequestDelegate denota uma conclusão de solicitação HTTP.
        public ApiExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                /* Um bloco try-catch simples sobre o delegado de solicitação indica que sempre que houver uma 
                 * exceção de qualquer tipo no pipeline para a solicitação atual, o controle vai para o bloco catch.
                 * Nesse middleware, o bloco Catch tem todas as vantagens. */
                await _next(context);
            }
            catch (Exception error)
            {
                /* O bloco catch captura todas as exceções onde as nossas exceções personalizadas são 
                 * derivadas da classe base Exception. */
                var response = context.Response;
                response.ContentType = "application/json";

                //Criamos um modelo ApiResponse a partir da mensagem de erro usando o método Fail que criado.
                var responseModel = ApiResponse<string>.Fail(error.Message);

                //Caso a exceção detectada seja do tipo ApiException, o código de status é definido como BadRequest. As outras exceções também são tratadas de maneira semelhante.
                switch (error)
                {
                    case ApiException e:
                        //  erro customizado
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // erro not found
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // erro não tratado
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                //Ao final o modelo de resposta API criado é serializado(JsonSerializer) e enviado como uma response.
                await response.WriteAsync(result);
            }
        }
    }
}
