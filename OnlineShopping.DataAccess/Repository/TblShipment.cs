using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblShipment
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int MethodId { get; set; }

    public int TrackingId { get; set; }

    public int StatusId { get; set; }

    public DateTime? EstimatedDeliveryDate { get; set; }

    public DateTime? ActualDeliveryDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TblShippingMethod Method { get; set; } = null!;

    public virtual TblOrder Order { get; set; } = null!;

    public virtual TblShippingStatus Status { get; set; } = null!;

    public virtual TblTrackingNumber Tracking { get; set; } = null!;
}
