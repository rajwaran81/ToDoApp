using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }
        public DbSet<Models.ToDo> ToDo { get; set; }
    }
}
