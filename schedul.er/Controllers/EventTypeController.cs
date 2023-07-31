using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using schedul.er.DTOs.EventTypeDTOs;
using schedul.er.Models;
using schedul.er.Services.EventTypeServices;
using schedul.er.Utils;
using System.Diagnostics.Eventing.Reader;

namespace schedul.er.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IEventTypeService _eventTypeService;

        public EventTypeController(IEventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }

        // CREATE
        [HttpPost]
        public async Task<ActionResult> Create(CreateEventTypeDTO eventTypeDTO)
        {
            try
            {
                return Ok(await _eventTypeService.Create(eventTypeDTO));
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
                return Ok(await _eventTypeService.Read());
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
                return Ok(await _eventTypeService.Read(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        // UPDATE
        [HttpPut]
        public async Task<ActionResult> Update(EventType eventType)
        {
            try
            {
                return Ok(await _eventTypeService.Update(eventType));
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
                return Ok(await _eventTypeService.Delete(id));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }
    }
}
