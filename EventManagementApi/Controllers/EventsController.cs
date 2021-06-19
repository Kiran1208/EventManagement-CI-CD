using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagementApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository eventsRepository;

        public EventsController(IEventsRepository _eventsRepository)
        {
            this.eventsRepository = _eventsRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<Event>))]
        public IActionResult GetAll() => Ok(eventsRepository.GetAll());

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created ,Type=typeof(Event))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody]Event newEvent)
        {
            if(newEvent.Id < 1)
            {
                return BadRequest("Invalid id");
            }

            eventsRepository.Add(newEvent);
            return Created("TODO", newEvent);
        }
        [HttpDelete]
        [Route("{eventToDeleteId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int eventToDeleteId )
        {
            try
            {
                eventsRepository.Delete(eventToDeleteId);
            }
            catch(ArgumentException)
            {
                return NotFound();
            }
            return NoContent();

        }

        [HttpGet]
        [Route("{eventId}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(Event))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type= typeof(Event))]

        public IActionResult GetById(int eventId)
        {
            return Ok(eventsRepository.GetById(eventId));
        }
    }
}