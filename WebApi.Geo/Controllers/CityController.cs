using Microsoft.AspNetCore.Mvc;
using WebApi.Geo.Services;
using WebApi.Geo.Storage.Entities;
using WebApi.Geo.Storage;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using WebApi.Geo.CrossCutting.Dtos;
using System.Linq;
using System.Collections.Generic;

namespace SzkolenieTechniczne.Geo.Controllers
{
    [Route("/geo")]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("cities")]
        public async Task<IEnumerable<CityDto>> Read() => await _cityService.Get();

        [HttpGet("cities/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var cityDto = await _cityService.GetById(id);

            if (cityDto == null)
            {
                return NotFound();
            }

            return Ok(cityDto);
        }

        [HttpPost("city")]
        public async Task<IActionResult> Create([FromBody] CityDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _cityService.Create(dto);

            return Ok(operationResult.Result);
        }
    }
}