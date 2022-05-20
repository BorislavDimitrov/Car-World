using CarWorld.Web.ViewModels.Reports;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface IReportsService
    {
        Task CreateCarReportAsync(CarReportInputModel model);
    }
}
