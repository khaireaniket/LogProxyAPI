using LogProxyAPI.BusinessLogic;
using LogProxyAPI.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LogProxyAPI.Controllers
{
    /// <summary>
    /// Log delegator controller containing action methods to GET and POST log messages
    /// </summary>
    [Authorize]
    [Route("api/delegator")]
    [ApiController]
    [Produces("application/json")]
    public class LogDelegatorController : ControllerBase
    {
        private IHandler _handler { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handler"></param>
        public LogDelegatorController(IHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Action method to get log messages from AirTable endpoint
        /// </summary>
        /// <param name="maxRecordsToFetch"></param>
        /// <returns></returns>
        [Route("messages")]
        [HttpGet]
        public async Task<ActionResult> GetLogMessages([FromQuery] int maxRecordsToFetch = 3)
        {
            string result = await _handler.CallAirTableGetLogs(maxRecordsToFetch);
            if (string.IsNullOrEmpty(result))
            {
                return NotFound();
            }

            var logMessages = _handler.ParseToGetReponse(result);
            return Ok(logMessages);
        }

        /// <summary>
        /// Action method to create log messages using AirTable endpoint
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("messages")]
        [HttpPost]
        public async Task<ActionResult> CreateLogMessages([FromBody] CreateLogRequest request)
        {
            if (request == null || request.LogRequest == null || request.LogRequest.Count() < 1)
            {
                return BadRequest();
            }

            string result = await _handler.CallAirTableCreateLogs(request);
            if (string.IsNullOrEmpty(result))
            {
                return NotFound();
            }

            var createdLogs = _handler.ParseToPostReponse(result);
            return Ok(createdLogs);
        }
    }
}


