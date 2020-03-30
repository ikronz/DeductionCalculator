using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeductibleApi.Models;
using DeductibleApi.Logic;
using DeductibleApi.DataAccess;
using static DeductibleApi.Logic.DeductionService;

namespace DeductibleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeductiblesController : ControllerBase
    {
        private readonly IDataStore dataStore;

        public DeductiblesController(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public ActionResult<DeductibleItem> GetDeductibles(long id)
        {
            var deductible = dataStore.GetItem(id);

            if (deductible == null)
            {
                return NotFound();
            }

            return deductible;
        }

        // POST: api/TodoItems
        [HttpPost]
        public ActionResult<Result> PostDeductibles([FromBody] DeductibleItem deductible)
        {
            dataStore.AddItem(deductible);
            var x = DeductionService.Calculate(deductible.Name, deductible.Dependents);
            return x;
        }
    }
}
