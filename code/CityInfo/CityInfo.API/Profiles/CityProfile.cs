using AutoMapper;

namespace CityInfo.API.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            //mapping from City Entity to the CityWithoutPointsOfInterestDto
            CreateMap<Entities.City, Models.CityWihoutPointsOfInterestDto>();
            CreateMap<Entities.City, Models.CityDto>();
        }
    }
}
