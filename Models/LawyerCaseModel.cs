using LawFirmApp.Entities;

namespace LawFirmApp.Models
{
    public class LawyerCaseModel
    {
        public required int FileId { get; set; }

        public required int CaseId { get; set; }

        public required int LawyerId { get; set; }



    }
}
