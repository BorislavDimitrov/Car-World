namespace CarWorld.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CarWorld.Data.Models;

    public class MakesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Makes.Any())
            {
                return;
            }

            await dbContext.Makes.AddAsync(new Make { Name = "Audi" });
            await dbContext.Makes.AddAsync(new Make { Name = "BMW" });
            await dbContext.Makes.AddAsync(new Make { Name = "VW" });
            await dbContext.Makes.AddAsync(new Make { Name = "Mercedes-Benz" });
            await dbContext.Makes.AddAsync(new Make { Name = "Opel" });
            await dbContext.Makes.AddAsync(new Make { Name = "Peugeot" });
            await dbContext.Makes.AddAsync(new Make { Name = "Renault" });
            await dbContext.Makes.AddAsync(new Make { Name = "Toyota" });
            await dbContext.Makes.AddAsync(new Make { Name = "Ford" });
            await dbContext.Makes.AddAsync(new Make { Name = "Citroen" });
            await dbContext.Makes.AddAsync(new Make { Name = "Honda" });
            await dbContext.Makes.AddAsync(new Make { Name = "Mazda" });
            await dbContext.Makes.AddAsync(new Make { Name = "Nissan" });
            await dbContext.Makes.AddAsync(new Make { Name = "Fiat" });
            await dbContext.Makes.AddAsync(new Make { Name = "Seat" });
            await dbContext.Makes.AddAsync(new Make { Name = "Skoda" });
            await dbContext.Makes.AddAsync(new Make { Name = "Mitsubishi" });
            await dbContext.Makes.AddAsync(new Make { Name = "Hyundai" });
            await dbContext.Makes.AddAsync(new Make { Name = "Kia" });
            await dbContext.Makes.AddAsync(new Make { Name = "Suzuki" });
            await dbContext.Makes.AddAsync(new Make { Name = "Volvo" });
            await dbContext.Makes.AddAsync(new Make { Name = "Subaru" });
            await dbContext.Makes.AddAsync(new Make { Name = "Alfa Romeo" });
            await dbContext.Makes.AddAsync(new Make { Name = "Chevrolet" });
            await dbContext.Makes.AddAsync(new Make { Name = "Dacia" });
            await dbContext.Makes.AddAsync(new Make { Name = "Land Rover" });
            await dbContext.Makes.AddAsync(new Make { Name = "Jeep" });
            await dbContext.Makes.AddAsync(new Make { Name = "Mini" });
            await dbContext.Makes.AddAsync(new Make { Name = "Lancia" });
            await dbContext.Makes.AddAsync(new Make { Name = "Chrysler" });
            await dbContext.Makes.AddAsync(new Make { Name = "Jaguar" });
            await dbContext.Makes.AddAsync(new Make { Name = "Smart" });
            await dbContext.Makes.AddAsync(new Make { Name = "Porsche" });
            await dbContext.Makes.AddAsync(new Make { Name = "Rover" });
            await dbContext.Makes.AddAsync(new Make { Name = "Saab" });
            await dbContext.Makes.AddAsync(new Make { Name = "Lexus" });
            await dbContext.Makes.AddAsync(new Make { Name = "Lada" });
            await dbContext.Makes.AddAsync(new Make { Name = "Infinity" });
            await dbContext.Makes.AddAsync(new Make { Name = "Dodge" });
            await dbContext.Makes.AddAsync(new Make { Name = "Isuzu" });
            await dbContext.Makes.AddAsync(new Make { Name = "Tesla" });
            await dbContext.Makes.AddAsync(new Make { Name = "Range Rover" });
            await dbContext.Makes.AddAsync(new Make { Name = "Moskvich" });
            await dbContext.Makes.AddAsync(new Make { Name = "Cadillac" });
            await dbContext.Makes.AddAsync(new Make { Name = "Trabant" });
            await dbContext.Makes.AddAsync(new Make { Name = "Hummer" });
            await dbContext.Makes.AddAsync(new Make { Name = "Maserati" });
            await dbContext.Makes.AddAsync(new Make { Name = "Bentley" });
            await dbContext.Makes.AddAsync(new Make { Name = "Iveco" });
            await dbContext.Makes.AddAsync(new Make { Name = "Rolls Royce" });
            await dbContext.Makes.AddAsync(new Make { Name = "Ferrari" });
            await dbContext.Makes.AddAsync(new Make { Name = "Buick" });
            await dbContext.Makes.AddAsync(new Make { Name = "Lamborghini" });
            await dbContext.Makes.AddAsync(new Make { Name = "Maybach" });
            await dbContext.Makes.AddAsync(new Make { Name = "Aston Martin" });            
            await dbContext.SaveChangesAsync();
        }
    }
}
