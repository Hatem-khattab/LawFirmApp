using System;
using System.Collections.Generic;

namespace LawFirmApp.Entities;

public partial class Case
{
    public int CaseId { get; set; }

    public string CaseName { get; set; } = null!;

    public DateOnly CaseFireDate { get; set; }

    public string CaseInformaion { get; set; } = null!;

    public int CaseLawyer { get; set; }

    public virtual Lawyer CaseLawyerNavigation { get; set; } = null!;
}
