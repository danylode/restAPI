using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using get_post_action_task.Models;
using get_post_action_task.Services;

namespace TaskController.Controllers
{
    [Route("/lists/{listId}/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        TodoService service;
        public TasksController(TodoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<TodoTask>> GetTasksInTaskListById(int listId)
        {
            return service.GetAllTasksByListId(listId);
        }

        [HttpPost]
        public ActionResult<List<TodoTask>> PostTask(int listId, TodoTask task)
        {
            service.AddTaskInTaskListById(listId, task);
            return service.GetAllTasksByListId(listId);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<TodoTask>> DeleteTask(int listId, int id)
        {
            
            return null;
        }
        
        
    }
}
