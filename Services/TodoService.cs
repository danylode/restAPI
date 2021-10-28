using System;
using System.Collections.Generic;
using get_post_action_task.Models;

namespace get_post_action_task.Services
{
    public class TodoService
    {
        private List<TaskList> todoList = new List<TaskList>();
        private int lastId = 2;

        public TodoService()
        {
            todoList.Add(new TaskList());
            todoList.Add(new TaskList());
            todoList[0].Tasks = new List<TodoTask>(){
                new TodoTask() { Id = 1, Title = "Implement read" }
            };
            todoList[0].lastId = 1;
            todoList[1].Tasks = new List<TodoTask>(){
                new TodoTask() { Id = 2, Title = "Implement create" }
            };;
            todoList[1].lastId = 1;
        }

        public List<TaskList> GetAllTaskLists()
        {
            return todoList;
        }

        public List<TodoTask> GetAllTasksByListId(int listId)
        {
            return todoList[listId].Tasks;
        }

        public TaskList PostTaskList(TaskList list)
        {
            TaskList newList = list;
            todoList.Add(newList);
            lastId++;
            return todoList[lastId];
        }

        public List<TaskList> AddTaskList(TaskList list){
            todoList.Add(list);
            return todoList;
        }

        public List<TodoTask> AddTaskInTaskListById(int listId, TodoTask item)
        {
            TaskList list = todoList[listId];
            list.Tasks.Add(item);
            list.lastId++;
            return list.Tasks;
        }

        public List<TaskList> ReplaceTaskListById(int taskListId, TaskList newList)
        {
            todoList[taskListId] = newList;
            return todoList;
        }

        public List<TodoTask> ReplaceTaskInTaskListById(int taskListId, int taskId, TodoTask newTask)
        {
            todoList[taskListId].Tasks[taskId] = newTask;
            return todoList[taskListId].Tasks;
        }

        public List<TaskList> DeleteTaskListById(int id)
        {
            todoList.RemoveAt(id);
            return todoList;
        }

        public List<TodoTask> DeleteTaskInTaskListById(int taskListId, int itemId)
        {
            TaskList list = todoList[taskListId];
            list.Tasks.RemoveAt(itemId);
            return list.Tasks;
        }

    }
}