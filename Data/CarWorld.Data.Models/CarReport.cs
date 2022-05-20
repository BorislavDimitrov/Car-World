namespace CarWorld.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CarWorld.Data.Common.Models;
    using CarWorld.Data.Models.Enums;

    public class CarReport : BaseModel<int>
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public ReportType ReportType { get; set; }

        public string ReporterId { get; set; }

        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
    }
}
