// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;
// using Moq;
// using System.Threading.Tasks;
// using VehicleFleet.Api.Commands;
// using VehicleFleet.Api.Controllers;
// using VehicleFleet.Api.Models;
// using Xunit;
// using MediatR;

// namespace VehicleFleet.Api.Tests.Controllers
// {
//     public class CreateUserControllerTests
//     {
//         private readonly ApiContext _context;
//         private readonly Mock<IMediator> _mediatorMock;
//         private readonly Mock<ILogger<CreateUserController>> _loggerMock;
//         private readonly CreateUserController _controller;

//         public CreateUserControllerTests()
//         {
//             var options = new DbContextOptionsBuilder<ApiContext>()
//                 .UseInMemoryDatabase(databaseName: "TestDatabase")
//                 .Options;

//             _context = new ApiContext(options);
//             _mediatorMock = new Mock<IMediator>();
//             _loggerMock = new Mock<ILogger<CreateUserController>>();

//             _controller = new CreateUserController(_context, _mediatorMock.Object, _loggerMock.Object);
//         }

//         [Fact]
//         public async Task CreateNewUser_ValidUser_ReturnsOkResult()
//         {
//             var user = new User
//             {
//                 Id = 1,
//                 Name = "Test User",
//                 Email = "testuser@example.com"
//             };
//             _mediatorMock.Setup(m => m.Send(It.IsAny<CreateNewUserCommand>(), default))
//                 .ReturnsAsync(user);

//             // Act
//             var result = await _controller.CreateNewUser(user);

//             // Assert
//             var okResult = Assert.IsType<OkObjectResult>(result);
//             var returnValue = Assert.IsType<User>(okResult.Value);
//             Assert.Equal(user.Id, returnValue.Id);
//             Assert.Equal(user.Name, returnValue.Name);
//             Assert.Equal(user.Email, returnValue.Email);
//         }

//         [Fact]
//         public async Task CreateNewUser_NullUser_ReturnsBadRequest()
//         {
//             // Act
//             var result = await _controller.CreateNewUser(null);

//             // Assert
//             var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//             Assert.Equal("User data is null.", badRequestResult.Value);
//         }

//         [Fact]
//         public async Task CreateNewUser_InvalidModel_ReturnsBadRequest()
//         {
//             // Arrange
//             var user = new User(); // Invalid user model
//             _controller.ModelState.AddModelError("Name", "Required");

//             // Act
//             var result = await _controller.CreateNewUser(user);

//             // Assert
//             var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//         }

//         [Fact]
//         public async Task CreateNewUser_ExceptionThrown_ReturnsInternalServerError()
//         {
//             var user = new User
//             {
//                 Id = 1,
//                 Name = "Test User",
//                 Email = "testuser@example.com",
//                 idNumber = 2,
//                 firstName = "Joa",
//                 lastName = "Waya",
//                 password = "password123"
//             };

//             _mediatorMock.Setup(m => m.Send(It.IsAny<CreateNewUserCommand>(), default))
//                 .ThrowsAsync(new System.Exception("Test exception"));

//             // Act
//             var result = await _controller.CreateNewUser(user);

//             // Assert
//             var internalServerErrorResult = Assert.IsType<ObjectResult>(result);
//             Assert.Equal(500, internalServerErrorResult.StatusCode);
//             Assert.Equal("Internal server error.", internalServerErrorResult.Value);
//         }
//     }
// }
