using ProductsClientHub.API.Entities;
using ProductsClientHub.API.Infra;
using ProductsClientHub.API.UseCases.Products.SharedValidator;
using ProductsClientHub.Communication.Requests;
using ProductsClientHub.Communication.Responses;
using ProductsClientHub.Exceptions.ExceptionsBase;

namespace ProductsClientHub.API.UseCases.Products.Register;

public class RegisterProductUseCase
{
    public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
    {
        var dbContext = new ProductsClientsHubDbContext();

        Validate(dbContext, clientId, request);

        var entity = new Product
        {
            Name = request.Name,
            Brand = request.Brand,
            Price = request.Price,
            ClientId = clientId
        };

        dbContext.Products.Add(entity);
        dbContext.SaveChanges();

        return new ResponseShortProductJson
        {
            Id = entity.Id,
            Name = entity.Name,
        };

    }
    private void Validate(ProductsClientsHubDbContext dbContext, Guid clientId, RequestProductJson request)
    {
        var clientExist = dbContext.Clients.Any(client => client.Id == clientId);
        if (!clientExist)
        {
            throw new NotFoundException("Cliente não existe.");
        }


        var validator = new RequestProductValidator();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}
