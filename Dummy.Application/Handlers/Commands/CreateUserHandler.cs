using Dummy.Core.Interfaces.RabbitMqServices;
using Dummy.Core.Interfaces.Repository.Commands;
using Dummy.Core.Interfaces.Results;
using Dummy.Core.Models;
using Dummy.Core.Results;
using Dummy.CQS.Commands.User;
using Dummy.CQS.ViewModels;
using MediatR;

namespace Dummy.Application.Handlers.Commands;

public class CreateUserHandler(ICommandUserRepository repo, IUserQueue userQueue) : IRequestHandler<CreateUserCommand, IOperationResult<UserViewModel>>
{
    private readonly ICommandUserRepository _userRepo = repo;
    private readonly IUserQueue _userQueue = userQueue;

    public async Task<IOperationResult<UserViewModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = new UserModel(request.Name, request.Email, request.Document);
            var validUser = user.IsValidUser();

            if (!validUser.IsSuccessResultType)
                return OperationResult<UserViewModel>.CreateInvalidInput().AddMessages(validUser.Messages);

            await _userQueue.Send(user);
            await _userRepo.AddAsync(user);

            return OperationResult<UserViewModel>.CreateSuccess(new UserViewModel(user));
        }
        catch (Exception e)
        {
            return OperationResult<UserViewModel>.CreateInternalServerError(e).AddMessage("There has been an error while trying to create user.");
        }
    }
}