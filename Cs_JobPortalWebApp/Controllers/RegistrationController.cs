using Microsoft.AspNetCore.Mvc;
using Cs_JobPortalWebApp.Models;
using Cs_JobPortalWebApp.CustomSession;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Cs_JobPortalWebApp.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace Cs_JobPortalWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        IWebHostEnvironment hostEnvironment;
        private readonly IService<Personal, int> PersonalInfo;
        private readonly IService<ProjectInfo, int> ProjectInfo;
        private readonly IService<CampanyInfo, int> CampanyInfo;
        private readonly IService<EduInfo, int> EduInfo;
        public RegistrationController(IWebHostEnvironment hostEnvironment, IService<EduInfo, int> service1, IService<ProjectInfo, int> service2, IService<CampanyInfo, int> service3, IService<Personal, int> service4)
        {
            this.hostEnvironment = hostEnvironment;
            PersonalInfo = service4;
            ProjectInfo = service2;
            CampanyInfo = service3;
            EduInfo = service1;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPersonalInfo()
        {
            var NewPerson = HttpContext.Session.GetObject<Personal>("Personal");
            if(NewPerson == null)
            {
                NewPerson = new Personal();
            }
            //Personal NewPerson = new Personal();
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Male", Value = "Male" });
            items.Add(new SelectListItem { Text = "Female", Value = "Female" });
            items.Add(new SelectListItem { Text = "Trans", Value = "TransGender" });
            ViewBag.Gender = items;

            return View(NewPerson);
        }
        [HttpPost]
        public IActionResult AddPersonalInfo(Personal person)
        {
            HttpContext.Session.SetObject<Personal>("Personal", person);
            
            return RedirectToAction("AddEducation", "Registration"); ;
        }


        public IActionResult AddEducation()
        {
            EduInfo education = HttpContext.Session.GetObject<EduInfo>("LatestEdu");
            if (education ==null)
            {
                education = new EduInfo();
            }
            
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "School", Value = "SSC" });
            items.Add(new SelectListItem { Text = "Deploma", Value = "Dipoma" });
            items.Add(new SelectListItem { Text = "Intermediate", Value = "Intermediate" });
            items.Add(new SelectListItem { Text = "PostGraduation", Value = "PG" });
            items.Add(new SelectListItem { Text = "UnderGraduation", Value = "UG" });
            ViewBag.EduTypes = items;
            
            return View(education); 
        }
        [HttpPost]

        public IActionResult AddEducation(EduInfo education,string action)
        {

           
                var Edus = HttpContext.Session.GetObject<List<EduInfo>>("Educations");
                if (Edus == null)
                {
                    Edus = new List<EduInfo>();
                    Edus.Add(education);
                    HttpContext.Session.SetObject<List<EduInfo>>("Educations", Edus);
                }
                else
                {
                    Edus.Add(education);
                    HttpContext.Session.SetObject<List<EduInfo>>("Educations", Edus);
                }

                if (action == "AddOneMore")
                {

                    HttpContext.Session.SetObject<EduInfo>("LatestEdu", new EduInfo());
                    return RedirectToAction("AddEducation");

                }
                else if (action == "AddProjectsandExperience")
                {
                    HttpContext.Session.SetObject<EduInfo>("LatestEdu", education);
                    return RedirectToAction("AddProject");
                }
                else if (action == "SaveAndContinue")
                {
                    HttpContext.Session.SetObject<EduInfo>("LatestEdu", education);
                    return RedirectToAction("FileUpload");
                }
           
            return RedirectToAction("AddEducation"); 
        }

        public IActionResult AddProject()
        {
            ProjectInfo project = HttpContext.Session.GetObject<ProjectInfo>("LatestProject");
            if (project == null)
            {
                project = new ProjectInfo();
            }
            
            return View(project);
        }
        [HttpPost]
        public IActionResult AddProject(ProjectInfo project,string action)
        {
         
            var projects = HttpContext.Session.GetObject<List<ProjectInfo>>("Projects");
            if (projects == null)
            {
                projects = new List<ProjectInfo>();
                projects.Add(project);
                HttpContext.Session.SetObject<List<ProjectInfo>>("Projects", projects);
            }
            else
            {
                projects.Add(project);
                HttpContext.Session.SetObject<List<ProjectInfo>>("Projects", projects);
            }
            if (action == "AddOneMore")
            {
                HttpContext.Session.SetObject<ProjectInfo>("LatestProject", new ProjectInfo());
                return RedirectToAction("AddProject");
            }
            else if (action == "AddExperience")
            {
                HttpContext.Session.SetObject<ProjectInfo>("LatestProject",project);
                return RedirectToAction("AddExperience");
            }
            else if (action == "SaveAndContinue")
            {
                HttpContext.Session.SetObject<ProjectInfo>("LatestProject", project);
                return RedirectToAction("FileUpload");
            }
            return View("Index");           
        }

        public IActionResult AddExperience()
        {
           
            CampanyInfo campany = HttpContext.Session.GetObject<CampanyInfo>("LatestCampany");
            if (campany == null)
            {
                campany = new CampanyInfo();
            }
            return View(campany);
        }
        [HttpPost]
        public IActionResult AddExperience(CampanyInfo campany,string action)
        {
         
            var campanies = HttpContext.Session.GetObject<List<CampanyInfo>>("campanies");
            if (campanies == null)
            {
                campanies = new List<CampanyInfo>();
                campanies.Add(campany);
                HttpContext.Session.SetObject<List<CampanyInfo>>("campanies", campanies);
            }
            else
            {
                campanies.Add(campany);
                HttpContext.Session.SetObject<List<CampanyInfo>>("campanies", campanies);
            }


            if (action == "AddOneMore")
            {
                 HttpContext.Session.SetObject<CampanyInfo>("LatestCampany",new CampanyInfo());
                return RedirectToAction("AddExperience");
            }
            else if (action == "SaveAndContinue")
            {
                HttpContext.Session.SetObject<CampanyInfo>("LatestCampany", campany);
                return RedirectToAction("FileUpload");
            }
            return View("Index");

        }
        public IActionResult FileUpload()
        {
            ProfileData data = new ProfileData();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> FileUpload(ProfileData data)     
        {
            var person = HttpContext.Session.GetObject<Personal>("Personal");
            var campanies = HttpContext.Session.GetObject<List<CampanyInfo>>("campanies");
            var edus = HttpContext.Session.GetObject<List<EduInfo>>("Educations");
            var projects = HttpContext.Session.GetObject<List<ProjectInfo>>("Projects");

            

            IFormFile Image = data.Image;
            IFormFile Resume = data.Resume;
            if (Image.Length > 0 && Resume.Length >0)
            {
                var ImageFileName = ContentDispositionHeaderValue
                  .Parse(Image.ContentDisposition)
                    .FileName.Trim('"');
                var ResumeFileName = ContentDispositionHeaderValue
                  .Parse(Resume.ContentDisposition)
                    .FileName.Trim('"');

                FileInfo imageInfo = new FileInfo(ImageFileName);

                FileInfo ResumeInfo = new FileInfo(ResumeFileName);


                if (imageInfo.Extension == ".jpg" || imageInfo.Extension == ".png")
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "images", ImageFileName);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await Image.CopyToAsync(fs);
                    }
                    //data.ImageFileName = finalPath;
                    data.ImageFileName = ImageFileName;
                    data.ImageUploadStatus = "Uploaded Successfully";
                }
                else
                {
                    data.ImageUploadStatus = "Upload UnSuccess";
                }
                if (ResumeInfo.Extension == ".pdf" || ResumeInfo.Extension == ".txt")
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "resumes", ResumeFileName);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await Resume.CopyToAsync(fs);
                    }
                    data.ResumeFileName = ResumeFileName;
                    data.ResumeUploadStatus = "Uploaded Successfully";
                }
                else
                {
                    data.ResumeUploadStatus = "Upload UnSuccess";
                }
            }
            else
            {
                return RedirectToAction("FileUpload");
            }
            person.ImagePath = data.ImageFileName;
            person.ProfilePath = data.ResumeFileName;
            var res = PersonalInfo.CreateAsync(person).Result;
            await CampanyInfo.AddList(campanies, res.PersonId);
            await EduInfo.AddList(edus, res.PersonId);
            await ProjectInfo.AddList(projects, res.PersonId);
            HttpContext.Session.Remove("Personal");
            HttpContext.Session.Remove("campanies");
            HttpContext.Session.Remove("Educations");
            HttpContext.Session.Remove("Personal");
            HttpContext.Session.Remove("LatestCampany");
            HttpContext.Session.Remove("LatestProject");
            HttpContext.Session.Remove("LatestEdu");
            return RedirectToAction("Index");
        }
        public IActionResult ValidateName(string FullName)
        {
            Regex r = new Regex("([A-Z][a-z]{3,} )([A-Z][a-z]{3,} )?([A-Z][a-z]{3,})");
            Match m = r.Match(FullName);
            if (m.Success)
            {
                return Json(true);
            }
            return Json(false);

        }
        public IActionResult ValidPhone(string Contact)
        {
            Regex r = new Regex("^\\+?[1-9][0-9]{7,14}$");
            Match m = r.Match(Contact);
            if (m.Success)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
