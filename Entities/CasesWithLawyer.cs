using System;
using System.Collections.Generic;

namespace LawFirmApp.Entities;

public partial class CasesWithLawyer
{
    public int Id { get; set; }

    public int CaseId { get; set; }

    public int LawyerId { get; set; }
}
