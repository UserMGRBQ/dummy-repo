using Dummy.CQS.Commands.User;
using Dummy.CQS.ViewModels;
using MediatR;

namespace Dummy.Application.Handlers.Commands;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserViewModel>
{
    public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5));

        return new UserViewModel();
    }
}