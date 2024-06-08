using Dummy.Core.Interfaces.Results;
using Dummy.CQS.ViewModels;
using MediatR;

namespace Dummy.CQS.Queries.User;

public class GetUserByIdQuery : IRequest<IOperationResult<UserViewModel>>
{
    public int Id { get; set; }
}