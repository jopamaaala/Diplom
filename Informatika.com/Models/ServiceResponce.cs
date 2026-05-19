namespace Informatika.Application.Models
{
    public class ServiceResponce<T>
    {
        public bool Success { get; set; } = false;
        public string? Error { get; set; }
        public T? Data { get; set; }
    }
}
