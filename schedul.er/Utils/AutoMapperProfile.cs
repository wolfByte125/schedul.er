using AutoMapper;
using schedul.er.DTOs.EventDTOs;
using schedul.er.DTOs.EventTypeDTOs;
using schedul.er.Models;

namespace schedul.er.Utils
{
    public class AutoMapperProfile : Profile
    {
        private readonly IMapper _mapper;

        public AutoMapperProfile(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AutoMapperProfile()
        {
            // EVENT TYPE
            CreateMap<CreateEventTypeDTO, EventType>();

            // EVENT
            CreateMap<CreateEventDTO, Event>();
            CreateMap<UpdateEventDTO, Event>();
        }
    }
}
