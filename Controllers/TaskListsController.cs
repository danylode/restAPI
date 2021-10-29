using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using get_post_action_task.Models;
using get_post_action_task.Services;
using Microsoft.AspNetCore.JsonPatch;

namespace get_post_action_task.Controllers
{
    [Route("/lists")]
    [ApiController]
    public class TaskListsContoller : ControllerBase
    {
        TodoService service;
        public TaskListsContoller(TodoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<TaskList>> GetTaskLists()
        {
            return Ok(service.GetAllTaskLists());
        }

        [HttpGet("{id}")]
        public ActionResult<List<TodoTask>> GetTasksByTaskListId(int id)
        {
            return Ok(service.GetAllTasksByListId(id));
        }

        [HttpPost("")]
        public ActionResult<List<TaskList>> PostTaskList(TaskList list)
        {
            return ActionStatus(service.PostTaskList(list));
        }

        [HttpDelete("")]
        public ActionResult DeleteTaskList(int id)
        {
            return ActionStatus(service.DeleteTaskListById(id));
        }

        [HttpPut("{id}")]
        public ActionResult<List<TaskList>> PutTaskList(int id, TaskList list)
        {
            return ActionStatus(service.ReplaceTaskListById(id, list));
        }

        private ActionResult ActionStatus(bool result)
        {
            if (result)
            {
                return Ok(service.GetAllTaskLists());
            }
            else
            {
                return NotFound();
            }
        }
    }
}