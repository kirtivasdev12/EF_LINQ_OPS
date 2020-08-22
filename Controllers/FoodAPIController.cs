using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json.Serialization;
using RestSharp;
using EF_LINQ_OPS.DataAccess;
using EF_LINQ_OPS.Models;



namespace EF_LINQ_OPS.Controllers
{
    public class FoodAPIController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public FoodAPIController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //HttpClient httpClient;
        

        //static string BASE_URL = "https://tasty.p.rapidapi.com";
        //static string API_KEY = "f65c9575d9msh7401166d92cbee6p105425jsnd68297f07086"; // Bibhas Key
        public IActionResult Index()
        {

            

            var client = new RestClient("https://tasty.p.rapidapi.com/recipes/list?tags=indian&from=0&sizes=1000");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "tasty.p.rapidapi.com");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("x-rapidapi-key", "f65c9575d9msh7401166d92cbee6p105425jsnd68297f07086");
            IRestResponse response = client.Execute(request);



            /*
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string NATIONAL_PARK_API_PATH = BASE_URL + "recipes/list?tags=mexican&q=horchata&from=0&sizes=20";
            string parksData = "";

            httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);*/
            string recipeData = "";
            Root recipe = null;
            //response.Content.;

            try
            {
                // HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();

                if (response.IsSuccessful )
                {
                    recipeData = response.Content.ToString();
                    
                      
                    //recipe = JsonConvert.DeserializeObject<Recipe>(response.ContentEncoding);
                }

                // Use https://json2csharp.com/ to convert JSON to classes

                if (!recipeData.Equals(""))
                {
                    //recipe = JsonConverterFactory(recipeData.);
                   recipe = JsonConvert.DeserializeObject<Root>(recipeData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message  
                Console.WriteLine(e.Message);
            }
            List<Result> res  ;

             res  = recipe.results.Where(r =>r.user_ratings != null )
             .OrderByDescending(r => r.user_ratings.score ).ToList() ;

            //res = recipe.results.Where(r => r.user_ratings != null).ToList();
            //return View(parks);
            return View(res);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MyLink()
        {
            return View();
        }
        /*public IActionResult UserAction(PersonModel person)
        {
            
            string name = person.Name;
            string city = person.City;
            string gender = person.Attending;

            return View();
        }*/

        [HttpGet]
        public ViewResult UserAction()
        {
            return View();
        }

        [HttpPost]
        //public ViewResult UserAction(PersonModel person)
        //{
        //    PersonModel.AddResponse(person);
        //    return View("UserActionResponse", person);

        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



