using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Facebook;
using Newtonsoft.Json;
using Yelp.Api.Models;

namespace BusinessReputation.Controllers.API
{
    public class LookupBusinessController : ApiController
    {
        //public const string TripAdvisorApi = "http://api.tripadvisor.com/api/partner/2.0/location/155507?key=";
        static HttpClient client = new HttpClient();




        [HttpGet]
        [Route("api/LookupBusiness/GetBusinessRep/{businessName}/{location}")]
        public async Task<IHttpActionResult> GetBusinessRep(string businessName,string location )
        {

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "UYGEnpjdfW81wQSMHNlQ0gf1ZuMwU2ooIkXamypVqyrixxhchKNO-YTceDT_5ThzppfaNw2ksZZO-aDqaMwuW4l_kffCw6qDHMQjY2UwU6G4Rnf4jC5u1B9toumAW3Yx");
            var yelpResults = await client.GetAsync($"https://api.yelp.com/v3/businesses/search?term={businessName}&location={location}");

            
            var businessSearchResults  = JsonConvert.DeserializeObject<SearchResponse>(yelpResults.Content.ReadAsStringAsync().Result);

            


            var fb = new FacebookClient();
            dynamic result = fb.Get("oauth/access_token", new
            {
                client_id = "",
                client_secret = "",
                grant_type = "client_credentials"
            });
            fb.AccessToken = result.access_token;
            try
            {
                var result2 = fb.Get($"/{businessName}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return Ok("test");

        }


    }
}
