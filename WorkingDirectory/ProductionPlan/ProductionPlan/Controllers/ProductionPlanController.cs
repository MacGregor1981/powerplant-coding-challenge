using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductionPlan.Data;
using ProductionPlan.Engine;

namespace ProductionPlan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        [HttpPost("Calculate")]
        public List<Result> Calculcate(Loader loader)
        {
            ProductionManager production = new ProductionManager(loader);

            return production.Calculate();
        }
    }
}
