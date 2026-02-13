using TaskManagementSystem.Models;
using System.Collections.Generic;
using TaskStatus = TaskManagementSystem.Models.TaskStatus;

namespace TaskManagementSystem.Services
{
    public class TaskService
    {
        private List<TaskItem> tasks;
        public TaskService()
        {
            tasks = new List<TaskItem>();
        }
        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
        }
        public List<TaskItem> GetAllTasks()
        {
            return tasks;
        }
        public void DeleteTask(int index)
        {
            if (index < 0 || index >= tasks.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid task index");
            }

            tasks.RemoveAt(index);
        }
        public void ChangeStatus(int index, TaskStatus status)
        {
            if (index < 0 || index >= tasks.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid task index");
            }

            tasks[index].Status = status;
        }
    }
}
