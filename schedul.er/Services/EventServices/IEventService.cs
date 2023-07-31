using schedul.er.DTOs.EventDTOs;
using schedul.er.Models;

namespace schedul.er.Services.EventServices
{
    public interface IEventService
    {
        Task<Event> Create(CreateEventDTO eventDTO);
        Task<Event> Delete(int id);
        Task<List<Event>> Read();
        Task<Event> Read(int id);
        Task<Event> Update(UpdateEventDTO eventDTO);
    }
}
