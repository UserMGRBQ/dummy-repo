using Dummy.Core.Interfaces.Results;
using Dummy.CQS.ViewModels;
using MediatR;

namespace Dummy.CQS.Commands.User;

public class CreateUserCommand : IRequest<IOperationResult<UserViewModel>>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Document { get; set; }
}