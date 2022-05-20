namespace CarWorld.Web.ViewModels.Cars
{
    using CarWorld.Data.Models;
    using CarWorld.Services.Mapping;

    public class CarsInListViewModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public int CreationYear { get; set; }

        public int Price { get; set; }

        public string ThumbnailPicturePath { get; set; }
    }
}
