using Informatika.Domain.Enums;
using Templates;

namespace Informatika.Domain.Models
{
    public class UserActionLog : BaseBdEntityWithId
    {
        public Guid UserId {  get; set; }
        public User User { get; set; }

        public DateTime ActionedAt { get; set; } = DateTime.UtcNow;

        public UserLogAction LogAction { get; set; }

        public LogLevel LogLevel { get; set; }

        public string Message { get; set; } = null!;
    }
}
