using CarWorld.Web.ViewModels.Reports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface IReportsService
    {
        Task CreateCarReportAsync(CarReportInputModel model);

        Task<List<T>> GetReportsAsync<T>(string search, string orderBy);

        Task<T> GetReportByIdAsync<T>(int reportId);

        Task<bool> IsReportExistingByIdAsync(int reportId);

        Task SetReportAsCheckedByIdAsync(int reportId);

        Task DeleteCarReportAsync(int reportId);
    }
}
