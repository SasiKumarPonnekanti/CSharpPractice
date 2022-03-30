using Cs_JobPortalWebApp.Models;
using Cs_JobPortalWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cs_JobPortalWebApp.Controllers
{
    public class ViewDataController : Controller
    {
        private readonly IService<Personal, int> PersonalInfo;
        private readonly IService<ProjectInfo, int> ProjectInfo;
        private readonly IService<CampanyInfo, int> CampanyInfo;
        private readonly IService<EduInfo, int> EduInfo;
        public ViewDataController( IService<EduInfo, int> service1, IService<ProjectInfo, int> service2, IService<CampanyInfo, int> service3, IService<Personal, int> service4)
        {
           
            PersonalInfo = service4;
            ProjectInfo = service2;
            CampanyInfo = service3;
            EduInfo = service1;

        }
        public IActionResult Index()
        {
            var res = PersonalInfo.GetAllByIdAsync(0).Result;
            List<FullInfo> fullinfo = new List<FullInfo>();
            foreach(Personal p in res)
            {
                FullInfo f = new FullInfo()
                {
                    FullName= p.FullName,
                    Contact= p.Contact,
                    Email =p.Email,
                    ImagePath=p.ImagePath ,
                    PersonId=p.PersonId
                    
                };
                fullinfo.Add(f);
            }
            return View(fullinfo);
        }
        public IActionResult ShowDetails(int id)
        {
            FullInfo f = new FullInfo();
            var res1 = PersonalInfo.GetAsync(id).Result;
            f.FullName = res1.FullName;
            f.Gender = res1.Gender;
            f.Contact = res1.Contact;
            f.Email = res1.Email;
            f.AlternateContact= res1.AlternateContact;
            f.Adress = res1.Address;
            f.WorkExperience= res1.WorkExperience;
            f.ImagePath = res1.ImagePath;
            f.Resumepath = res1.ProfilePath;
            f.Campanys= CampanyInfo.GetAllByIdAsync(id).Result;
            f.Projects= ProjectInfo.GetAllByIdAsync(id).Result;
            f.Educations = EduInfo.GetAllByIdAsync(id).Result;

            return View(f);
        }
    }
}
