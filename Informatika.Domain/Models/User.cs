using Informatika.Domain.Enums;
using Templates;


namespace Informatika.Domain.Models
{
    public class User : BaseBdEntityWithId
    {
        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public Role? Role { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? AvatarURL { get; set; }

        public string Email { get; set; } = null!;

        public List<ConfirmedTask> ConfirmedTasks { get; set; } = [];

        public List<UserActionLog> UserActionLogs { get; set; } = [];

        public Guid? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
