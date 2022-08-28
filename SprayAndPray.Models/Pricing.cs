using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.Models
{
    public class Pricing
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int ServicesId { get; set; }

        // Foreign key to Services
        public virtual Services? Services { get; set; }
    }
}
