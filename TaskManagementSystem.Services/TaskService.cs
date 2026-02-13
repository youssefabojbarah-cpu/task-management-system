using TaskManagementSystem.Models;
using System.Collections.Generic;
using TaskStatus = TaskManagementSystem.Models.TaskStatus;

namespace TaskManagementSystem.Services
{
    public class TaskService
    {
        private TaskFileRepository repository;
        private List<TaskItem> tasks;
        public TaskService()
        {
            repository = new TaskFileRepository("tasks.txt");
            tasks = repository.LoadTasks();
        }
        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
            repository.SaveTasks(tasks);
        }
        public List<TaskItem> GetAllTasks()
        {
            return new List<TaskItem>(tasks);
        }
        public void DeleteTask(int index)
        {
            if (index < 0 || index >= tasks.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid task index");
            }

            tasks.RemoveAt(index);
            repository.SaveTasks(tasks);
        }
        public void ChangeStatus(int index, TaskStatus status)
        {
            if (index < 0 || index >= tasks.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid task index");
            }

            tasks[index].Status = status;
            repository.SaveTasks(tasks);
        }
    }
}
