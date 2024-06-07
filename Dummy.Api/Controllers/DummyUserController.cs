using AutoMapper;
using Dummy.CQS.Commands.User;
using Dummy.CQS.Dtos;
using Dummy.CQS.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DummyUserController(IMapper mapper, IMediator mediator) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        var query = new GetUserByIdQuery() { Id = id };
        var viewModel = await _mediator.Send(query);

        return Ok(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserDto dto)
    {
        var command = _mapper.Map<UserDto, CreateUserCommand>(dto);
        var viewModel = await _mediator.Send(command);

        return Ok(viewModel);
    }

    //// PUT api/<DummyUserController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<DummyUserController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
