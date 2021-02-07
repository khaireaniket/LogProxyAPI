using LogProxyAPI.BusinessLogic;
using LogProxyAPI.Controllers;
using LogProxyAPI.Models.Request;
using LogProxyAPI.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace LogProxyAPI.Tests.Controllers
{
    public class LogDelegatorControllerTests
    {
        private readonly LogDelegatorController _logDelegatorController;
        private readonly Mock<IHandler> _mockHandler = new Mock<IHandler>();

        public LogDelegatorControllerTests()
        {
            _logDelegatorController = new LogDelegatorController(_mockHandler.Object);
        }

        [Fact]
        public async Task GetLogMessages_ReturnsAnOkObjectResult_WithAListOfLogMessages()
        {
            // Arrange
            _mockHandler.Setup(handler => handler.CallAirTableGetLogs(2)).ReturnsAsync(TestData.AirTableGetResponse);
            _mockHandler.Setup(handler => handler.ParseToGetReponse(string.Empty)).Returns(new GetLogResponse[2]);

            // Act
            var result = await _logDelegatorController.GetLogMessages(2);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.NotNull(okObjectResult.Value);
        }

        [Fact]
        public async Task GetLogMessages_ReturnsNotFoundResult_WhenNoLogMessagesRetunedFromServer()
        {
            // Arrange
            _mockHandler.Setup(handler => handler.CallAirTableGetLogs(2)).ReturnsAsync(string.Empty);

            // Act
            var result = await _logDelegatorController.GetLogMessages(2);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }
 
        [Fact]
        public async Task PostLogMessages_ReturnsAnOkObjectResult_WithCreatedLogMessages()
        {
            // Arrange
            var mockRequest = JsonConvert.DeserializeObject<CreateLogRequest>(TestData.CreateLogRequest);
            var mockResponse = JsonConvert.DeserializeObject<CreateLogResponse>(TestData.AirTablePostResponse);

            _mockHandler.Setup(handler => handler.CallAirTableCreateLogs(mockRequest)).ReturnsAsync(TestData.AirTablePostResponse);
            _mockHandler.Setup(handler => handler.ParseToPostReponse(TestData.AirTablePostResponse)).Returns(mockResponse);

            // Act
            var result = await _logDelegatorController.CreateLogMessages(mockRequest);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.NotNull(okObjectResult.Value);
        }

        [Fact]
        public async Task PostLogMessages_ReturnsBadRequestResult_WhenInvalidRequestModelIsPassed()
        {
            // Act
            var result = await _logDelegatorController.CreateLogMessages(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }
    }
}
