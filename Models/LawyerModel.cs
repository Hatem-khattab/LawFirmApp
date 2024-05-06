using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace LawFirmApp.Models
{
    public class LawyerModel
    {

        //public  int LawyerId { get; set; }

        public required string LawyerName { get; set; }
        public required string LawyerLocation { get; set; }

        [Display(Name ="Chose the Profile Picture !")]
        public  IFormFile Lawyerpicture { get; set; }
        public required string LawyerPhoneNumber { get; set; }

        //public IFormFile? Lawyerpicture { get; set; }






    }
}
