namespace CarWorld.Services
{
    using AutoMapper;
    using CarWorld.Common;
    using CarWorld.Data.Common.Repositories;
    using CarWorld.Data.Models;
    using CarWorld.Services.Contracts;
    using CarWorld.Services.Mapping;
    using CarWorld.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Processing;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<Car> carsRepo;
        private readonly IDeletableEntityRepository<Picture> picturesRepo;
        private readonly IMapper mapper;

        public CarsService(IDeletableEntityRepository<Car> carsRepo,
            IDeletableEntityRepository<Picture> picturesRepo)
        {
            this.carsRepo = carsRepo;
            this.picturesRepo = picturesRepo;
            this.mapper = AutoMapperConfig.MapperInstance;
        }

        public async Task CreateCarAsync(CreateCarInputModel model, string wwwrootPath)
        {

            var car = mapper.Map<Car>(model);

            string thumbnailPicturePath = String.Empty;

            if (model.ThumbnailPicture != null)
            {
                thumbnailPicturePath = ResizeThumbnailPicture(model.ThumbnailPicture, wwwrootPath);
            }
            else
            {
                thumbnailPicturePath = GlobalConstants.DefaultCarImage;
            }

            car.ThumbnailPicturePath = thumbnailPicturePath;

            List<Picture> pictures = new List<Picture>();

            if (model.CarPictures.Count > 0)
            {
                pictures = await ResizeCarPicturesAsync(model.CarPictures, wwwrootPath);
            }
            else
            {
                var newImage = new Picture()
                {
                    CarId = car.Id,
                    Car = car,
                };

                newImage.PicturePath = GlobalConstants.DefaultCarImage;

                await picturesRepo.AddAsync(newImage);
            }

            car.Pictures.AddRange(pictures);

            await carsRepo.AddAsync(car);

            await carsRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetUserCarsAsync<T>(string userId, string search, int? makeId, int? modelId, int? regionId, string orderBy)
        {
            var cars = carsRepo.AllAsNoTracking()
                .Where(x => x.CreatorId == userId)
                .AsQueryable();

            if (search != null)
            {
                cars = cars.Where(x => x.Title.Contains(search)).AsQueryable();
            }

            if (makeId != null)
            {
                cars = cars.Where(x => x.MakeId == makeId).AsQueryable();
            }

            if (modelId != null)
            {
                cars = cars.Where(x => x.ModelId == modelId).AsQueryable();
            }

            if (regionId != null)
            {
                cars = cars.Where(x => x.RegionId == regionId).AsQueryable();
            }

            if (modelId != null)
            {
                cars = cars.Where(x => x.ModelId == modelId).AsQueryable();
            }

            switch (orderBy)
            {
                case "DateAsc":
                    cars = cars.OrderBy(x => x.CreateDate);
                    break;
                case "PriceDesc":
                    cars = cars.OrderByDescending(x => x.Price);
                    break;
                case "RateAsc":
                    cars = cars.OrderBy(x => x.Price);
                    break;
                default:
                    cars = cars.OrderByDescending(x => x.CreateDate);
                    break;
            }

            return await cars 
                .To<T>()
                .ToListAsync();
        }

        public async Task<T> GetCarByIdAsync<T>(int carId)
        {
            return await carsRepo.AllAsNoTracking()
                .Where(x => x.Id == carId)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task EditCarAsync(EditCarInputModel model, string wwwrootPath)
        {
            var car = carsRepo.All()
                .FirstOrDefault(x => x.Id == model.Id);

            car.MakeId = model.MakeId;
            car.ModelId = model.ModelId;
            car.Title = model.Title;
            car.HorsePower = model.HorsePower;
            car.Price = model.Price;
            car.CarType = model.CarType;
            car.HandDrive = model.HandDrive;
            car.EmissionClass = model.EmissionClass;
            car.Transmission = model.Transmission;
            car.Condition = model.Condition;
            car.FuelType = model.FuelType;
            car.DoorsCount = model.DoorsCount;
            car.SeatsCount = model.SeatsCount;
            car.RegionId = model.RegionId;
            car.TankFuel = model.TankFuel;
            car.Color = model.Color;
            car.CreationYear = model.CreationYear;
            car.Mileage = model.Mileage;
            car.CubicCapacity = model.CubicCapacity;
            car.Description = model.Description;
            car.PhoneNumber = model.PhoneNumber;
            car.City = model.City;

            if (model.ThumbnailImage != null)
            {
                car.ThumbnailPicturePath = ResizeThumbnailPicture(model.ThumbnailImage, wwwrootPath);
            }
            List<Picture> pictures = new List<Picture>();

            if (model.Images.Count > 0)
            {
                var carPics = picturesRepo.All()
                    .Where(x => x.CarId == car.Id)
                    .ToList();

                foreach (var picture in carPics)
                {
                    picturesRepo.HardDelete(picture);
                }

                pictures = await ResizeCarPicturesAsync(model.Images, wwwrootPath);
                car.Pictures.AddRange(pictures);
            }

            await carsRepo.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int carId)
        {
            var car = carsRepo.All()
               .FirstOrDefault(x => x.Id == carId);

            carsRepo.Delete(car);

            await carsRepo.SaveChangesAsync();
        }

        public async Task<DetailsCarViewModel> GetCarDetailsByIdAsync(int carId)
        {
            return await carsRepo.AllWithDeleted()
                .Where(x => x.Id == carId)
                .To<DetailsCarViewModel>()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetCarsForAdminAsync<T>(string search, int? makeId, int? modelId, int? regionId, string orderBy)
        {                    
            var cars = carsRepo.AllWithDeleted()
                .AsQueryable();

            if (search != null)
            {
                cars = cars.Where(x => x.Title.Contains(search)).AsQueryable();
            }

            if (makeId != null)
            {
                cars = cars.Where(x => x.MakeId == makeId).AsQueryable();
            }

            if (modelId != null)
            {
                cars = cars.Where(x => x.ModelId == modelId).AsQueryable();
            }

            if (regionId != null)
            {
                cars = cars.Where(x => x.RegionId == regionId).AsQueryable();
            }

            if (modelId != null)
            {
                cars = cars.Where(x => x.ModelId == modelId).AsQueryable();
            }

            switch (orderBy)
            {
                case "DateAsc":
                    cars = cars.OrderBy(x => x.CreateDate);
                    break;
                case "PriceDesc":
                    cars = cars.OrderByDescending(x => x.Price);
                    break;
                case "PriceAsc":
                    cars = cars.OrderBy(x => x.Price);
                    break;
                default:
                    cars = cars.OrderByDescending(x => x.CreateDate);
                    break;
            }

            return await cars
                .To<T>()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetSearchCarsAsync<T>(string search, int? makeId, int? modelId, int? regionId, string orderBy)
        {
            var cars = carsRepo.All()
                .AsQueryable();

            if (search != null)
            {
                cars = cars.Where(x => x.Title.Contains(search)).AsQueryable();
            }

            if (makeId != null)
            {
                cars = cars.Where(x => x.MakeId == makeId).AsQueryable();
            }

            if (modelId != null)
            {
                cars = cars.Where(x => x.ModelId == modelId).AsQueryable();
            }

            if (regionId != null)
            {
                cars = cars.Where(x => x.RegionId == regionId).AsQueryable();
            }

            if (modelId != null)
            {
                cars = cars.Where(x => x.ModelId == modelId).AsQueryable();
            }

            switch (orderBy)
            {
                case "DateAsc":
                    cars = cars.OrderBy(x => x.CreateDate);
                    break;
                case "PriceDesc":
                    cars = cars.OrderByDescending(x => x.Price);
                    break;
                case "PriceAsc":
                    cars = cars.OrderBy(x => x.Price);
                    break;
                default:
                    cars = cars.OrderByDescending(x => x.CreateDate);
                    break;
            }

            return await cars
                .To<T>()
                .ToListAsync();
        }

        public int GetCount()
        {
            return carsRepo.AllAsNoTracking()
                .Count();
        }

        public async Task<bool> IsCarExistingForUserByIdAsync(int id)
            => await carsRepo.All()
            .FirstOrDefaultAsync(x => x.Id == id) == null ? false : true;

        public async Task<bool> IsCarExistingForAdminByIdAsync(int id)
            => await carsRepo.AllWithDeleted()
            .FirstOrDefaultAsync(x => x.Id == id) == null ? false : true;

        public async Task<bool> IsCarMadeByUserAsync(int carId, string userId)
            => await carsRepo.All()
            .FirstOrDefaultAsync(x => x.Id == carId && x.CreatorId == userId) == null ? false : true;

        public async Task<bool> IsCarDeleted(int carId)
            => await carsRepo.AllWithDeleted()
            .FirstOrDefaultAsync(x => x.Id == carId && x.IsDeleted == true) == null ? false : true;

        private string ResizeThumbnailPicture(IFormFile thumbnailPic, string wwwrootPath)
        {
            var extension = Path.GetExtension(thumbnailPic.FileName);

            string picturePath = "/img/cars/" + Guid.NewGuid().ToString() + extension;

            using var pic = Image.Load(thumbnailPic.OpenReadStream());
            pic.Mutate(x => x.Resize(300, 300));
            pic.Save(wwwrootPath + picturePath);

            return picturePath;
        }

        private async Task<List<Picture>> ResizeCarPicturesAsync(List<IFormFile> carPics, string wwwrootPath)
        {
            List<Picture> pictures = new List<Picture>();

            foreach (var picture in carPics)
            {
                var newImage = new Picture();

                string picturePath = "/img/cars/" + newImage.Id + ".jpeg";
                newImage.PicturePath = picturePath;

                using var image = Image.Load(picture.OpenReadStream());
                image.Mutate(x => x.Resize(400, 400));
                image.Save(wwwrootPath + picturePath);

                pictures.Add(newImage);
            }

            return pictures;
        }
    }
}
