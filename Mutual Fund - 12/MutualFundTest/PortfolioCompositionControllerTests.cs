using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MutualFund.Controller;
using MutualFund.Controllers;
using MutualFund.DI;
using MutualFund.Models;
using MutualFund.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TEST_PMS
{
    [TestFixture]
    public class PortfolioHeaderControllerTests
    {

        private PortfolioCompositionController _portfolioCompositionController;
        private Mock<IPortfolioComposition> _portfolioCompositionMock;
        private Mock<ILogger<PortfolioCompositionController>> _loggerMock;


        [SetUp]
        public void Setup()
        {
            _portfolioCompositionMock = new Mock<IPortfolioComposition>();
            _loggerMock = new Mock<ILogger<PortfolioCompositionController>>();
            _portfolioCompositionController = new PortfolioCompositionController(_portfolioCompositionMock.Object, _loggerMock.Object);
        }
        [Test]
        public async Task CreateHeader_ValidComposition_ReturnsOkResult()
        {
            // Arrange
            var portfolio = new PortfolioCompositionModel
            {
                Portfolio_Composition_ID=1,
                Transaction_Date=DateTime.Now,
                Security_Name="pavan",
                Equity_Category="mid",
                Exchange_Name="Nse",
                Transaction_Type="Currency",
                Price=10000000,
                Quantity=2,
                ValueofSecurity=3,
                Allocation=2,
                Total_Transaction=3,
                EstimatedTax=1
            };
            _portfolioCompositionMock.Setup(x => x.Createportfolio(It.IsAny<PortfolioCompositionModel>()))
            .ReturnsAsync(portfolio);
            // Act
            var result = await _portfolioCompositionController.Createportfolio(portfolio);
            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.EqualTo(portfolio));
        }


        [Test]
        public async Task UpdateHeader_ReturnsOkResult()
        {
            // Arrange
            int Portfolio_Composition_ID = 1;
            var portfolioCompositionModel = new PortfolioCompositionModel();

            _portfolioCompositionMock.Setup(x => x.UpdatePortfolio(Portfolio_Composition_ID, It.IsAny<PortfolioCompositionModel>()))
                .ReturnsAsync(portfolioCompositionModel);

            // Act
            var result = await _portfolioCompositionController.UpdatePortfolio(Portfolio_Composition_ID, portfolioCompositionModel);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task DeletePortfolio_ReturnsOkResult()
        {
            // Portfolio_Composition_ID
            int Portfolio_Composition_ID = 1;
            var portfolioCompositionModel = new PortfolioCompositionModel();

            _portfolioCompositionMock.Setup(x => x.DeletePortfolio(Portfolio_Composition_ID))
                .ReturnsAsync(portfolioCompositionModel);

            // Act
            var result = await _portfolioCompositionController.DeletePortfolio(Portfolio_Composition_ID);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
        [Test]
        public async Task GetAllPortfolios_ReturnsOkResult()
        {
            // Arrange
            var portfolioCompositionModel = new PortfolioCompositionModel();

            _portfolioCompositionMock.Setup(x => x.GetAllPortfolios())
                .ReturnsAsync(new List<PortfolioCompositionModel> { portfolioCompositionModel });

            // Act
            var result = await _portfolioCompositionController.GetAllPortfolios();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
        [Test]
        public async Task GetPortfolioByID_ReturnsOkResult()
        {
            // Arrange
            int Portfolio_Composition_ID = 1;
            var portfolioCompositionModel = new PortfolioCompositionModel();

            _portfolioCompositionMock.Setup(x => x.GetPortfolioByID(Portfolio_Composition_ID))
                .ReturnsAsync(new List<PortfolioCompositionModel> { portfolioCompositionModel });

            // Act
            var result = await _portfolioCompositionController.GetPortfolioByID(Portfolio_Composition_ID);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

    }
}
