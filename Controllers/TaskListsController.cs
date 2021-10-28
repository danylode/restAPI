using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using get_post_action_task.Models;
using get_post_action_task.Services;

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
            return service.GetAllTaskLists();
        }

        [HttpGet("{id}")]
        public ActionResult<List<TodoTask>> GetTasksByTaskListId(int id)
        {
            return service.GetAllTasksByListId(id);
        }

        [HttpPost("")]
        public ActionResult<List<TaskList>> PostTaskList(TaskList list)
        {
            service.PostTaskList(list);
            return service.GetAllTaskLists();
        }

        [HttpDelete("")]
        public ActionResult<List<TaskList>> DeleteTaskList(int id)
        {
            service.DeleteTaskListById(id);
            return service.GetAllTaskLists() ;
        }

        [HttpPut("")]
        public ActionResult<List<TaskList>> PutTaskList(int id, TaskList list)
        {
            service.ReplaceTaskListById(id, list);
            return service.GetAllTaskLists();
        }

        [HttpPatch("")]
        public ActionResult<List<TaskList>> PatchTaskList(int id, [FromQuery] TaskList list){
            return service.GetAllTaskLists();
        }

    }
}