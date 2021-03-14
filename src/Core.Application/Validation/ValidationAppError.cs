namespace Core.Application
{
    public class ValidationAppError
    {
        public string Message { get; set; }
        public ValidationAppError(string message)
        {
            this.Message = message;
        }
    }
}
