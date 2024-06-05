using Dummy.CQS.ViewModels;
using MediatR;

namespace Dummy.CQS.Commands.User;

public class CreateUserCommand : IRequest<UserViewModel>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Document { get; set; }
}