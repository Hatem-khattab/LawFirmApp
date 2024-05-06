using System;
using System.Collections.Generic;

namespace LawFirmApp.Entities;

public partial class File
{
    public int FileId { get; set; }

    public string FileName { get; set; } = null!;

    public string? ContentType { get; set; }

    public byte[]? Content { get; set; }
}
