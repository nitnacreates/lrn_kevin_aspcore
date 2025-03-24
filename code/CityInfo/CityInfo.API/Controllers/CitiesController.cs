using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    //[Route("api/cities")]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(
            ICityInfoRepository cityInfoRepository,
            IMapper mapper
        )
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWihoutPointsOfInterestDto>>> GetCities()
        {
            //return Ok(_citiesDataStore.Cities);
            var cityEntities = await _cityInfoRepository.GetCitiesAsync();

            return Ok(_mapper.Map<IEnumerable<CityWihoutPointsOfInterestDto>>(cityEntities));
            /*
            var results = new List<CityWihoutPointsOfInterestDto>();
            foreach (var cityEntity in cityEntities)
            {
                results.Add(new CityWihoutPointsOfInterestDto
                {
                    Id = cityEntity.Id,
                    Description = cityEntity.Description,
                    Name = cityEntity.Name
                });
            }

            return Ok(results);
            */


        }

        [HttpGet("{id}")]
        //public async Task<ActionResult<CityDto>> GetCity(int id, bool includePointsOfInterestId = false)
        public async Task<IActionResult> GetCity(int id, bool includePointsOfInterestId = false)
        {
            var city = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterestId);
            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterestId)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }

            return Ok(_mapper.Map<CityWihoutPointsOfInterestDto>(city));
        }
    }
}
