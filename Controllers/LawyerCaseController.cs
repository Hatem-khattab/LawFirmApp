using LawFirmApp.Entities;
using LawFirmApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace LawFirmApp.Controllers
{
    public class LawyerCaseController : Controller
    {
        [Obsolete]
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment _webHost;

        Entities.WebContext context = new Entities.WebContext();

        [Obsolete]
        public LawyerCaseController(Microsoft.AspNetCore.Hosting.IHostingEnvironment host)
        {
            _webHost = host;
        }
        public IActionResult Case()
        {
            ViewBag.Lawyers = context.Lawyers.ToList();
            return View();
        }
        public IActionResult Courts() {   return View();   }
         
        public IActionResult UpdateUser(int ID) {

            ViewBag.Lawyers = context.Lawyers.ToList();

            var result = (from obje in context.Lawyers.Where(x => x.LawyerId == ID)
                          select new Models.LawyerModel
                          {
                              LawyerLocation = obje.LawyerLocation,
                              LawyerName = obje.LawyerName,
                              LawyerPhoneNumber = obje.LawyerPhoneNumber,
                              //Lawyerpicture = SaveImage(LawyerModel)




                          }).FirstOrDefault();


            return View(result); 
        
        
        
        }
        public IActionResult File()   {   return View();  }

        public IActionResult SaveLawyer()
        {
            return View();
        }

        private string ConvertImageToBase64(string imagePath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageBytes);
        }


        [HttpGet]
        public IActionResult ShowAllCasesAndLawyers()
        {
            

           
            List<Models.CaseModel> lstdata = new List<CaseModel>();
            lstdata = (from obj in context.Cases
                       join law in context.Lawyers on obj.CaseLawyer equals law.LawyerId
                       select new Models.CaseModel
                       {


                           CaseId = obj.CaseId,
                           CaseName = obj.CaseName,
                           CaseFireDate = obj.CaseFireDate,
                           CaseInformation = obj.CaseInformaion,
                           LawyerName = law.LawyerName,
                           //LawyerPicture = law.Lawyerpicture



                       }).ToList();
            return View(lstdata);
        }

  



        [HttpPost]
        public IActionResult SaveCase(Models.CaseModel caseModel)
        {
            if (caseModel == null)
            {
                return BadRequest("Invalid case data.");
            }

            var newCase = new Entities.Case
            {
                CaseFireDate = caseModel.CaseFireDate,
                CaseName = caseModel.CaseName,
                CaseInformaion = caseModel.CaseInformation,
                CaseLawyer = caseModel.CaseLawyer
            };

            try
            {
                context.Cases.Add(newCase);
                context.SaveChanges();

                return RedirectToAction("ShowAllCasesAndLawyers", "LawyerCase");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while saving the case: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SaveNewLawyer(Models.LawyerModel lawyerModel,IFormFile image)
        {//intiate an obj of the upload file method
            try
            {  
               

                
                var newLawyer = new Entities.Lawyer
                {
                    Lawyerpicture= SaveImage (lawyerModel.Lawyerpicture),
                    LawyerPhoneNumber = lawyerModel.LawyerPhoneNumber,
                    LawyerName = lawyerModel.LawyerName,
                    LawyerLocation = lawyerModel.LawyerLocation
                };

                context.Lawyers.Add(newLawyer);
                context.SaveChanges();

                return RedirectToAction("case", "LawyerCase");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while saving the lawyer: " + ex.Message);
                return RedirectToAction("SaveLawyer");
            }
        }




       
       
        [HttpPost]
        [Obsolete]
        public IActionResult UploadButton_Click(FileModel mode)
        {

            LawFirmApp.Entities.File file = new LawFirmApp.Entities.File()
            {
                FileName = SaveImage(mode.FileName),
                ContentType = "nnnn",
                Content = []

            };
            context.Add(file);
            context .SaveChanges();
            return RedirectToAction("ShowAllCasesAndLawyers","LawyerCase");


        }

        [Obsolete]
        string SaveImage(IFormFile file)
        {
            string ImageName = "";
            if (file != null)
            {
                string Filepath = Path.Combine(_webHost.WebRootPath, "Lawyers");
                FileInfo fil = new FileInfo(file.FileName);
                ImageName = "Image_" + Guid.NewGuid() + fil.Extension;
                string FullPath = Path.Combine(Filepath, ImageName);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;

        }

    }
}





