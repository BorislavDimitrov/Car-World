using AutoMapper;
using CarWorld.Data.Common.Repositories;
using CarWorld.Data.Models;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Reports;
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
    }
}
