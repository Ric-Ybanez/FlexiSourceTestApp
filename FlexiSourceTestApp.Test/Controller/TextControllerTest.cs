using FlexiSourceTestApp.Common.Request;
using FlexiSourceTestApp.Test.Controller.Shared;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace FlexiSourceTestApp.Test.Controller
{
    public class TextControllerTest
    {
        [Fact]
        public void Post_ReturnsOk()
        {
            var req = new StringMatchRequest();
            var mockService = MockServiceGenerator.GetMockTextService();
            var controller = ControllerGenerator.GetTextController(mockService.Object);
            var response = controller.Post(req);
            var result = response as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Post_ArgumentException_ReturnsBadRequest()
        {
            var req = new StringMatchRequest();
            var mockService = MockServiceGenerator.GetMockTextService();
            var controller = ControllerGenerator.GetTextController(mockService.Object);

            mockService.Setup(i => i.StringSearch(It.IsAny<StringMatchRequest>()))
               .Throws<ArgumentException>();

            var response = controller.Post(req);
            var result = response as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Post_ModelStateInvalid_ReturnsBadRequest()
        {
            var req = new StringMatchRequest();
            var mockService = MockServiceGenerator.GetMockTextService();
            var controller = ControllerGenerator.GetTextController(mockService.Object);
            controller.ModelState.AddModelError("key", "error message");
            var response = controller.Post(req);
            var result = response as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }
    }
}
