using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MutualFund.Controllers;
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
    public class AssetClassesControllerTest
    {
        private AssetClassesController _assetClassescontroller;
        private Mock<IAssetClass> _assetMock;
        private Mock<ILogger<AssetClassesController>> _loggerMock;

        //private PortfolioHeaderController _portfolioHeaderController;
        //private Mock<IPortfolioHeader> _portfolioHeaderMock;
        //private Mock<ILogger<PortfolioHeaderController>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _assetMock = new Mock<IAssetClass>();
            _loggerMock = new Mock<ILogger<AssetClassesController>>();
            _assetClassescontroller = new AssetClassesController(_assetMock.Object);

           
        }
        [Test]
        public async Task CreateAssetClass_WithValidTheme_ReturnsOkResult()
        {
            // Arrange
            var asset = new AssetClassesModel { Asset_Class_ID = 1, Asset_Class="Asset1" };

            _assetMock.Setup(x => x.CreateAssetClass(It.IsAny<AssetClassesModel>()))
                .ReturnsAsync(asset);

            // Act
            var result = await _assetClassescontroller.CreateAssetClass(asset);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(asset, okResult.Value);
            _assetMock.Verify(x => x.CreateAssetClass(It.IsAny<AssetClassesModel>()), Times.Once);
        }

        [Test]
        public async Task UpdateTheme_WithValidTheme_ReturnsOkResult()
        {
            // Arrange
            var asset = new AssetClassesModel { Asset_Class_ID = 1, Asset_Class = "Asset1" };

            _assetMock.Setup(x => x.UpdateAssetClass(It.IsAny<int>(), It.IsAny<AssetClassesModel>()))
                .ReturnsAsync(asset);

            // Act
            var result = await _assetClassescontroller.UpdateAssetClass(1, asset);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(asset, okResult.Value);
            _assetMock.Verify(x => x.UpdateAssetClass(It.IsAny<int>(), It.IsAny<AssetClassesModel>()), Times.Once);
        }

        [Test]
        public async Task DeleteAssetClass_WithValidTheme_ReturnsOkResult()
        {
            // Arrange
            var asset = new AssetClassesModel { Asset_Class_ID = 1, Asset_Class = "Asset1" };

            _assetMock.Setup(x => x.DeleteAssetClass(It.IsAny<int>()))
               .ReturnsAsync(asset); 

            // Act
            var result = await _assetClassescontroller.DeleteAssetClass(1);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(asset, okResult.Value);
            _assetMock.Verify(x => x.DeleteAssetClass(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task GetAllAssetClasses_ReturnsOkResult()
        {
            // Arrange
            var assetClassesModel = new AssetClassesModel();

            _assetMock.Setup(x => x.GetAllAssetClasses())
                .ReturnsAsync(new List<AssetClassesModel> { assetClassesModel });

            // Act
            var result = await _assetClassescontroller.GetAllAssetClasses();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetAssetclassByID_ReturnsOkResult()
        {
            // Arrange
            int Asset_Class_ID = 1;
            var assetClassesModel = new AssetClassesModel();

            _assetMock.Setup(x => x.GetAssetClassByID(Asset_Class_ID))
                .ReturnsAsync(new List<AssetClassesModel> { assetClassesModel });

            // Act
            var result = await _assetClassescontroller.GetAssetclassByID(Asset_Class_ID);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

    }
}
