using AutoMapper;
using Dummy.CQS.Commands.User;
using Dummy.CQS.Dtos;
using Dummy.CQS.Objects;
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
    public async Task<IActionResult> Post([FromBody] UserObj obj)
    {
        var commandQueryBus =
            _mapper.Map<UserDto, CreateUserCommand>(
                _mapper.Map<UserObj, UserDto>(obj));

        var response = await _mediator.Send(commandQueryBus);

        return StatusCode((int)response.ResultType, response);
    }
}