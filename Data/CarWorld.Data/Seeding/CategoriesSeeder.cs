using CarWorld.Common;
using CarWorld.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorld.Data.Seeding
{
    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Cars",
                Description = "In this category you can make general posts / ask questions about cars.",
                ImagePath = GlobalConstants.DefaultCategoryImagePath + "CarsCategoryImage.jpg",
            });

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Motorbikes",
                Description = "In this category you can ask general questions about motorbikes.",
                ImagePath = GlobalConstants.DefaultCategoryImagePath + "MotorbikesCategoryImage.jpg",
            });

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Tuning",
                Description = "The posts in this category is meant to be about tuning of any vehicle , both visual and performance.",
                ImagePath = GlobalConstants.DefaultCategoryImagePath + "TuningCategoryImage.jpg",
            });

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Motorsport",
                Description = "The posts in this category is meant to be about anything connected with the motorsports in general.",
                ImagePath = GlobalConstants.DefaultCategoryImagePath + "MotorSportCategoryImage.jpg",
            });

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Other",
                Description = "This category is for anything you search for or want ot post about, that doesnt fit in rest of the categories.",
                ImagePath = GlobalConstants.DefaultCategoryImagePath + "OthersCategoryImage.jpg",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
