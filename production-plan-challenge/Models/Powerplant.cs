using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace production_plan_challange.Models
{
	public class Powerplant
	{
        [Required]
        public string? Name { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PowerplantType Type { get; set; }

        [Required]
        [Range(0, 1)]
        public double Efficiency { get; set; }

        [Required]
        public double Pmin { get; set; }

        [Required]
        public double Pmax { get; set; }

		public double EffectivePmax { get; set; }
		public double CostPerMWh { get; set; }
    }
}

