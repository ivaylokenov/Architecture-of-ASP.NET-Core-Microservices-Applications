namespace CarRentalSystem.Notifications.Messages
{
    using System.Threading.Tasks;
    using CarRentalSystem.Messages.Dealers;
    using Hub;
    using MassTransit;
    using Microsoft.AspNetCore.SignalR;

    using static Constants;

    public class CarAdCreatedConsumer : IConsumer<CarAdCreatedMessage>
    {
        private readonly IHubContext<NotificationsHub> hub;

        public CarAdCreatedConsumer(IHubContext<NotificationsHub> hub) 
            => this.hub = hub;

        public async Task Consume(ConsumeContext<CarAdCreatedMessage> context) 
            => await this.hub
                .Clients
                .Groups(AuthenticatedUsersGroup)
                .SendAsync(ReceiveNotificationEndpoint, context.Message);
    }
}
