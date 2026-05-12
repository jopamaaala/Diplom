using Templates;


namespace Informatika.Domain.Models
{
    public class TaskResource : BaseBdEntityWithId
    {
        public string Path { get; set; }

        public Guid TaskId { get; set; }
        public LectionTask LectionTask { get; set; }
    }
}
