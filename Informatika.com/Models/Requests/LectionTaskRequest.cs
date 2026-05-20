namespace Informatika.Application.Models.Requests
{
    public class LectionTaskRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? Deadline { get; set; }
    }
}
