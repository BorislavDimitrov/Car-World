namespace CarWorld.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using CarWorld.Common;
    using CarWorld.Data.Common.Repositories;
    using CarWorld.Data.Models;
    using CarWorld.Services.Contracts;
    using CarWorld.Services.Mapping;
    using CarWorld.Web.ViewModels.Administration.Cars;
    using CarWorld.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Processing;

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
            //var car = new Car()
            //{
            //    CreatorId = model.UserId,
            //    MakeId = model.MakeId,
            //    RegionId = model.RegionId,
            //    ModelId = model.ModelId,
            //    CarType = model.CarType,
            //    Color = model.Color,
            //    Condition = model.Condition,
            //    CreationYear = model.CreationYear,
            //    Description = model.Description,
            //    FuelType = model.FuelType,
            //    DoorsCount = model.DoorsCount,
            //    CubicCapacity = model.CubicCapacity,
            //    HandDrive = model.HandDrive,
            //    EmissionClass = model.EmissionClass,
            //    Mileage = model.Mileage,
            //    SeatsCount = model.SeatsCount,
            //    TankFuel = model.TankFuel,
            //    Transmission = model.Transmission,
            //    Title = model.Title,
            //    HorsePower = model.HorsePower,
            //    Price = model.Price,
            //    PhoneNumber = model.PhoneNumber,
            //    City = model.City,
            //};

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

            if (model.Pictures.Count > 0)
            {
                pictures = await ResizeCarPicturesAsync(model.Pictures, wwwrootPath);
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

        public async Task<IEnumerable<UserCarsInListViewModel>> GetUserCarsAsync(string userId)
        {
            return await carsRepo.AllAsNoTracking()
                .Where(x => x.CreatorId == userId)
                .OrderByDescending(x => x.Id)
                .To<UserCarsInListViewModel>()
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

        public async Task<DetailsCarViewModel> GetCarDetails(int carId)
        {
            return await carsRepo.AllWithDeleted()
                .Where(x => x.Id == carId)
                .To<DetailsCarViewModel>()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetCarsForAdminAsync<T>()
        {
            //return carsRepo.AllWithDeleted()
            //    .Select(x => new CarsForAdminInListViewModel
            //    {
            //        CarType = x.CarType,
            //        City = x.City,
            //        Color = x.Color,
            //        CreateDate = x.CreateDate.ToString("MM/dd/yyyy"),
            //        HorsePower = x.HorsePower,
            //        Make = x.Make.Name,
            //        Id = x.Id,
            //        Mileage = x.Mileage,
            //        Model = x.Model.Name,
            //        Price = x.Price,
            //        Title = x.Title,
            //        Year = x.CreationYear,
            //        UserName = !String.IsNullOrWhiteSpace(x.Creator.FirstName + " " + x.Creator.LastName) ? x.Creator.FirstName + " " + x.Creator.LastName : x.Creator.UserName,
            //        IsDeleted = x.IsDeleted,
            //    });
            
            return await carsRepo.AllWithDeleted()
                .To<T>()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetSearchCarsAsync<T>()
        {
            return await carsRepo.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
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
