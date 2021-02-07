using LogProxyAPI.Models.Request;
using LogProxyAPI.Models.Response;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LogProxyAPI.BusinessLogic
{
    /// <summary>
    /// Class containing business logic for the application
    /// </summary>
    public class Handler : IHandler
    {
        private IConfiguration _configuration { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Handler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Method to invoke AirTable GET endpoint
        /// </summary>
        /// <param name="maxRecordsToFetch">Maximum number of records to fetch</param>
        /// <returns></returns>
        public async Task<string> CallAirTableGetLogs(int maxRecordsToFetch)
        {
            // Read properties from appsettings.json
            string url = _configuration["AirTableGetUri"];
            string apiKey = _configuration["AirTableApiKey"];

            HttpResponseMessage response = null;
            using (var httpClient = new HttpClient())
            {
                // Add API key as bearer in authorization header
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                // Invoke AirTable GET endpoint to fetch log messages
                response = await httpClient.GetAsync(string.Format(url, maxRecordsToFetch));
            }

            return await response?.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Method to invoke AirTable POST endpoint
        /// </summary>
        /// <param name="request">Create log request</param>
        /// <returns></returns>
        public async Task<string> CallAirTableCreateLogs(CreateLogRequest request)
        {
            // Read properties from appsettings.json
            string url = _configuration["AirTablePostUri"];
            string apiKey = _configuration["AirTableApiKey"];

            // Logic to convert given request to AirTable request
            var airTableRequest = new JObject();
            var fields = new JArray();
            foreach (var log in request.LogRequest)
            {
                var fieldItem = new JObject();
                fieldItem.Add("id", log.Id);
                fieldItem.Add("Summary", log.Title);
                fieldItem.Add("Message", log.Text);
                fieldItem.Add("receivedAt", log.ReceivedAt);

                var fieldObject = new JObject();
                fieldObject.Add("fields", fieldItem);

                fields.Add(fieldObject);
            }
            airTableRequest.Add("records", fields);

            HttpResponseMessage response = null;
            using (var httpClient = new HttpClient())
            {
                // Add API key as bearer in authorization header
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                string jsonRequest = JsonConvert.SerializeObject(airTableRequest);
                var stringContent = new StringContent(jsonRequest, UnicodeEncoding.UTF8, "application/json");

                // Invoke AirTable POST endpoint to create log messages
                response = await httpClient.PostAsync(url, stringContent);
            }

            return await response?.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Method to parse AirTable GET response to custom response
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public GetLogResponse[] ParseToGetReponse(string result)
        {
            // Parse the string of result to JObject
            var parsedToJson = JObject.Parse(result);

            // Extract only 'fields' part from JObject where 'id' property is not null
            var fields = parsedToJson["records"].Children()["fields"];

            // Serialize filterd list of JToken to string
            var stringOfFields = JsonConvert.SerializeObject(fields);

            // Deserialize string to strong typed objects
            return JsonConvert.DeserializeObject<GetLogResponse[]>(stringOfFields);
        }

        /// <summary>
        /// Method to parse AirTable POST response to custom response
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public CreateLogResponse ParseToPostReponse(string result)
        {
            // Deserialize result to strong typed objects
            return JsonConvert.DeserializeObject<CreateLogResponse>(result);
        }
    }
}
