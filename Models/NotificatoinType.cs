using System;
using System.Collections.Generic;

namespace RisePingAPIs.Models;

public partial class NotificatoinType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<EventRecord> EventRecords { get; set; } = new List<EventRecord>();
}
