using ApiCodeChallenge.Common.Interfaces;
using ApiCodeChallenge.Common.Models;
using ApiCodeChallenge.Filters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCodeChallenge.Controllers
{
    [ApiController, Route("api/[controller]"), Produces("application/json"), Consumes("application/json"), AuthFilter]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainersService TrainersService;
        private readonly ILogger _logger;

        public TrainersController(ITrainersService trainersService, ILogger<Trainer> logger)
        {
            TrainersService = trainersService;
            _logger = logger;
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetTrainers()
        {
            return Ok(await TrainersService.GetTrainers());
        }


        [HttpGet, Route("{ID}")]
        public async Task<IActionResult> GetTrainer(Guid ID)
        {
            try
            {
                _logger.LogInformation($"GetTrainer ID={ID}");
                var dbTrainer = await TrainersService.GetTrainer(ID);

                if(dbTrainer != null)
                {
                    return Ok(dbTrainer);
                }

                return BadRequest(new ErrorResponse(status: System.Net.HttpStatusCode.BadRequest, "Invalid Request"));
            }

            //this would be a custom exception
            //general errors would be caught a logged below.
            catch (Exception e)
            {
                _logger.LogError($"Invalid ID passed in ID={ID}");
                //since we are only throwing on invalid id's let just return a 400 bad request not give away to much info for security purposes.
                return BadRequest(new ErrorResponse(status: System.Net.HttpStatusCode.BadRequest, "Invalid Request"));
            }
        }

        [AuthFilter, HttpPut, Route("")]
        public async Task<IActionResult> AddTrainer([FromBody]Trainer newTrainer)
        {

            _logger.LogInformation($"Add New Trainer ID={newTrainer.TrainerID}");
            await TrainersService.CreateTrainer(newTrainer);

            return Ok(newTrainer);
        }

        [AuthFilter, HttpPatch, Route("{id}")]
        public async Task<IActionResult> ModifyTrainer(Guid ID, [FromBody] JsonPatchDocument<Trainer> trainerPatch)
        {
            _logger.LogInformation($"Updating Trainer ID={ID}");
            Trainer updatedTrainer = await TrainersService.ModifyTrainer(ID, trainerPatch);

            if (updatedTrainer != null)
            {
                return Ok(updatedTrainer);
            }
            else
            {
                _logger.LogError($"Error Updating Trainer = {ID}");
                return BadRequest(new ErrorResponse(System.Net.HttpStatusCode.BadRequest, "Invalid Request / Patch Instructions"));
            }
        }
    }
}
