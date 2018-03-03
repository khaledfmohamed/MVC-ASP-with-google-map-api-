using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Model
{
    [Table("events")]
    public class Event
    {
        [Required()]
        [Column("id")]
        public int Id { get; set; }
        [Required()]
        [Column("title")]
        public string Title { get; set; }
        [Required()]
        [Column("start_date")]
        [Display(Name = "StartDate", ResourceType = typeof(Resource))]
        public DateTime StartDate { get; set; }
        [Required()]
        [Column("end_date")]
        [Display(Name = "EndDate", ResourceType = typeof(Resource))]
        public DateTime EndDate { get; set; }
        [Required()]
        [Column("country_id")]
        [Display(Name = "CountryName", ResourceType = typeof(Resource))]
        public int CountryId { get; set; }
        [Required()]
        [Column("city_id")]
        [Display(Name = "CityName", ResourceType = typeof(Resource))]
        public int CityId { get; set; }
        [Required()]
        [Column("location")]
        public string Location { get; set; }
        [Required()]
        [Column("image_path")]
        [Display(Name = "Image", ResourceType = typeof(Resource))]
        public string ImagePath { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("creator")]
        public string Creator { get; set; }
        [Column("created")]
        public DateTime? Created { get; set; }
        [Column("changer")]
        public string Changer { get; set; }
        [Column("changed")]
        public DateTime? Changed { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }
}
