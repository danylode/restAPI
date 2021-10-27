using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using get_post_action_task.Models;

namespace get_post_action_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        static private List<TodoItem> todoItems = new List<TodoItem> {
            new TodoItem() { Id = 1, Title = "Implement read" },
            new TodoItem() { Id = 2, Title = "Implement create" }
        };
        static private int lastId = 2;

        public TodoItemController()
        {
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            return todoItems;
        }

        [HttpPost("")]
        public ActionResult<TodoItem> PostTModel(TodoItem todoItem)
        {
            todoItem.Id = ++lastId;
            todoItems.Add(todoItem);
            return Created($"api/todoItem/{todoItem.Id}", todoItem);
        }

    }
}