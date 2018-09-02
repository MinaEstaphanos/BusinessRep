using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using BusinessRep.ViewModels;
using Newtonsoft.Json;
using Yelp.Api.Models;

namespace BusinessRep.Controllers
{
    
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            return View(new BusinessSearchViewModel());
        }

        public ActionResult Search(BusinessSearchViewModel searchViewModel)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();

           ;

            searchViewModel = new BusinessSearchViewModel
            {
                BusinessName = searchViewModel.BusinessName,
                BusinessLocation = searchViewModel.BusinessLocation,
                
            };

            //SearchYelp(searchViewModel);
            SearchGoogle(searchViewModel);
            return View("Index",searchViewModel);
        }

        private void SearchYelp(BusinessSearchViewModel searchViewModel)
        {
            var businessName = searchViewModel.BusinessName.Replace(' ', '+');
            var businessLocation = searchViewModel.BusinessLocation.Replace(' ', '+');
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "UYGEnpjdfW81wQSMHNlQ0gf1ZuMwU2ooIkXamypVqyrixxhchKNO-YTceDT_5ThzppfaNw2ksZZO-aDqaMwuW4l_kffCw6qDHMQjY2UwU6G4Rnf4jC5u1B9toumAW3Yx");
            var yelpResults = client.GetAsync($"https://api.yelp.com/v3/businesses/search?term={businessName}&location={businessLocation}").Result;


            var businessSearchResults =
                JsonConvert.DeserializeObject<SearchResponse>(yelpResults.Content.ReadAsStringAsync().Result);

            searchViewModel.YelpBusinesses = businessSearchResults.Businesses;
        }

        private void SearchGoogle(BusinessSearchViewModel searchViewModel)
        {
            var results = client.GetAsync(
                $"https://maps.googleapis.com/maps/api/" +
                $"place/findplacefromtext/json?input=Museum%20of%20Contemporary%20Art%20Australia&inputtype=textquery&fields=name,rating&key=AIzaSyDzn3sX-H9IsuDf-PmyPI3X3zKCVt5I9nQ").Result;

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}