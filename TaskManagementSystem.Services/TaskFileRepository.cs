using TaskManagementSystem.Models;
using System.Collections.Generic;
using System.IO;
using TaskStatus = TaskManagementSystem.Models.TaskStatus;


namespace TaskManagementSystem.Services
{
    public class TaskFileRepository
    {
        private readonly string filePath;

        public TaskFileRepository(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Invalid file path", nameof(filePath));
            }
            this.filePath = filePath;
        }
        public void SaveTasks(List<TaskItem> tasks)
        {
            if (tasks == null)
            {
                throw new ArgumentNullException(nameof(tasks));
            }
            using(StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (TaskItem task in tasks)
                {
                    sw.WriteLine($"{task.Id}|{task.Title}|{task.Description}|{task.Status}");
                }
            }
        }
        public List<TaskItem> LoadTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            if (!File.Exists(filePath))
            {
                return tasks;
            }

            using(StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length != 4)
                    {
                        continue;
                    }
                    
                    int id = int.Parse(parts[0]);
                    string title = parts[1];
                    string description = parts[2];
                    TaskStatus status = Enum.Parse<TaskStatus>(parts[3]);

                    TaskItem task = new TaskItem(id, title, description, status);
                    tasks.Add(task);
                }
            }
            return tasks;
        }
    }
}