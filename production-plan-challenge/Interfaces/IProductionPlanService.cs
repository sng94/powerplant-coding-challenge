using System;
using production_plan_challange.Models;

namespace production_plan_challange.Interfaces
{
	public interface IProductionPlanService
	{
        public List<Response> CalculateProductionPlan(Payload payload);
    }
}

