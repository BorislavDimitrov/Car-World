using CarWorld.Data.Models;
using CarWorld.Data.Models.Enums;
using CarWorld.Services.Mapping;

namespace CarWorld.Web.ViewModels.Administration.CarReports
{
    public class CarReportViewModel : IMapFrom<CarReport>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ReportType ReportType { get; set; }
    }
}
