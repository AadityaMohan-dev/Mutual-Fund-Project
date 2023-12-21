using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MutualFund.Controllers;
using MutualFund.DI;
using MutualFund.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MutualFund.Tests.Controllers
{
    [TestFixture]
    public class ViewThemeControllerTests
    {
        private ViewThemeController _controller;
        private Mock<IViewTheme> _themeMock;
        private Mock<ILogger<ViewThemeController>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _themeMock = new Mock<IViewTheme>();
            _loggerMock = new Mock<ILogger<ViewThemeController>>();
            _controller = new ViewThemeController(_themeMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task CreateTheme_WithValidTheme_ReturnsOkResult()
        {
            // Arrange
            var theme = new ViewThemeModel { Theme_Id = 1, Investment_Theme = "Theme 1", Investment_Horizon = "Long-term" };

            _themeMock.Setup(x => x.CreateTheme(It.IsAny<ViewThemeModel>()))
                .ReturnsAsync(theme);

            // Act
            var result = await _controller.CreateTheme(theme);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(theme, okResult.Value);
            _themeMock.Verify(x => x.CreateTheme(It.IsAny<ViewThemeModel>()), Times.Once);
        }

        [Test]
        public async Task UpdateTheme_WithValidTheme_ReturnsOkResult()
        {
            // Arrange
            var theme = new ViewThemeModel { Theme_Id = 1, Investment_Theme = "Theme 1", Investment_Horizon = "Long-term" };

            _themeMock.Setup(x => x.UpdateTheme(It.IsAny<int>(), It.IsAny<ViewThemeModel>()))
                .ReturnsAsync(theme);

            // Act
            var result = await _controller.UpdateTheme(1, theme);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(theme, okResult.Value);
            _themeMock.Verify(x => x.UpdateTheme(It.IsAny<int>(), It.IsAny<ViewThemeModel>()), Times.Once);
        }

        [Test]
        public async Task DeleteTheme_WithValidTheme_ReturnsOkResult()
        {
            // Arrange
            var theme = new ViewThemeModel { Theme_Id = 1, Investment_Theme = "Theme 1", Investment_Horizon = "Long-term" };

            _themeMock.Setup(x => x.DeleteTheme(It.IsAny<int>()))
                .ReturnsAsync(theme);

            // Act
            var result = await _controller.DeleteTheme(1);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(theme, okResult.Value);
            _themeMock.Verify(x => x.DeleteTheme(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task GetThemesByThemeID_WithExistingTheme_ReturnsOkResult()
        {
            // Arrange
            var theme = new ViewThemeModel { Theme_Id =1, Investment_Theme = "Theme 1", Investment_Horizon = "Long-term" };
            var themes = new List<ViewThemeModel> { theme };

            _themeMock.Setup(x => x.GetThemesByThemeID(It.IsAny<int>()))
                .ReturnsAsync(themes);

            // Act
            var result = await _controller.GetThemesByThemeID(1);

            // Assert
        }
    }
}
