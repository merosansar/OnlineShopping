using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblDeliveryAssignmentStatus
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TblDeliveryAssignment> TblDeliveryAssignments { get; set; } = new List<TblDeliveryAssignment>();
}
