using System;
using System.Collections.Generic;

namespace LawFirmApp.Entities;

public partial class Lawyer
{
    public int LawyerId { get; set; }

    public string LawyerName { get; set; } = null!;

    public string LawyerPhoneNumber { get; set; } = null!;

    public string LawyerLocation { get; set; } = null!;

    public required string Lawyerpicture { get; set; }

    public virtual ICollection<Case> Cases { get; set; } = new List<Case>();
}
