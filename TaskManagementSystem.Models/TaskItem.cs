
namespace TaskManagementSystem.Models
{
    public class TaskItem
    {
        private int id;
        private string title;
        private string description;
        private TaskStatus status;
        public int Id
        {
            get => id;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Id must be positive!");
                }
                id = value;
            }
        }
        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid title!");
                }
                title = value;
            }
        }
        public string Description
        {
            get => description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid description!");
                }
                description = value;
            }
        }
        public TaskStatus Status
        {
            get => status;
            set => status = value;
        }
        public TaskItem(int id, string title, string description, TaskStatus status)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
        }       
    }    
}