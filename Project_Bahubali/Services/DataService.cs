using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_Bahubali.Models;
using Microsoft.AspNetCore.Http;
namespace Project_Bahubali.Services
{
    public class DataService
    {
        private readonly ScoresDbContext _context;
        
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DataService(ScoresDbContext _context, UserManager<IdentityUser> _userManager, IHttpContextAccessor httpContextAccessor)
        {
            this._context = _context;
            this._userManager = _userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Score>> GetAllScoresAsync()
        {

            var k = _httpContextAccessor.HttpContext.Session.GetString("UserName");
           var d =  _httpContextAccessor.HttpContext.User.Identity.Name;
           var res = await _context.Scores.Where(s => s.UserId == k).ToListAsync();

            return res;
        }

        public async Task<Score> AddScores(Score score)
        {

            var d = _httpContextAccessor.HttpContext.User.Identity.Name;
            score.Date = DateTime.Now;
            score.UserId = d;
            var res =await  _context.Scores.AddAsync(score);
            await _context.SaveChangesAsync();
            return res.Entity;
        }
       

    }
}
