using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WeatherHistory.Web.Models;

namespace WeatherHistory.Web.Api
{
    // We derive our API contoller from the base class provided by WebAPI, but
    //  we also specify the route prefix at the controller level
    //
    [RoutePrefix("temperatures")]
    public class TemperaturesController : ApiController
    {
        // Now we can use the WebAPI conventions to automatically mark this as 
        //  a GET endpoint, and indicate that it does not add anything to the
        //  route
        //
        [Route("")]
        public IHttpActionResult Get(string zipCode)
        {
            // Create our dummy response just to show the API is working
            //
            var zipcodeWeather = new ZipcodeWeather
            {
                City = "St. Paul",
                State = "MN",
                Latitude = 44.9397629f,
                Longitude = -93.1410727f
            };

            // Now just add a list of fake temperatures to the return object
            //
            zipcodeWeather.HistoricalTemperatures.AddRange(
                new List<HistoricalTemperature> {
                    new HistoricalTemperature { Date = DateTime.Now, High = 75, Low = 50 },
                    new HistoricalTemperature { Date = DateTime.Now.AddYears(-1), High = 75, Low = 50 },
                    new HistoricalTemperature { Date = DateTime.Now.AddYears(-2), High = 75, Low = 50 },
                    new HistoricalTemperature { Date = DateTime.Now.AddYears(-3), High = 75, Low = 50 },
                    new HistoricalTemperature { Date = DateTime.Now.AddYears(-4), High = 75, Low = 50 }
                }
            );

            // Use the WebAPI base method to return a 200-response with the object as
            //  the payload
            //
            return Ok(zipcodeWeather);
        }
    }
}