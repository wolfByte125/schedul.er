using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using schedul.er.DTOs.EventDTOs;
using schedul.er.Services.EventServices;
using schedul.er.Utils;

namespace schedul.er.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // CREATE
        [HttpPost]
        public async Task<ActionResult> Create(CreateEventDTO eventDTO)
        {
            try
            {
                return Ok(await _eventService.Create(eventDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // READ ALL
        [HttpGet]
        public async Task<ActionResult> Read()
        {
            try
            {
                return Ok(await _eventService.Read());
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // READ BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult> Read(int id)
        {
            try
            {
                return Ok(await _eventService.Read(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // UPDATE
        [HttpPut]
        public async Task<ActionResult> Update(UpdateEventDTO eventDTO)
        {
            try
            {
                return Ok(await _eventService.Update(eventDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _eventService.Delete(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }
    }
}
