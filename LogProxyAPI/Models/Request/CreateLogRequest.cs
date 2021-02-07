using System;

namespace LogProxyAPI.Models.Request
{
    /// <summary>
    /// List of Request object to create log messages
    /// </summary>
    public class CreateLogRequest
    {
        public LogRequest[] LogRequest { get; set; }
    }

    /// <summary>
    /// Request object to create log messages
    /// </summary>
    public class LogRequest
    {
        private static Random _random = new Random();

        public string Id { get; } = _random.Next(1, 9999).ToString();

        public string Title { get; set; }

        public string Text { get; set; }

        public string ReceivedAt { get; } = DateTime.UtcNow.ToString("o");
    }
}
