using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductsClientHub.Exceptions.ExceptionsBase;
using ProductsClientHub.Communication.Responses;
namespace ProductsClientHub.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is ProductsClientHubException productsClientHubException)
        {
            context.HttpContext.Response.StatusCode = (int)productsClientHubException.GetHttpStatusCode(); // convertemos para int,
                                                                                                           // pois vem como Enum

            context.Result = new ObjectResult(new ResponseErrorMessagesJson(productsClientHubException.GetErrors()));

        } else
        {
            ThrowUnknowError(context);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = 500;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson("ERRO DESCONHECIDO"));
    }
}
