using Dummy.Core.Interfaces.Repository.Base;
using Dummy.Core.Models;

namespace Dummy.Core.Interfaces.Repository;

public interface IUserRepository : IBaseRepository<UserModel, int>
{
}