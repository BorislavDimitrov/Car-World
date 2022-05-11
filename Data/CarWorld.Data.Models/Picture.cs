namespace CarWorld.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using CarWorld.Data.Common.Models;

    public class Picture : BaseDeletableModel<string>
    {
        public Picture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string PicturePath { get; set; }

        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
    }
}
