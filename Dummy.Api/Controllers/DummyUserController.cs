using AutoMapper;
using Dummy.CQS.Commands.User;
using Dummy.CQS.Dtos;
using Dummy.CQS.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Api.Controllers;

[Route("api/dummy-user")]
[ApiController]
public class DummyUserController(IMapper mapper, IMediator mediator) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    [HttpGet, Route("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var query = new GetUserByIdQuery() { Id = id };
        var viewModel = await _mediator.Send(query);

        return StatusCode((int)viewModel.ResultType, viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserDto dto)
    {
        var command = _mapper.Map<UserDto, CreateUserCommand>(dto);
        var viewModel = await _mediator.Send(command);

        return Ok(viewModel);
    }
}