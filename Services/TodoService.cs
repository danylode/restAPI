using System;
using System.Collections.Generic;
using get_post_action_task.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace get_post_action_task.Services
{
    public class TodoService
    {
        private List<TaskList> todoLists = new List<TaskList>();
        private int lastId = 2;

        public TodoService()
        {
            todoLists.Add(new TaskList());
            todoLists.Add(new TaskList());
            todoLists[0].Tasks = new List<TodoTask>(){
                new TodoTask() { Id = 1, Title = "Implement read" }
            };
            todoLists[0].lastId = 1;
            todoLists[1].Tasks = new List<TodoTask>(){
                new TodoTask() { Id = 2, Title = "Implement create" }
            }; ;
            todoLists[1].lastId = 1;
        }

        public List<TaskList> GetAllTaskLists()
        {
            return todoLists;
        }

        public List<TodoTask> GetAllTasksByListId(int listId)
        {
            return todoLists[listId].Tasks;
        }

        public bool PostTaskList(TaskList list)
        {
            TaskList newList = list;
            todoLists.Add(newList);
            lastId++;
            return true;
        }

        public bool AddTaskList(TaskList list)
        {
            todoLists.Add(list);
            return true;
        }

        public bool AddTaskInTaskListById(int listId, TodoTask item)
        {
            try
            {
                TaskList list = todoLists[listId];
                list.Tasks.Add(item);
                list.lastId++;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ReplaceTaskListById(int taskListId, TaskList newList)
        {
            try
            {
                todoLists[taskListId] = newList;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ReplaceTaskInTaskListById(int taskListId, int taskId, TodoTask newTask)
        {
            try
            {
                todoLists[taskListId].Tasks[taskId] = newTask;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteTaskListById(int id)
        {
            try
            {

                todoLists.RemoveAt(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteTaskInTaskListById(int taskListId, int itemId)
        {
            try
            {
                TaskList list = todoLists[taskListId];
                list.Tasks.RemoveAt(itemId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}