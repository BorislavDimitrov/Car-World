using CarWorld.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarWorld.Web.ViewModels.Reports
{
    public class CarReportInputModel
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public ReportType ReportType { get; set; }

        public string ReporterId { get; set; }

        public int CarId { get; set; }
    }
}
