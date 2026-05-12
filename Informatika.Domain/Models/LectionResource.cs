using Templates;


namespace Informatika.Domain.Models
{
    public class LectionResource : BaseBdEntityWithId
    {
        public string Path { get; set; }

        public Guid LectionId { get; set; }
        public Lection Lection  { get; set; }
    }
}
