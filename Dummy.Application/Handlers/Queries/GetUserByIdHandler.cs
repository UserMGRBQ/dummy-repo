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
        // validate if request.Id is a valid id

        var user = await _repo.GetByIdAsync(request.Id);

        if (user == null)
            return OperationResult<UserViewModel>.CreateInvalidInput().AddMessage("User not found!");

        return OperationResult<UserViewModel>.CreateSuccess(new UserViewModel(user));
    }
}