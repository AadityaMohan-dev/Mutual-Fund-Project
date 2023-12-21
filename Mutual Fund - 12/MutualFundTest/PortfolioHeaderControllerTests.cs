using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MutualFund.Controllers;
using MutualFund.DI;
using MutualFund.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MutualFundTests
{
    [TestFixture]
     public class PortfolioHeaderControllerTests
    {
        private readonly Mock<IPortfolioHeader> mockHeader;
        private readonly Mock<ILogger<PortfolioHeaderController>> mockLogger;
        private readonly PortfolioHeaderController controller;

        public PortfolioHeaderControllerTests()
        {
            mockHeader = new Mock<IPortfolioHeader>();
            mockLogger = new Mock<ILogger<PortfolioHeaderController>>();
            controller = new PortfolioHeaderController(mockHeader.Object, mockLogger.Object);
        }

        [Test]
        public async Task CreateHeader_ReturnsOkResult()
        {
            // Arrange
            var portfolioHeaderModel = new PortfolioHeaderModel();

            mockHeader.Setup(x => x.CreateHeader(It.IsAny<PortfolioHeaderModel>()))
                .ReturnsAsync(portfolioHeaderModel);

            // Act
            var result = await controller.CreateHeader(portfolioHeaderModel);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task UpdateHeader_ReturnsOkResult()
        {
            // Arrange
            int portfolioId = 1;
            var portfolioHeaderModel = new PortfolioHeaderModel();

            mockHeader.Setup(x => x.UpdateHeader(portfolioId, It.IsAny<PortfolioHeaderModel>()))
                .ReturnsAsync(portfolioHeaderModel);

            // Act
            var result = await controller.UpdateHeader(portfolioId, portfolioHeaderModel);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task DeleteHeader_ReturnsOkResult()
        {
            // Arrange
            int portfolioId = 1;
            var portfolioHeaderModel = new PortfolioHeaderModel();

            mockHeader.Setup(x => x.DeleteHeader(portfolioId))
                .ReturnsAsync(portfolioHeaderModel);

            // Act
            var result = await controller.DeleteHeader(portfolioId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetPortfolioHeaderByName_ReturnsOkResult()
        {
            // Arrange
            string portfolioName = "Portfolio 1";
            var portfolioHeaderModel = new PortfolioHeaderModel();

            mockHeader.Setup(x => x.GetPortfolioHeaderByName(portfolioName))
                .ReturnsAsync(new List<PortfolioHeaderModel> { portfolioHeaderModel });

            // Act
            var result = await controller.GetPortfolioHeaderByName(portfolioName);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetAllPortfolioHeader_ReturnsOkResult()
        {
            // Arrange
            var portfolioHeaderModel = new PortfolioHeaderModel();

            mockHeader.Setup(x => x.GetAllPortfolioHeader())
                .ReturnsAsync(new List<PortfolioHeaderModel> { portfolioHeaderModel });

            // Act
            var result = await controller.GetAllPortfolioHeader();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetPortfolioHeaderById_ReturnsOkResult()
        {
            // Arrange
            int portfolioId = 1;
            var portfolioHeaderModel = new PortfolioHeaderModel();

            mockHeader.Setup(x => x.GetPortfolioHeaderById(portfolioId))
                .ReturnsAsync(new List<PortfolioHeaderModel> { portfolioHeaderModel });

            // Act
            // var result

        }
    }
}
