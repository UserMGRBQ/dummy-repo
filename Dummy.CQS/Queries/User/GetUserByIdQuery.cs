using Dummy.CQS.ViewModels;
using MediatR;

namespace Dummy.CQS.Queries.User;

public class GetUserByIdQuery : IRequest<UserViewModel>
{
    public int Id { get; set; }
}