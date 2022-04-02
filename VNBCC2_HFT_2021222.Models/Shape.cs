﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNBCC2_HFT_2021222.Models
{
    [Table("shapes")]
    public class Shape : Entity
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Guitar> Guitars { get; set; }

        public Shape()
        {
            this.Guitars = new HashSet<Guitar>();
        }
    }
}
