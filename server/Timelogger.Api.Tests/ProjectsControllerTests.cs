using Timelogger.Api.Controllers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Timelogger.Api.Tests
{
    public class ProjectsControllerTests
    {
        private Mock<IRepositoryWrapper> _mock;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IRepositoryWrapper>();
        }

        [Test]
        public void GetAll_ShouldReturn_OkStatusCode()
        {
            // Arrange
            _mock.Setup(repo => repo.Project.GetAll());
            var controller = new ProjectsController(_mock.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            int? statusCode = ((OkObjectResult)result).StatusCode;
            Assert.AreEqual(404, statusCode);
        }
    }
} 
