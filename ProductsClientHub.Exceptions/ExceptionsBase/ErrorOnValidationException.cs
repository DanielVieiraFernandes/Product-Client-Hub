using System.Net;

namespace ProductsClientHub.Exceptions.ExceptionsBase;
public class ErrorOnValidationException : ProductsClientHubException
{
    private readonly List<string> _errors; // com readonly podemos atribuir o valor apenas no construtor
    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErrors() => _errors;

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}
