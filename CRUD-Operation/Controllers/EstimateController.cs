using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        private readonly IEstimatesRepository _estimatesRepository;
        public EstimateController(IEstimatesRepository estimatesRepository)
        {
            _estimatesRepository = estimatesRepository;
        }
        // create estimate
        [HttpPost]
        public IActionResult CreateEstimates(Estimates model)
        {
            model.ChangeOrder = false;
            var result = _estimatesRepository.EstimateAdd(model);
            return Ok(result);
        }
        [HttpPost("changeorder")]
        public IActionResult Changeorder(Estimates model)
        {
            model.ChangeOrder = true;
            var result = _estimatesRepository.EstimateAdd(model);
            return Ok(result);
        }

        //Locked the estimate
        [HttpPut("blockedTheEstimate/{id}")]
        public IActionResult LockedTheEstimate(string id)
        {
            try 
            {
                var result = _estimatesRepository.LockTheEstimate(id)
   ;
                return Ok(result);
            }  
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while locking the estimate.");
            }
        }


        //Change the default estimate will be true
        [HttpPut("changeDefaultEstimate/{id}")]
        public IActionResult ChangeTheDefaultEstimate(string id)
        {
            try
            {
                var result = _estimatesRepository.ChangeTheDefaultEstimate(id)
   ;
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while locking the estimate.");
            }
        }
    }
}
