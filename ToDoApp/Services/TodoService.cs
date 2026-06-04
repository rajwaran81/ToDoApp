using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    
    public class TodoService : ITodoService
    {
        public readonly ToDoDbContext _dbContext;

        public TodoService(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ToDo>> GetAllAsync()
        {
            return await _dbContext.ToDo.ToListAsync();
        }

        public async Task SaveAsync(ToDo newToDo)
        {
            _dbContext.ToDo.Add(newToDo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
