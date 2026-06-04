using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.Data;

namespace ToDoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ITodoService _toDoService;
        public ToDoController(ITodoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _toDoService.GetAllAsync();
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveAsync(ToDo newToDo)
        {
            await _toDoService.SaveAsync(newToDo);
            return Ok();
        }
    }
}
