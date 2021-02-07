using Newtonsoft.Json;
using System;

namespace LogProxyAPI.Models.Response
{
    /// <summary>
    /// Response object to get log messages
    /// </summary>
    public class GetLogResponse
    {
        public string Id { get; set; }

        [JsonProperty("summary")]
        public string Title { get; set; }
        
        [JsonProperty("message")]
        public string Text { get; set; }
        
        public DateTime ReceivedAt { get; set; }
    }
}
