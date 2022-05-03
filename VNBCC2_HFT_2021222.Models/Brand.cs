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
    [Table("brands")]
    public class Brand
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }

        [MaxLength(50)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Guitar> Guitars { get; set; }

        public Brand()
        {
            this.Guitars = new HashSet<Guitar>();
        }

        public Brand(string line)
        {
            this.Guitars = new HashSet<Guitar>();

            string[] split = line.Split('#');
            BrandId = int.Parse(split[0]);
            Name = split[1];
        }
    }
}
