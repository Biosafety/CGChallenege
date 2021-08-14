using ApiCodeChallenge.Common.Interfaces;
using ApiCodeChallenge.Common.Models;
using ApiCodeChallenge.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ApiCodeChallenge.Controller.Tests
{
    [TestClass]
    public class TrainersControllerTests
    {
        private TrainersController controller;
        private Mock<ITrainersService> mockTrainersService;
        private Mock<ILogger<Trainer>> mockLogger;
        private Trainer mockTrainer;

        [TestInitialize]
        public void Initialize()
        {
            mockTrainersService = new Mock<ITrainersService>();
            mockLogger = new Mock<ILogger<Trainer>>();

            controller = new TrainersController(mockTrainersService.Object, mockLogger.Object);
            SetupModels();
        }

        public void SetupModels()
        {
            mockTrainer = new Trainer()
            {
                TrainerID = Guid.NewGuid(),
                FirstName = "FirstName",
                LastName = "LastName",
                Address = "Address",
                Phone = "Phone",
                Email = "Email"
            };
        }

        [TestMethod]
        public void ControllerIsNotNull()
        {
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public async Task GetTrainersReturns200()
        {
            mockTrainersService.Setup(_ => _.GetTrainer(It.IsAny<Guid>())).Returns(Task.FromResult(mockTrainer));

            var result = await controller.GetTrainer(mockTrainer.TrainerID);
            var response = result as ObjectResult;

            Assert.AreEqual(200, response.StatusCode);
        }

        [TestMethod]
        public async Task GetTrainersReturns400()
        {
            mockTrainersService.Setup(_ => _.GetTrainer(It.IsAny<Guid>())).Throws(new Exception("Something went wrong"));

            var result = await controller.GetTrainer(Guid.NewGuid());
            var response = result as ObjectResult;
            var respObj = response.Value as ErrorResponse;

            Assert.AreEqual(HttpStatusCode.BadRequest.ToString(), respObj.Status);
        }
    }
}
