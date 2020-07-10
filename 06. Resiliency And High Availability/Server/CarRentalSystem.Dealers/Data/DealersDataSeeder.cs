namespace CarRentalSystem.Dealers.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using CarRentalSystem.Services;
    using Models;

    public class DealersDataSeeder : IDataSeeder
    {
        private static IEnumerable<Category> GetData()
            => new List<Category>
            {
                new Category{ Name = "Economy", Description = "Economy cars are extremely comfortable for urban and non-urban condition because of its sizes and maneuverability as well as the best rental prices. We offer huge choice of economy cars available for rent at affordable prices. If our offices are not convenient for you, we will deliver a car directly to you address. Economy cars for rent are from the leading world manufacturers as: Toyota, Renault, Ford, Nissan and others. If you need economy car for rent in Bulgaria, you will find the best offers below. Choose the best economy car hire for your holiday!" },
                new Category{ Name = "Compact", Description = "We offer standard and compact cars for rent at affordable prices. Huge choice of cars for rent from compact and standard class. You can order delivery of the chosen compact car to exact address or renting directly from our office. The cars of our car fleet are from the leading cars manufactures. Between the options of the chosen car for rent are make, model, seats, coupe type, trunk capacity and others." },
                new Category{ Name = "Estate", Description = "We offer standard and compact cars for rent at affordable prices. Huge choice of cars for rent from compact and standard class. You can order delivery of the chosen compact car to exact address or renting directly from our office. The cars of our car fleet are from the leading cars manufactures. Between the options of the chosen car for rent are make, model, seats, coupe type, trunk capacity and others." },
                new Category{ Name = "Minivan", Description = "We offer 7 and 9-seats minivans and minibuses at affordable prices. Diversity of minivans and minibuses with various specifications – engine, year of production, gearbox type, seats, load capacity and etc. We serve deliveries of minivans and minibuses for rent directly to your address or some of our offices in the country. You can choose between the make and model of some of the leading minivan and minibus manufacturing as Тoyota, Ford, Renault and others. Choose us and you wil have reliable and safe partner in every case." },
                new Category{ Name = "SUV", Description = "SUV available for rent from us are comfortable and perfect for all road conditions Diversity of SUV models at very reasonable prices. You can order delivery of SUV directly to address chosen by you or rent from some of our offices in Bulgaria. The SUV vehicles available for hire from us are from the leading world manufacturers as: Volkswagen, Nissan, Renault and others. They offer wonderful combination of comfort and style. We offer affordable prices for hiring SUV. These car group has many extras and all cars are extremely comfortable for driving in urban and non-urban conditions." },
                new Category{ Name = "Cargo Vans", Description = "We offer cargo van rentals at affordable prices. You can book on our website with discount for online reservations. The system will automatically calculate the exact price of the chosen cargo van for rental and on the last step of the booking process there is information about all included in the price. We offer cargo vans for hire from the leading manufacturers as Toyota, Ford, Renault, Iveco and others. Best conditions for hiring a comfortable cargo vans." }
            };

        private readonly DealersDbContext db;

        public DealersDataSeeder(DealersDbContext db) => this.db = db;

        public void SeedData()
        {
            if (this.db.Categories.Any())
            {
                return;
            }

            foreach (var category in GetData())
            {
                this.db.Categories.Add(category);
            }

            this.db.SaveChanges();
        }
    }
}
