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
    public class Guitar : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("guitar_id", TypeName = "int")]
        public override int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Model { get; set; }

        public int? BasePrice { get; set; }

        [NotMapped] 
        public virtual Brand Brand { get; set; }
        public virtual Shape Shape { get; set; }


        [ForeignKey(nameof(Brand))] 
        public int BrandId { get; set; }

        [ForeignKey(nameof(Shape))]
        public int ShapeId { get; set; }
    }
}
