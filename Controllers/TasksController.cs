using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using get_post_action_task.Models;
using get_post_action_task.Services;

namespace TaskController.Controllers
{
    [Route("/lists/{id}/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        TodoService service;
        public TasksController(TodoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<TodoTask>> GetTasksInTaskListById(int id)
        {
            return service.GetAllTasksByListId(id);
        }

        [HttpGet("")]
        public ActionResult<List<TodoTask>> GetTasksinTaskListById(int id)
        {
            return service.GetAllTasksByListId(id);
        }

        [HttpPost("")]
        public ActionResult<List<TodoTask>> PostTModel(int id, TodoTask task)
        {
            service.AddTaskInTaskListById(id, task);
            return null;
        }
        
    }
}
