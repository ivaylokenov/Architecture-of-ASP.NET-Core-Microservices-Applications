namespace CarRentalSystem.Schedule.Messages
{
    using System.Threading.Tasks;
    using CarRentalSystem.Messages.Dealers;
    using MassTransit;
    using Services;

    public class CarAdUpdatedConsumer : IConsumer<CarAdUpdatedMessage>
    {
        private readonly IRentedCarService rentedCars;

        public CarAdUpdatedConsumer(IRentedCarService rentedCars) 
            => this.rentedCars = rentedCars;

        public async Task Consume(ConsumeContext<CarAdUpdatedMessage> context)
            => await this.rentedCars.UpdateInformation(
                context.Message.CarAdId,
                context.Message.Manufacturer,
                context.Message.Model);
    }
}
