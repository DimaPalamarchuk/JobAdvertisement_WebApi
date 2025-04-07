using Microsoft.AspNetCore.Mvc;
using WebApi.Geo.Services;
using WebApi.Geo.CrossCutting.Dtos;

namespace WebApi.Geo.Controllers
{
    [Route("/geo")]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }


        [HttpGet("countries")]
        public async Task<IEnumerable<CountryDto>> Read() => await _countryService.Get();

        [HttpGet("countries/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var cityDto = await _countryService.GetById(id);

            if (cityDto == null)
            {
                return NotFound();
            }

            return Ok(cityDto);
        }

        [HttpPost("country")]
        public async Task<IActionResult> Create([FromBody] CountryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _countryService.Create(dto);

            return Ok(operationResult.Result);
        }
    }
}
