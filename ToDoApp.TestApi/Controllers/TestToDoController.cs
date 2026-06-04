using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoApp.Controllers;
using ToDoApp.Services;
using FluentAssertions; // Add this at the top with other using directives

namespace ToDoApp.TestApi.TestToDoControllers
{
    public class TestToDoController
    {
        [Fact]
        public async Task GetAllAsync_ShouldReturn200Status()
        {
            // Arrange  
            var todoService = new Mock<ITodoService>();
            todoService.Setup(service => service.GetAllAsync()).ReturnsAsync(ToDoMockData.ToDoMockData.GetToDos());
            var sut = new ToDoController(todoService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetAllAsync();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn204NoContentStatus()
        {
            // Arrange  
            var todoService = new Mock<ITodoService>();
            todoService.Setup(service => service.GetAllAsync()).ReturnsAsync(ToDoMockData.ToDoMockData.GetEmptyToDos());
            var sut = new ToDoController(todoService.Object);
            // Act
            var result = (NoContentResult)await sut.GetAllAsync();
            // Assert
            result.StatusCode.Should().Be(204);
            todoService.Verify(service => service.GetAllAsync(), Times.Exactly(1));
        }

        [Fact]
        public async Task SaveAsync_ShouldCall_ITodoService_SaveAsync_AtleastOnce()
        {
            // Arrange  
            var todoService = new Mock<ITodoService>();
            var sut = new ToDoController(todoService.Object);
            var newToDo = ToDoMockData.ToDoMockData.NewToDo();
            // Act
            var result = await sut.SaveAsync(newToDo);
            // Assert
            todoService.Verify(service => service.SaveAsync(newToDo), Times.Exactly(1));
        }

    }
}
