using System;
using System.Collections.Generic;

namespace RisePingAPIs.Models;

public partial class EventRecord
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TypeId { get; set; }

    public DateTime? DateTimeFrom { get; set; }

    public DateTime? DateTimeTo { get; set; }

    public string? CreatedBy { get; set; }

    public virtual NotificatoinType? Type { get; set; }
}
