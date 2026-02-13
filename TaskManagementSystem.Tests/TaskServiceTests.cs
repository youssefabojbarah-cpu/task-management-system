using Xunit;
using TaskStatus = TaskManagementSystem.Models.TaskStatus;
using TaskManagementSystem.Services;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Tests
{
    public class TaskServiceTests
    {
        [Fact]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            TaskService service = new TaskService();

            TaskItem task = new TaskItem(
                1,
                "Study OOP",
                "Finish lesson",
                TaskStatus.Pending
            );

            service.AddTask(task);

            Assert.Single(service.GetAllTasks());
        }

        [Fact]
        public void DeleteTask_ShouldDecreaseTaskCount()
        {   
            TaskService service = new TaskService();
            TaskItem task1 = new TaskItem(
                1,
                "Study OOP",
                "Finish lesson",
                TaskStatus.Pending
            );

            TaskItem task2 = new TaskItem(
                2,
                "Study English",
                "Finish lesson",
                TaskStatus.Pending
            );

            service.AddTask(task1);
            service.AddTask(task2);
            service.DeleteTask(1);

            Assert.Single(service.GetAllTasks());
        }

        [Fact]
        public void ChangeStatus_ShouldUpdateTaskStatus()
        {
            TaskService service = new TaskService();
            TaskStatus status = TaskStatus.Completed;
            TaskItem task1 = new TaskItem(
                1,
                "Study OOP",
                "Finish lesson",
                TaskStatus.Pending
            );

            service.AddTask(task1);
            service.ChangeStatus(0, status);

            Assert.Equal(status, service.GetAllTasks()[0].Status);
        }

        [Fact]
        public void DeleteTask_InvalidIndex_ShouldThrowException()
        {
            TaskService service = new TaskService();

            Assert.Throws<ArgumentOutOfRangeException>(() => service.DeleteTask(0));            
        }
    }
}