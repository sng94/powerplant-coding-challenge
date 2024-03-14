using Microsoft.AspNetCore.Mvc;
using production_plan_challange.Interfaces;
using production_plan_challange.Models;
using production_plan_challange.Services;

namespace production_plan_challange.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly IProductionPlanService _productionPlanService;

        public ProductionPlanController(IProductionPlanService productionPlanService)
        {
            _productionPlanService = productionPlanService;
        }

        [HttpPost]
        public IActionResult CalculateProductionPlan([FromBody] Payload payload)
        {
            try
            {
                var response = _productionPlanService.CalculateProductionPlan(payload);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
