using Dummy.Core.Interfaces.Repositories.Queries;
using Dummy.Core.Interfaces.Results;
using Dummy.Core.Results;
using Dummy.CQS.Queries.User;
using Dummy.CQS.ViewModels;
using MediatR;

namespace Dummy.Application.Handlers.Queries;

public class GetUserByIdHandler(IQueryUserRepository repo) : IRequestHandler<GetUserByIdQuery, IOperationResult<UserViewModel>>
{
    private readonly IQueryUserRepository _repo = repo;

    public async Task<IOperationResult<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var userModel = await _repo.GetByIdAsync(request.Id);

            if (userModel == null)
                return OperationResult<UserViewModel>.CreateInvalidInput().AddMessage("User not found!");

            return OperationResult<UserViewModel>.CreateSuccess(new UserViewModel(userModel));
        }
        catch (Exception e)
        {
            return OperationResult<UserViewModel>.CreateInternalServerError(e).AddMessage("There has been an error while trying to obtain the user.");
        }
    }
}