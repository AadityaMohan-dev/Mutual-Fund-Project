//using FutureCapitals.Controllers;
//using FutureCapitals.DataAccessLayer;
//using FutureCapitals.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Moq;
//using MutualFund.DataAccessLayer;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace MutualFundTests
//{
//    [TestFixture]
//    public class usmControllerTests
//    {
//        private usmController _controller;
//        private Mock<Iusm> _dataContextMock;
//        private Mock<MutualDbContext> _dbContextMock;
//        private Mock<ILogger<usmController>> _loggerMock;

//        [SetUp]
//        public void Setup()
//        {
//            _dataContextMock = new Mock<Iusm>();
//            _dbContextMock = new Mock<MutualDbContext>();
//            _loggerMock = new Mock<ILogger<usmController>>();

//            _controller = new usmController(_dataContextMock.Object, _dbContextMock.Object, _loggerMock.Object);
//        }

//        [Test]
//        public void GetSecurities_ReturnsOkResult()
//        {
//            // Arrange
//            var securities = new List<usmModel> { new usmModel(), new usmModel() };
//            _dataContextMock.Setup(x => x.GetSecurities()).ReturnsAsync(securities);

//            // Act
//            var result = _controller.GetSecurities().Result;

//            // Assert
//            Assert.IsInstanceOf<OkObjectResult>(result);
//            var okResult = (OkObjectResult)result;
//            Assert.AreEqual(securities, okResult.Value);
//        }

//        [Test]
//        public async Task CREATENSE_ReturnsOkResult()
//        {
//            // Arrange
//            var nSE_Export = new usmModel();

//            _dataContextMock.Setup(x => x.CREATENSE(It.IsAny<usmModel>())).ReturnsAsync(nSE_Export);

//            // Act
//            var result = await _controller.CREATENSE(nSE_Export);

//            // Assert
//            Assert.IsInstanceOf<OkObjectResult>(result);
//            var okResult = (OkObjectResult)result;
//            Assert.AreEqual(nSE_Export, okResult.Value);
//        }

//        [Test]
//        public async Task UPDATENSE_ReturnsOkResult()
//        {
//            // Arrange
//            var symbol = "ABC";
//            var nSE_Data1 = new usmModel();

//            _dataContextMock.Setup(x => x.UPDATENSE(symbol, It.IsAny<usmModel>())).ReturnsAsync(nSE_Data1);

//            // Act
//            var result = await _controller.UPDATENSE(symbol, nSE_Data1);

//            // Assert
//            Assert.IsInstanceOf<OkObjectResult>(result);
//            var okResult = (OkObjectResult)result;
//            Assert.AreEqual(nSE_Data1, okResult.Value);
//        }

//        [Test]
//        public async Task DELETENSE_ReturnsOkResult()
//        {
//            // Arrange
//            var symbol = "ABC";
//            var nSE_Data1 = new usmModel();

//            _dataContextMock.Setup(x => x.DELETENSE(symbol)).ReturnsAsync(nSE_Data1);

//            // Act
//            var result = await _controller.DELETENSE(symbol);

//            // Assert
//            Assert.IsInstanceOf<OkObjectResult>(result);
//            var okResult = (OkObjectResult)result;
//            Assert.AreEqual(nSE_Data1, okResult.Value);
//        }

//        [Test]
//        public async Task DetailsWithData_ReturnsOkResult()
//        {
//            // Arrange
//            var option = "ABC";
//            var nSE_Data1 = new List<usmModel> { new usmModel(), new usmModel() };
//        }


//    }
//}
