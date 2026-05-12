using Templates;


namespace Informatika.Domain.Models
{
    public class Lection : BaseBdEntityWithId
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? LectionText { get; set; }

        public List<LectionResource> LectionResources { get; set; } = [];

        public List<LectionTask> LectionTasks { get; set; } = [];
    }
}
