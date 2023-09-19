using Domain.Core.Entities;

namespace Domain.Todo;

public class Todo : Entity<Todo>
{
    public string Task { get; set; }
    public bool Made { get; set; }

    public Todo(string task, bool made)
    {
        Task = task;
        Made = made;
    }
    
    public override bool IsValid()
    {
        throw new NotImplementedException();
    }

    public class Factory
    {
        private string _task;
        private bool _made;

        public Todo Criar(string task, bool made)
        {
            return new Todo(task, made);
        }
    }
}