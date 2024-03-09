﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.Models
{
    public class Services
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;    

        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }
    }
}
