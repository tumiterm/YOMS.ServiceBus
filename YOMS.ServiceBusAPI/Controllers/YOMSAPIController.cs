using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YOMS.ServiceBus;
using YOMS.ServiceBusAPI.Models;
using YOMS.ServiceBusAPI.Models.Dto;

namespace YOMS.ServiceBusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YOMSAPIController : ControllerBase
    {
        private readonly IMessageBus _messageBus;
        private IConfiguration _configuration;
        public YOMSAPIController(IMessageBus messageBus, IConfiguration configuration)
        {
            _messageBus = messageBus;

            _configuration = configuration;
        }

        //invoke this endpoint to web project
        //e.g yomsServices.EmailMessage(yomsDTO)
        public async Task<object> EmailRequest([FromBody] ProfillingDTO profilling)
        {
            try
            {

                await _messageBus.PublishMessage(profilling, _configuration.GetValue<string>("TopicAndQueNames:yomstest"));

            }catch(Exception ex) { 
            
            }

            return "whatever";

        }
    }
}
