using Dummy.Core.Interfaces.Repository.Base;
using Dummy.Core.Models;

namespace Dummy.Core.Interfaces.Repository.Queries;

public interface IQueryUserRepository : IBaseQueryRepository<UserModel, int>
{
}