using LogProxyAPI.Models.Request;
using LogProxyAPI.Models.Response;
using System.Threading.Tasks;

namespace LogProxyAPI.BusinessLogic
{
    /// <summary>
    /// Interface containing definition to implement business logic for the application
    /// </summary>
    public interface IHandler
    {
        Task<string> CallAirTableGetLogs(int maxRecordsToFetch);

        Task<string> CallAirTableCreateLogs(CreateLogRequest request);

        GetLogResponse[] ParseToGetReponse(string result);

        CreateLogResponse ParseToPostReponse(string result);
    }
}
