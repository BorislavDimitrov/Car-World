using AutoMapper;
using CarWorld.Data.Common.Repositories;
using CarWorld.Data.Models;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Reports;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorld.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IRepository<CarReport> carsReportsRepo;

        public ReportsService(IRepository<CarReport> carsRepo)
        {
            this.carsReportsRepo = carsRepo;
        }

        public async Task CreateCarReportAsync(CarReportInputModel model)
        {
            var newCarReport = new CarReport
            {
                Title = model.Title,
                Description = model.Description,
                CarId = model.CarId,
                ReportType = model.ReportType,
                ReporterId = model.ReporterId,
                IsChecked = false,
            };

            await carsReportsRepo.AddAsync(newCarReport);

            await carsReportsRepo.SaveChangesAsync();
        }

        public async Task DeleteCarReportAsync(int reportId)
        {
            var report = await carsReportsRepo.All()
                .FirstOrDefaultAsync(x => x.Id == reportId);

            carsReportsRepo.Delete(report);

            await carsReportsRepo.SaveChangesAsync();
        }

        public async Task<T> GetReportByIdAsync<T>(int reportId)
        {
            return await carsReportsRepo.AllAsNoTracking()
                .Where(x => x.Id == reportId)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetReportsAsync<T>(string search, string orderBy)
        {
            var reports = carsReportsRepo.AllAsNoTracking()
                .AsQueryable();

            if (search != null)
            {
                reports = reports.Where(x => x.Description.Contains(search)).AsQueryable();
            }

            switch (orderBy)
            {
                case "Newest":
                    reports = reports.OrderByDescending(x => x.CreatedOn);
                    break;
                case "Oldest":
                    reports = reports.OrderBy(x => x.CreatedOn);
                    break;
                case "CheckedFirst":
                    reports = reports.OrderByDescending(x => x.IsChecked);
                    break;
                default:
                    reports = reports.OrderBy(x => x.IsChecked);
                    break;
            }

            return await reports.To<T>()
                .ToListAsync();
        }

        public async Task<bool> IsReportExistingByIdAsync(int reportId)
            => await carsReportsRepo.AllAsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == reportId) == null ? false : true;

        public async Task SetReportAsCheckedByIdAsync(int reportId)
        {
            var report = await carsReportsRepo.All()
                .FirstOrDefaultAsync(x => x.Id == reportId);

            report.IsChecked = true;

            await carsReportsRepo.SaveChangesAsync();
        }
    }
}
