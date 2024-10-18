using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblDeliveryAssignment
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int PartnerId { get; set; }

    public DateTime? AssignmentDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public int? DassignmentStatusId { get; set; }

    public virtual TblDeliveryAssignmentStatus? DassignmentStatus { get; set; }

    public virtual TblOrder Order { get; set; } = null!;

    public virtual TblDeliveryPartner Partner { get; set; } = null!;
}
