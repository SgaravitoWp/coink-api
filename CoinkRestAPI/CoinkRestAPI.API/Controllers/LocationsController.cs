using Microsoft.AspNetCore.Mvc;
using CoinkRestAPI.CORE.DTOs;
using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.Interfaces;

namespace CoinRestAPI.API.Controllers
{
    [ApiController]
    [Route("")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Route("listCountries")]
        [ProducesResponseType(typeof(SuccessResponse<Country>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListCountries()
        {
            var countries = await _locationService.GetCountriesAsync();
            return Ok(new SuccessResponse<Country>
            {
                success = true,
                message = "Countries",
                data = countries,
                status_code = 200
            });
        }

        [HttpGet]
        [Route("listStates")]
        [ProducesResponseType(typeof(SuccessResponse<State>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListStates([FromQuery] StateGet state)
        {
            var states = await _locationService.GetStatesByCountryAsync(state.country_id);
            string message = states.Any() ? "States" : "No states found for the provided data.";
            return Ok(new SuccessResponse<State>
            {
                success = true,
                message = message,
                data = states,
                status_code = 200
            });
        }

        [HttpGet]
        [Route("listCities")]
        [ProducesResponseType(typeof(SuccessResponse<City>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListCities([FromQuery] CityGet city)
        {
            var cities = await _locationService.GetCitiesByStateAsync(city.state_id);
            string message = cities.Any() ? "Cities" : "No cities found for the provided data.";
            return Ok(new SuccessResponse<City>
            {
                success = true,
                message = message,
                data = cities,
                status_code = 200
            });
        }
    }
}