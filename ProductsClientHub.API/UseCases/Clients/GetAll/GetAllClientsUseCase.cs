using ProductsClientHub.API.Infra;
using ProductsClientHub.Communication.Responses;

namespace ProductsClientHub.API.UseCases.Clients.GetAll;
public class GetAllClientsUseCase
{
    public ResponseAllClientsJson execute()
    {
        var dbContext = new ProductsClientsHubDbContext();

        var clients = dbContext.Clients.ToList().Select(client => new ResponseShortClientJson
        {
            Id = client.Id,
            Name = client.Name,
        }).ToList();

        return new ResponseAllClientsJson
        {
            Clients = clients
        };
    }
}
