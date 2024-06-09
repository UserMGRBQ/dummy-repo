using Dummy.Core.Interfaces.RabbitMqServices;
using Dummy.Core.Models;
using MassTransit;

namespace Dummy.Services.RabbitMqServices;

public class UserQueue(IPublishEndpoint endpoint) : IConsumer<UserModel>, IUserQueue
{
    private readonly IPublishEndpoint _endpoint = endpoint;

    public async Task Consume(ConsumeContext<UserModel> context)
    {
        var model = context.Message;

        await Task.CompletedTask;
    }

    public async Task Send(UserModel model)
    {
        await _endpoint.Publish(model);
    }
}