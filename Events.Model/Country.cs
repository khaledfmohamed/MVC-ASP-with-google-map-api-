using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Model
{
    [Table("countries")]
    public class Country
    {
        [Required()]
        [Column("id")]
        public int Id { get; set; }
        [Required()]
        [Column("name")]
        public string Name { get; set; }
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
