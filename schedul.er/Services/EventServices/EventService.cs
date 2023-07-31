using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using schedul.er.Contexts;
using schedul.er.DTOs.EventDTOs;
using schedul.er.Models;

namespace schedul.er.Services.EventServices
{
    public class EventService : IEventService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EventService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // CREATE
        public async Task<Event> Create(CreateEventDTO eventDTO)
        {
            var alreadyReserved = await CheckTimeReserved(eventDTO.StartDate, eventDTO.EndDate);

            if (alreadyReserved != null)
                throw new InvalidOperationException("Time Is Already Reserved.");

            var newEvent = _mapper.Map<Event>(eventDTO);

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            return newEvent;
        }

        // READ ALL
        public async Task<List<Event>> Read()
        {
            var events = await _context.Events
                .OrderBy(e => e.StartDate)
                .ToListAsync();

            return events;
        }

        // READ BY ID
        public async Task<Event> Read(int id)
        {
            var singleEvent = await _context.Events
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (singleEvent == null)
                throw new KeyNotFoundException("Event Not Found.");

            return singleEvent;
        }

        // UPDATE
        public async Task<Event> Update(UpdateEventDTO eventDTO)
        {
            var alreadyReserved = await CheckTimeReserved(eventDTO.StartDate, eventDTO.EndDate);

            if (alreadyReserved != null && alreadyReserved.Id == eventDTO.Id)
                throw new InvalidOperationException("Time Is Already Reserved.");

            var singleEvent = await Read(eventDTO.Id);

            singleEvent = _mapper.Map(eventDTO, singleEvent);

            _context.Events.Update(singleEvent);
            await _context.SaveChangesAsync();

            return singleEvent;
        }

        // DELETE
        public async Task<Event> Delete(int id)
        {
            var singleEvent = await Read(id);

            _context.Events.Remove(singleEvent);
            await _context.SaveChangesAsync();

            return singleEvent;
        }


        private async Task<Event?> CheckTimeReserved(DateTime startDate, DateTime endDate)
        {
            var alreadyReserved = await _context.Events
                .Where(ar =>
                (ar.StartDate <= startDate &&
                ar.EndDate >= endDate) ||
                ar.StartDate == startDate || 
                ar.EndDate == endDate)
                .FirstOrDefaultAsync();

            return alreadyReserved;
        }
    }
}
