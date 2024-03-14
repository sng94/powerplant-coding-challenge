using System;
using System.ComponentModel.DataAnnotations;

namespace production_plan_challange.Models
{
	public class Payload
	{
        [Required]
        public int Load { get; set; }

        [Required]
        public Fuels? Fuels { get; set; }

        [Required]
        [MinLength(1)]
        public Powerplant[]? Powerplants { get; set; }
    }
}

