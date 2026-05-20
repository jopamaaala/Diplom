namespace Informatika.Application.Models.Requests
{
    public class LectionUpdateRequest
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? LectionText { get; set; }

        public List<LectionTaskRequest> Tasks { get; set; } = [];

        public List<LectionResourcesRequest> Resources { get; set; } = [];
    }
}
