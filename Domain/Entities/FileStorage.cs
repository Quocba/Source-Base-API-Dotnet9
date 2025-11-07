using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class FileStorage
{
    public string FileId { get; set; } = null!;

    public string? FileName { get; set; }

    public string? GdriveId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }
}
