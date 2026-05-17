using AutoMapper;
using StadiumAnalytics.API.Models.Dtos;
using StadiumAnalytics.API.Models.Entities;

namespace StadiumAnalytics.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateSensorEventRequest, SensorEvent>().ReverseMap();

            CreateMap<SensorEvent, SensorSummaryDto>().ReverseMap();
        }
    }
}
