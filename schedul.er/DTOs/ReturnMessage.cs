namespace schedul.er.DTOs
{
    public class ReturnMessage
    {
        public string Message { get; set; } = string.Empty;

        public static ReturnMessage Parse(string message)
        {
            return new ReturnMessage() { Message = message };
        }
    }
}
