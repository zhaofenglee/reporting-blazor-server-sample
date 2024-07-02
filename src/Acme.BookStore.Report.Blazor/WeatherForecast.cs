using System;
using System.Collections.Generic;

namespace Acme.BookStore.Report.Blazor
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public class WeatherForecastDto
    {
        public WeatherForecastDto()
        {
            Items = InitializeList();
        }
        public List<WeatherForecast> Items { get; set; }

        public List<WeatherForecast> InitializeList()
        {
            //随机生成数据
            return new List<WeatherForecast>
            {
                new WeatherForecast
                {
                    Date = DateTime.Now,
                    TemperatureC = 20,
                    Summary = "Warm"
                },
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(1),
                    TemperatureC = 14,
                    Summary = "Cool"
                },
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(2),
                    TemperatureC = -13,
                    Summary = "Freezing"
                },
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(3),
                    TemperatureC = 30,
                    Summary = "热"
                },
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(4),
                    TemperatureC = 25,
                    Summary = "Balmy"
                },
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(5),
                    TemperatureC = -5,
                    Summary = "Chilly"
                }
            };

        }
    }
}
