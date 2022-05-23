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
        private readonly IMapper mapper;

        public ReportsService(IRepository<CarReport> carsRepo)
        {
            this.carsReportsRepo = carsRepo;
            this.mapper = AutoMapperConfig.MapperInstance;
        }

        public async Task CreateCarReportAsync(CarReportInputModel model)
        {
            var newCarReport = mapper.Map<CarReport>(model);

            await carsReportsRepo.AddAsync(newCarReport);

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
