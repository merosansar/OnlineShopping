using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblDeliveryPartner
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactPerson { get; set; }

    public string? ContactPersonPnoneNo { get; set; }

    public string? ContactPersonEmail { get; set; }

    public string? Country { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Zone { get; set; }

    public string? District { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public int? StatusId { get; set; }

    public string? Description { get; set; }

    public virtual TblStatus? Status { get; set; }

    public virtual ICollection<TblDeliveryAssignment> TblDeliveryAssignments { get; set; } = new List<TblDeliveryAssignment>();

    public virtual ICollection<TblDeliveryPartnerPerformance> TblDeliveryPartnerPerformances { get; set; } = new List<TblDeliveryPartnerPerformance>();
}
