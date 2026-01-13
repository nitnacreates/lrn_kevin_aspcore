using AutoMapper;
using CityInfo.Models;

namespace CityInfo.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
    {
            CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
            CreateMap<Entities.City, Models.CityDto>();
        }
}
}
