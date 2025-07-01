using Microsoft.AspNetCore.Mvc;
using ProductsClientHub.API.UseCases.Clients.Register;
using ProductsClientHub.Communication.Requests;
using ProductsClientHub.Communication.Responses;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ProductsClientHub.API.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RequestClientJson request)
    {
        RegisterClientUseCase useCase = new();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        return Ok(id);
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
}
