using System;

namespace LogProxyAPI.Models.Response
{
    /// <summary>
    /// List of Response object to create log messages
    /// </summary>
    public class CreateLogResponse
    {
        public Record[] Records { get; set; }
    }

    /// <summary>
    /// Response object to create log messages
    /// </summary>
    public class Record
    {
        public string Id { get; set; }
        public Fields Fields { get; set; }
        public DateTime CreatedTime { get; set; }
    }

    /// <summary>
    /// Fields in response object
    /// </summary>
    public class Fields
    {
        public string Id { get; set; }
        public string Summary { get; set; }
        public string Message { get; set; }
        public DateTime ReceivedAt { get; set; }
    }

}
