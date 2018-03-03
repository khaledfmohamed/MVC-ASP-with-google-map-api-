using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Model
{
    [Table("cities")]
    public class City
    {
        [Required()]
        [Column("id")]
        [Display(Name="Id" ,ResourceType = typeof(Resource))]
        public int Id { get; set; }
        [Required()]
        [Column("name")]
        [Display(Name = "Name", ResourceType = typeof(Resource))]
        public string Name { get; set; }
        [Required()]
        [Column("country_id")]

        [Display(Name = "CountryName", ResourceType = typeof(Resource))]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [Column("creator")]
        public string Creator { get; set; }
        [Column("created")]
        public DateTime? Created { get; set; }
        [Column("changer")]
        public string Changer { get; set; }
        [Column("changed")]
        public DateTime? Changed { get; set; }
    }
}
