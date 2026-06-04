using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory; // Add this using directive
using ToDoApp.Data;
using ToDoApp.Services;
using Xunit;
using ToDoApp.TestApi.ToDoMockData;
using FluentAssertions;

namespace ToDoApp.TestApi.Services
{
    public class TestToDoService : IDisposable
    {
        protected readonly ToDoDbContext _context;
        public TestToDoService()
        {
            var options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _context = new ToDoDbContext(options);

            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllAsync_ReturnTodoCollection()
        {
            /// Arrange
            _context.ToDo.AddRange(ToDoMockData.ToDoMockData.GetToDos());
            _context.SaveChanges();

            var sut = new TodoService(_context);

            /// Act
            var result = await sut.GetAllAsync();

            /// Assert
            result.Should().HaveCount(ToDoMockData.ToDoMockData.GetToDos().Count);
        }

        [Fact]
        public async Task SaveAsync_AddNewTodo()
        {
            /// Arrange
            var newTodo = ToDoMockData.ToDoMockData.NewToDo();
            _context.ToDo.AddRange(ToDoMockData.ToDoMockData.GetToDos());
            _context.SaveChanges();

            var sut = new TodoService(_context);

            /// Act
            await sut.SaveAsync(newTodo);

            ///Assert
            int expectedRecordCount = (ToDoMockData.ToDoMockData.GetToDos().Count() + 1);
            _context.ToDo.Count().Should().Be(expectedRecordCount);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
