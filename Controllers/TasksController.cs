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

        [HttpPost]
        public ActionResult<List<TodoTask>> PostTask(int listId, TodoTask task)
        {
            return ActionStatus(service.AddTaskInTaskListById(listId, task));
        }

        [HttpDelete("{id}")]
        public ActionResult<List<TodoTask>> DeleteTask(int listId, int id)
        {

            return ActionStatus(service.DeleteTaskInTaskListById(listId, id));
        }

        [HttpPut("{id}")]
        public IActionResult PutTodoTask(int taskList, int id, TodoTask task)
        {
            return ActionStatus(service.ReplaceTaskInTaskListById(taskList, id, task));
        }

        [HttpPatch("{id}")]
        public IActionResult PatchTodoTask(int listId, int id, [FromBody] JsonPatchDocument<TodoTask> list)
        {
            try
            {
                list.ApplyTo(service.GetAllTasksByListId(listId)[id]);
                return Ok();
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }

        private ActionResult ActionStatus(bool result)
        {
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
