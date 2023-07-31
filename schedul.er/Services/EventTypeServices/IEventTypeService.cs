using schedul.er.DTOs.EventTypeDTOs;
using schedul.er.Models;

namespace schedul.er.Services.EventTypeServices
{
    public interface IEventTypeService
    {
        Task<EventType> Create(CreateEventTypeDTO eventTypeDTO);
        Task<EventType> Delete(int id);
        Task<List<EventType>> Read();
        Task<EventType> Read(int id);
        Task<EventType> Update(EventType updateEventType);
    }
}
