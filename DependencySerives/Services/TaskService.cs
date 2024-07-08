using DependencySerives.Interface;

namespace DependencySerives.Services
{
    public class TaskService : IScopedService, ISingletonService, ITransientService
    {
        Guid id;
        public TaskService()
        {
            id = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return id;
        }
    }
}
