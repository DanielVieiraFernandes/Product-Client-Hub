using Microsoft.AspNetCore.Mvc;
using ProductsClientHub.API.UseCases.Clients.Delete;
using ProductsClientHub.API.UseCases.Clients.GetAll;
using ProductsClientHub.API.UseCases.Clients.GetById;
using ProductsClientHub.API.UseCases.Clients.Register;
using ProductsClientHub.API.UseCases.Clients.Update;
using ProductsClientHub.Communication.Requests;
using ProductsClientHub.Communication.Responses;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ProductsClientHub.API.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RequestClientJson request)
    {
        RegisterClientUseCase useCase = new();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestClientJson request)
    {
        var useCase = new UpdateClientUseCase();

        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllClientsUseCase();

        var response = useCase.execute();

        if (response.Clients.Count == 0) return NoContent();

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status200OK)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetClientByIdUseCase();
        var response = useCase.Execute(id);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]

    public IActionResult Delete(Guid id)
    {
        var useCase = new DeleteClientUseCase();
        useCase.Execute(id);
        return Ok();
    }
}
