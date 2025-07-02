using ProductsClientHub.API.Entities;
using ProductsClientHub.API.Infra;
using ProductsClientHub.API.UseCases.Clients.SharedValidator;
using ProductsClientHub.Communication.Requests;
using ProductsClientHub.Exceptions.ExceptionsBase;

namespace ProductsClientHub.API.UseCases.Clients.Update;

public class UpdateClientUseCase
{
    public void Execute(Guid clientId, RequestClientJson request)
    {
        Validate(request);

        var dbContext = new ProductsClientsHubDbContext();

        var entity = dbContext.Clients.FirstOrDefault(client => client.Id == clientId);

        if (entity is null) throw new NotFoundException("Cliente não encontrado.");

        entity.Name = request.Name;
        entity.Email = request.Email;

        dbContext.Clients.Update(entity);
        dbContext.SaveChanges(); // não esquecer, após fazer a atualização, é necessário salvar as alterações no banco de dados.
    }

    private void Validate(RequestClientJson request)
    {
        var validator = new RequestClientValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
