using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNBCC2_HFT_2021222.Models
{

    [Table("guitars")]
    public class Guitar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("guitar_id", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Range(1500, 2022)]

        public int Year { get; set; }
        
        [Range(0, int.MaxValue)]
        public int? BasePrice { get; set; }

        [NotMapped] 
        public virtual Brand Brand { get; set; }

        [NotMapped]
        public virtual Shape Shape { get; set; }


        [ForeignKey(nameof(Brand))] 
        public int BrandId { get; set; }

        [ForeignKey(nameof(Shape))]
        public int ShapeId { get; set; }

        public Guitar()
        {

        }

        public Guitar(string line)
        {
            string[] split = line.Split('#');
            Id = int.Parse(split[0]);
            Year = int.Parse(split[1]);
            BasePrice = int.Parse(split[2]);
            BrandId = int.Parse(split[3]);
            ShapeId = int.Parse(split[4]);
        }
    }
}
