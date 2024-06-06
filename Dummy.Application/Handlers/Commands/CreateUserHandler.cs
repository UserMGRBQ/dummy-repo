using Dummy.Core.Interfaces.Repository;
using Dummy.Core.Models;
using Dummy.CQS.Commands.User;
using Dummy.CQS.ViewModels;
using MediatR;

namespace Dummy.Application.Handlers.Commands;

public class CreateUserHandler(IUserRepository repo) : IRequestHandler<CreateUserCommand, UserViewModel>
{
    private readonly IUserRepository _userRepo = repo;

    public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new UserModel(request.Name, request.Email, request.Document);

        await _userRepo.AddAsync(user);

        return new UserViewModel() 
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Document = user.Document
        };
    }
}