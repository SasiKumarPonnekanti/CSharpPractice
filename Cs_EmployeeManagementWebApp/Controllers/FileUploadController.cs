using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cs_EmployeeManagementWebApp.Models;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace Cs_EmployeeManagementWebApp.Controllers
{
    public class FileUploadController : Controller
    {
        IWebHostEnvironment hostEnvironment;
        public FileUploadController(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            List<ProfileData> Profiles =  new List<ProfileData>();
            return View(Profiles);
        }

        public IActionResult Upload()
        {
            ProfileData data = new ProfileData();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Upload(ProfileData data)
        {
            // REad the Current Directtory that is mapped with WebServer
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages");
            // Get the File Objet
            IFormFile file = data.ProfilePicture;
            // Process It
            // Always Check Length of file
            if (file.Length > 0 && file.Length< 10485760)
            {
                // REad the Uploaded File Name
                var postedFileName = ContentDispositionHeaderValue
                  .Parse(file.ContentDisposition)
                    .FileName.Trim('"');
                FileInfo fileInfo = new FileInfo(postedFileName);

                // set the file path as FolderName/FileName
                if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png")
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "images", postedFileName);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = file.FileName;
                }
                else
                if (fileInfo.Extension == ".pdf")
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "pdfs", postedFileName);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = "pdf_icon.png";
                }
                else
                 if (fileInfo.Extension == ".txt")
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "textfiles", postedFileName);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = "Text_Icon.png";
                }

                
                data.UploadStatus = "File is Uploaded Successfully";
                

            }
            else
            {
                data.UploadStatus = "File is Upload Failed";
            }
            return View(data);
        }
    }
}
