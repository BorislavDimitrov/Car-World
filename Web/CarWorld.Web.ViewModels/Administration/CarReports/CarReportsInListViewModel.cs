using CarWorld.Data.Models;
using CarWorld.Data.Models.Enums;
using CarWorld.Services.Mapping;

namespace CarWorld.Web.ViewModels.Administration.CarReports
{
    public class CarReportsInListViewModel : IMapFrom<CarReport>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ReportType ReportType { get; set; }

        public string ReporterId { get; set; }

        public int CarId { get; set; }

        public bool IsChecked { get; set; }
    }
}
