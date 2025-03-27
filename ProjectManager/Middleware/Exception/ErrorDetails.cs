using System.Text.Json;

namespace ProjectManager.Middleware.Exception
{
    public class ErrorDetails
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
