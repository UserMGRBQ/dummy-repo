using Dummy.Core.Models;

namespace Dummy.Core.Interfaces.RabbitMqServices;

public interface IUserQueue
{
    Task Send(UserModel model);
}