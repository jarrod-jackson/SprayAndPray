using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.Models
{
    public class Pricing
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [Required]
        [Range(1, 10000)]
        public double BundledPrice { get; set; }

        [Required]
        public int ServicesId { get; set; }

        // Foreign key to Services
        public virtual Services? Services { get; set; }
    }
}
