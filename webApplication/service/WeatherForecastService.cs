using webApplication.persistance;

namespace webApplication.service
{
    public class WeatherForecastService
    {
        private readonly AppDbContext _dbContext;

        public WeatherForecastService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  List<WeatherForecast> GetAllForecastsAsync()
        {
            return  _dbContext.WeatherForecasts.ToList();
        }

        public async Task<WeatherForecast> GetForecastByIdAsync(int id)
        {
            return await _dbContext.WeatherForecasts.FindAsync(id);
        }

        public async Task AddForecastAsync(WeatherForecast forecast)
        {
            _dbContext.WeatherForecasts.Add(forecast);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateForecastAsync(WeatherForecast forecast)
        {
            _dbContext.WeatherForecasts.Update(forecast);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteForecastAsync(int id)
        {
            var forecast = await _dbContext.WeatherForecasts.FindAsync(id);
            if (forecast != null)
            {
                _dbContext.WeatherForecasts.Remove(forecast);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
