using Dummy.Core.Interfaces.Repository.Commands;
using Dummy.Core.Interfaces.Results;
using Dummy.Core.Models;
using Dummy.Core.Results;
using Dummy.CQS.Commands.User;
using Dummy.CQS.ViewModels;
using MediatR;

namespace Dummy.Application.Handlers.Commands;

public class CreateUserHandler(ICommandUserRepository repo) : IRequestHandler<CreateUserCommand, IOperationResult<UserViewModel>>
{
    private readonly ICommandUserRepository _userRepo = repo;

    public async Task<IOperationResult<UserViewModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = new UserModel(request.Name, request.Email, request.Document);

            // validate user info before repo insert

            await _userRepo.AddAsync(user);

            return OperationResult<UserViewModel>.CreateSuccess(new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Document = user.Document,
            });
        }
        catch (Exception e)
        {
            return OperationResult<UserViewModel>.CreateInternalServerError(e).AddMessage("There has been an error while trying to create user.");
        }
    }
}