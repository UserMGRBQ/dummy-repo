using Dummy.Core.Interfaces.Repository.Base;
using Dummy.Core.Models;

namespace Dummy.Core.Interfaces.Repository.Commands;

public interface ICommandUserRepository : IBaseCommandRepository<UserModel, int>
{
}