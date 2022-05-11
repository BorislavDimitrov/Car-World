namespace CarWorld.Web.ViewModels.Administration.Cars
{
    using System;

    using CarWorld.Data.Models.Enums;

    public class CarsListViewModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Title { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Price { get; set; }

        public string UserName { get; set; }

        public int HorsePower { get; set; }

        public CarType CarType { get; set; }

        public string City { get; set; }

        public string Color { get; set; }

        public int Mileage { get; set; }

        public string CreateDate { get; set; }
    }
}
