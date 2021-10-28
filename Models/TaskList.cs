using System;
using System.Collections.Generic;

namespace get_post_action_task.Models
{
    public class TaskList
    {
        public string name {get;set;}
        public List<TodoTask> Tasks {get;set;}
        public int lastId {get;set;}
    }
}