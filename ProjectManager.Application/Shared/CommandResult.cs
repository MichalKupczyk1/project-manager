namespace ProjectManager.Application.Shared
{
    public class CommandResult
    {
        public required bool IsSuccess { get; set; }
        public object? Data { get; set; }
    }
}
