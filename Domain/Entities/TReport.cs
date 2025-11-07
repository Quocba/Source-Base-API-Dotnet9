using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TReport
{
    public string ReportName { get; set; } = null!;

    public string? ReportGuid { get; set; }

    public byte[]? ReportContent { get; set; }

    public byte[]? ReportCompiled { get; set; }

    public string? ReportTitle { get; set; }

    public string? ReportGroup { get; set; }

    public byte? ReportOrder { get; set; }
}
