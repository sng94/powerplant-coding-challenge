using System;
using production_plan_challange.Interfaces;
using production_plan_challange.Models;

namespace production_plan_challange.Services
{
	public class ProductionPlanService : IProductionPlanService
	{
        public List<Response> CalculateProductionPlan(Payload payload)
        {
            var powerplants = payload.Powerplants ?? Array.Empty<Powerplant>();
            var fuels = payload.Fuels ?? new Fuels();

            // Step 1: Calculate the cost per MWh in order to establish merit order later on
            foreach (var plant in powerplants)
            {
                double effectivePmax = plant.Pmax;

                switch (plant.Type)
                {
                    case PowerplantType.gasfired:
                        plant.CostPerMWh = (fuels.Gas / plant.Efficiency) + (fuels.CO2 * 0.3);
                        break;
                    case PowerplantType.turbojet:
                        plant.CostPerMWh = fuels.Kerosine / plant.Efficiency;
                        break;
                    case PowerplantType.windturbine:
                        effectivePmax = plant.Pmax * (fuels.Wind / 100); // Adjusted P for wind
                        plant.CostPerMWh = 0;
                        break;
                }

                plant.EffectivePmax = effectivePmax;
            }

            // Step 2: Establish merit order
            var sortedPowerplants = powerplants.OrderBy(p => p.CostPerMWh).ToList();

            // Step 3: Allocate load to power plants
            List<Response> productionPlan = new List<Response>();
            double remainingLoad = payload.Load;

            foreach (var plant in sortedPowerplants)
            {
                double production = 0;
                if (remainingLoad > 0)
                {
                    // Use the effective Pmax for calculation
                    double availableCapacity = Math.Min(plant.EffectivePmax, remainingLoad);

                    // Don't turn on the power plant if Pmin exceeds the available capacity
                    if (availableCapacity >= plant.Pmin)
                    {
                        production = availableCapacity;
                        remainingLoad -= production;
                    }
                }

                production = Math.Round(production, 1, MidpointRounding.AwayFromZero);
                productionPlan.Add(new Response { Name = plant.Name, P = production });
            }

            if (remainingLoad > 0)
            {
                throw new Exception("Unable to meet the total load with available power plants.");
            }

            return productionPlan;
        }
    }
}

