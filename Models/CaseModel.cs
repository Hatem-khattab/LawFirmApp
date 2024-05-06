using System.Data.SqlTypes;

namespace LawFirmApp.Models
{
    public class CaseModel
    {
        public required int CaseId { get; set; }

        public required String CaseName  { get; set; }

        public required DateOnly CaseFireDate { get; set; }

        public required String CaseInformation { get; set; }

        public int CaseLawyer {  get; set; }

        public string? LawyerName {  get; set; }

        public  IFormFile LawyerPicture { get; set; }
    }
}
