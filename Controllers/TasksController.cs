using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using get_post_action_task.Models;
using get_post_action_task.Services;
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpGet("{id}")]
        public ActionResult<TodoTask> GetTaskByIdInTaskListById(int listId, int id)
        {
            return service.GetAllTasksByListId(listId)[id];
        }

        [HttpPost]
        public ActionResult<List<TodoTask>> PostTask(int listId, TodoTask task)
        {
            return ActionStatus(listId, service.AddTaskInTaskListById(listId, task));
        }

        [HttpDelete("{id}")]
        public ActionResult<List<TodoTask>> DeleteTask(int listId, int id)
        {
            return ActionStatus(listId, service.DeleteTaskInTaskListById(listId, id));
        }

        [HttpPut("{id}")]
        public IActionResult PutTodoTask(int listId, int id, TodoTask task)
        {
            return ActionStatus(listId, service.ReplaceTaskInTaskListById(listId, id, task));
        }

        [HttpPatch("{id}")]
        public IActionResult PatchTodoTask(int listId, int id, [FromBody] JsonPatchDocument<TodoTask> list)
        {
            try
            {
                list.ApplyTo(service.GetAllTasksByListId(listId)[id]);
                return Ok(service.GetAllTasksByListId(listId));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        private ActionResult ActionStatus(int listId, bool result)
        {
            if (result)
            {
                return Ok(service.GetAllTasksByListId(listId));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
