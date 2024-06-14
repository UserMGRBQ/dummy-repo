using Dummy.Core.Interfaces.RabbitMqServices;
using Dummy.Core.Interfaces.Repositories.Commands;
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
            var userModel = new UserModel(request.Name, request.Email, request.Document);
            var validUser = userModel.IsValid();

            if (!validUser.IsSuccessResultType)
                return OperationResult<UserViewModel>.CreateInvalidInput().AddMessages(validUser.Messages);
            else
            {
                var entityUser = userModel.Sanitize();

                await _userQueue.Send(entityUser);
                await _userRepo.AddAsync(entityUser);
            }

            var viewModelUser = new UserViewModel(userModel);
            var response = viewModelUser.FormatToResponse();

            return OperationResult<UserViewModel>.CreateSuccess((UserViewModel)response);
        }
        catch (Exception e)
        {
            return OperationResult<UserViewModel>.CreateInternalServerError(e).AddMessage("There has been an error while trying to create user.");
        }
    }
}