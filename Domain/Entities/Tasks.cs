namespace Domain.Entities
{
    public class Tasks
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsComplete { get; private set; }

        public Tasks(string name, string description)
        {
            Name = name;
            Description = description;
            IsComplete = false;
        }

        public void UpdateTaskValues(string name, string description, bool isComplete)
        {
            Name = name;
            Description = description;
            IsComplete = isComplete;
        }

        public void SetName(string name) { this.Name = name; }
        public void SetDescription(string description) { this.Description = description; }
        public void SetIsComplete(bool isComplete) { this.IsComplete = isComplete; }

    }
}
