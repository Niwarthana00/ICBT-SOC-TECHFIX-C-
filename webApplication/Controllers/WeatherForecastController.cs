using Microsoft.AspNetCore.Mvc;
using webApplication.service;

namespace webApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _service;

        public WeatherForecastController(WeatherForecastService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var forecasts =  _service.GetAllForecastsAsync();
            return Ok(forecasts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var forecast = await _service.GetForecastByIdAsync(id);
            if (forecast == null) return NotFound();
            return Ok(forecast);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WeatherForecast forecast)
        {
            await _service.AddForecastAsync(forecast);
            return CreatedAtAction(nameof(GetById), new { id = forecast.Id }, forecast);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, WeatherForecast forecast)
        {
            if (id != forecast.Id) return BadRequest();
            await _service.UpdateForecastAsync(forecast);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteForecastAsync(id);
            return NoContent();
        }

    }
}
