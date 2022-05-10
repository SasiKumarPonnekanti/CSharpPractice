using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Bahubali.Models;
using Project_Bahubali.Services;

namespace Project_Bahubali.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class DataController : ControllerBase
    {
        private readonly DataService dataService; 

        public DataController (DataService dataService)
        {
            this.dataService = dataService;
        }
        [Route("post/Scores")]
       [Authorize(Policy = "UserPolicy")]
        [HttpPost]
        public async Task<IActionResult> PostScores(Score score)
        {
            var res = await dataService.AddScores(score);
            if(res!=null)
            {
                return Ok("Marks Added Sucessfully");
            }
            else
            {
                return Ok("Something wrong");
            }
        }
        [HttpGet]
        [Route("get/Scores")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetScores()
        {
            var res = await dataService.GetAllScoresAsync();
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return Ok("Something wrong");
            }
        }
    }
}
