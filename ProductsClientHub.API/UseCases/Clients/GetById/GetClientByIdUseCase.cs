using Microsoft.EntityFrameworkCore;
using ProductsClientHub.API.Infra;
using ProductsClientHub.Communication.Responses;
using ProductsClientHub.Exceptions.ExceptionsBase;

namespace ProductsClientHub.API.UseCases.Clients.GetById;
public class GetClientByIdUseCase
{
    public ResponseClientJson Execute(Guid id)
    {
        var dbContext = new ProductsClientsHubDbContext();

        var client = dbContext
            .Clients
            .Include(client => client.Products)
            .FirstOrDefault(client => client.Id == id);


        if (client is null) throw new NotFoundException($"Client with id {id} not found.");

        return new ResponseClientJson
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Products = client.Products.Select(product => new ResponseShortProductJson
            {
                Id = product.Id,
                Name = product.Name,
            }).ToList()
        };
    }
}
