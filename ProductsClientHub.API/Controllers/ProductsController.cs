using Microsoft.AspNetCore.Mvc;
using ProductsClientHub.API.UseCases.Products.Delete;
using ProductsClientHub.API.UseCases.Products.Register;
using ProductsClientHub.Communication.Requests;
using ProductsClientHub.Communication.Responses;

namespace ProductsClientHub.API.Controllers;
[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost]
    [Route("{clientId}")]
    [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)]
    public IActionResult Register([FromRoute] Guid clientId, [FromBody] RequestProductJson request)
    {
        RegisterProductUseCase useCase = new();

        var response = useCase.Execute(clientId, request);

        return Created(string.Empty, response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var useCase = new DeleteProductUseCase();

        useCase.Execute(id);

        return NoContent();
    }
}
