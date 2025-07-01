using System.Net;

namespace ProductsClientHub.Exceptions.ExceptionsBase;
public abstract class ProductsClientHubException : SystemException
{
    public ProductsClientHubException(string errorMessage) : base(errorMessage)
    {

    }

    public abstract List<string> GetErrors();
    public abstract HttpStatusCode GetHttpStatusCode();
}
