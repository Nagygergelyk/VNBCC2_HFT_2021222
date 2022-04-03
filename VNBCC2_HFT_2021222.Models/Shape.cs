using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VNBCC2_HFT_2021222.Models
{
    [Table("shapes")]
    public class Shape
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShapeId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Guitar> Guitars { get; set; }

        public Shape()
        {
            this.Guitars = new HashSet<Guitar>();
        }
        public Shape(string line)
        {
            this.Guitars = new HashSet<Guitar>();

            string[] split = line.Split('#');
            ShapeId = int.Parse(split[0]);
            Name = split[1];
        }
    }
}
