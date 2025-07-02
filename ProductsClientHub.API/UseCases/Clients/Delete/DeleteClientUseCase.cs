using ProductsClientHub.API.Infra;
using ProductsClientHub.Exceptions.ExceptionsBase;

namespace ProductsClientHub.API.UseCases.Clients.Delete;

public class DeleteClientUseCase
{
    public void Execute(Guid id)
    {
        var dbContext = new ProductsClientsHubDbContext();
        var entity = dbContext.Clients.FirstOrDefault(client => client.Id == id);
        if (entity is null) throw new NotFoundException("Cliente não encontrado.");
        dbContext.Clients.Remove(entity);
        dbContext.SaveChanges();
    }
}
