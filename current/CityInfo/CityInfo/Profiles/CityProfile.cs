using AutoMapper;
using CityInfo.Models;

namespace CityInfo.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
    {
            CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
        
    }
}
}
