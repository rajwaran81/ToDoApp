namespace ToDoApp.Services
{
    public interface ITodoService
    {
        Task<List<Models.ToDo>> GetAllAsync();
        Task SaveAsync(Models.ToDo newToDo);
    }
}
