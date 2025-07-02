using System.Net;

namespace ProductsClientHub.Exceptions.ExceptionsBase;
public class NotFoundException : ProductsClientHubException
{

    public NotFoundException(string errorMessage) : base(errorMessage)
    {
    }

    public override List<string> GetErrors() => [Message];

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}
