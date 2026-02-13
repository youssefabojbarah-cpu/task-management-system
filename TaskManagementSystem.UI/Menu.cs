using System;
using TaskManagementSystem.Services;
using TaskManagementSystem.Models;
using TaskStatus = TaskManagementSystem.Models.TaskStatus;

namespace TaskManagementSystem.UI
{
    public class Menu
    {
        private TaskService taskService;

        public Menu()
        {
            taskService = new TaskService();
        }
        public void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("=================================");
            Console.WriteLine("      TASK MANAGEMENT SYSTEM     ");
            Console.WriteLine("=================================");
            Console.ResetColor();

            Console.WriteLine("[1] Add Task");
            Console.WriteLine("[2] View Tasks");
            Console.WriteLine("[3] Delete Task");
            Console.WriteLine("[4] Change Status");
            Console.WriteLine("[5] Exit");

            Console.Write("Enter your choice: ");
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;

                    case "2":
                        ViewTasks();
                        break;

                    case "3":
                        DeleteTask();
                        break;

                    case "4":
                        ChangeStatus();
                        break;

                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        private void AddTask()
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();

            Console.Write("Enter task description: ");
            string description = Console.ReadLine();

            int id = taskService.GetAllTasks().Count + 1;

            TaskItem task = new TaskItem(
                id,
                title,
                description,
                TaskStatus.Pending
            );

            taskService.AddTask(task);

            Console.WriteLine("Task added successfully!");
        }
        private void ViewTasks()
        {
            var tasks = taskService.GetAllTasks();

            if (tasks.Count == 0)
            {
                Console.WriteLine("There are no tasks.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {tasks[i].Title} - {tasks[i].Status}");
            }
        }
        private void DeleteTask()
        {       
            var task = taskService.GetAllTasks();

            if (task.Count == 0)
            {
                Console.WriteLine("There are no tasks to delete.");
                return;
            }

            ViewTasks();
            Console.Write("Enter task number to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            int index = id - 1;

            try
            {
                taskService.DeleteTask(index);
                 Console.WriteLine("Task deleted successfully!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Task number does not exist.");
            }
        }
        private void ChangeStatus()
        {
            var tasks = taskService.GetAllTasks();

            if (tasks.Count == 0)
            {
                Console.WriteLine("Ther are no tasks.");
                return;
            }

            ViewTasks();
            
            Console.Write("Enter task number: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            int index = id - 1;

            Console.WriteLine("Select new status:");
            Console.WriteLine("1. Pending");
            Console.WriteLine("2. Completed");
            Console.WriteLine("3. Canceled");

            string choice = Console.ReadLine();

            TaskStatus status;

           
            switch (choice)
            {
                case "1":
                    status = TaskStatus.Pending;
                    break;

                case "2":
                    status = TaskStatus.Completed;
                    break;

                case "3":
                    status = TaskStatus.Canceled;
                    break;

                default:
                    Console.WriteLine("Invalid status.");
                    return;
            }

            try
            {
                taskService.ChangeStatus(index, status);
                 Console.WriteLine("Status updated successfully!");
            }
            catch
            {
                Console.WriteLine("Task number does not exist.");
            }

        }
    }   
}