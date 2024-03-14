using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace production_plan_challange.Models
{
	public class Fuels
	{
        [Required]
        [JsonPropertyName("gas(euro/MWh)")]
        public double Gas { get; set; }

        [Required]
        [JsonPropertyName("kerosine(euro/MWh)")]
        public double Kerosine { get; set; }

        [Required]
        [JsonPropertyName("co2(euro/ton)")]
        public double CO2 { get; set; }

        [Required]
        [JsonPropertyName("wind(%)")]
        public double Wind { get; set; }
    }
}

