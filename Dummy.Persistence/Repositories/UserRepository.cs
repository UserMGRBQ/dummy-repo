using Dummy.Core.Interfaces.Repository;
using Dummy.Core.Models;
using Dummy.Persistence.Contexts;
using Dummy.Persistence.Repositories.Base;

namespace Dummy.Persistence.Repositories;

public class UserRepository(DummyContext context) : BaseRepository<UserModel, int>(context), IUserRepository
{
}