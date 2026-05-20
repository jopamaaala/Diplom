namespace Informatika.Application.Models.Requests
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; } = false;
        public string? Error { get; set; }
        public T? Data { get; set; }
    }
}
