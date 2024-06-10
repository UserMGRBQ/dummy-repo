using Dummy.Core.Interfaces.RabbitMqServices;
using Dummy.Core.Models;
using MassTransit;

namespace Dummy.Services.RabbitMqServices;

public class UserQueue(IPublishEndpoint endpoint) : IUserQueue
{
    private readonly IPublishEndpoint _endpoint = endpoint;

    public async Task Send(UserModel model)
    {
        await _endpoint.Publish(model);
    }
}