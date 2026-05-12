using Informatika.Domain.Enums;
using Templates;

namespace Informatika.Domain.Models
{
    public class ConfirmedTask : BaseBdEntityWithId
    {
        public Guid LectionTaskId { get; set; }
        public LectionTask LectionTask { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime GaveAt { get; set; } = DateTime.UtcNow;

        public int? Mark { get; set; }

        public ConfirmedTaskStatus TaskStatus { get; set; } = ConfirmedTaskStatus.NoChecked;

        public string? Text { get; set; }

        public string Path { get; set; } = null!;
    }
}
