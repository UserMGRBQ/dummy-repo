using Dummy.Core.Interfaces.Repository;
using Dummy.Core.Interfaces.Repository.Queries;
using Dummy.CQS.Queries.User;
using Dummy.CQS.ViewModels;
using MediatR;

namespace Dummy.Application.Handlers.Queries;

public class GetUserByIdHandler(IQueryUserRepository repo) : IRequestHandler<GetUserByIdQuery, UserViewModel>
{
    private readonly IQueryUserRepository _repo = repo;

    public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = _repo.GetByIdAsync(request.Id);

        //validate user
        //do something else

        var userFound = await user;

        return new UserViewModel()
        {
            Id = userFound.Id,
            Name = userFound.Name,
            Email = userFound.Email,
            Document = userFound.Document,
        };
    }
}