namespace Templates
{
    public class BaseBdEntityWithId
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
