using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using schedul.er.Contexts;
using schedul.er.DTOs.EventTypeDTOs;
using schedul.er.Models;

namespace schedul.er.Services.EventTypeServices
{
    public class EventTypeService : IEventTypeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EventTypeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // CREATE
        public async Task<EventType> Create(CreateEventTypeDTO eventTypeDTO)
        {
            var existing = await CheckExistingType(eventTypeDTO.Type);

            if (existing != null)
                throw new InvalidOperationException("Event Type Already Exists.");

            var eventType = _mapper.Map<EventType>(eventTypeDTO);

            eventType.Type.Trim();

            _context.EventTypes.Add(eventType);
            await _context.SaveChangesAsync();

            return eventType;
        }

        // READ ALL
        public async Task<List<EventType>> Read()
        {
            var eventTypes = await _context.EventTypes
                .OrderBy(et => et.Type)
                .ToListAsync();

            return eventTypes;
        }

        // READ BY ID
        public async Task<EventType> Read(int id)
        {
            var eventType = await _context.EventTypes
                .Where(et => et.Id == id)
                .FirstOrDefaultAsync();

            if (eventType == null)
                throw new KeyNotFoundException("Event Type Not Found.");

            return eventType;
        }

        // UPDATE
        public async Task<EventType> Update(EventType updateEventType)
        {
            var existing = await CheckExistingType(updateEventType.Type);

            if (existing != null && existing.Id != updateEventType.Id)
                throw new InvalidOperationException("Event Type Already Exists.");

            var eventType = await Read(updateEventType.Id);

            eventType = _mapper.Map(updateEventType, eventType);

            _context.EventTypes.Update(eventType);
            await _context.SaveChangesAsync();

            return eventType;
        }

        // DELETE
        public async Task<EventType> Delete(int id)
        {
            if (await CheckReferencedType(id))
                throw new InvalidOperationException("There Exists An Event With This Type. Delete Not Allowed.");

            var eventType = await Read(id);

            _context.EventTypes.Remove(eventType);
            await _context.SaveChangesAsync();

            return eventType;
        }

        private async Task<EventType?> CheckExistingType(string type)
        {
            var existingType = await _context.EventTypes
                .Where(et => et.Type.ToLower() == type.ToLower().Trim())
                .FirstOrDefaultAsync();

            return existingType;
        }

        private async Task<bool> CheckReferencedType(int id)
        {
            var eventWithType = await _context.Events
                .Where(e => e.EventTypeId == id)
                .AnyAsync();

            return eventWithType;
        }
    }
}
