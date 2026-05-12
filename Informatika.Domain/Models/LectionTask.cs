using Templates;


namespace Informatika.Domain.Models
{
    public class LectionTask : BaseBdEntityWithId
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeadLine { get; set; }

        public List<TaskResource> TaskResources { get; set; } = [];

        public Guid LectionId { get; set; }
        public Lection Lection { get; set; }

        public List<ConfirmedTask> ConfirmedTask { get; set; } = [];
    }
}
