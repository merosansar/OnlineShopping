using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblOrder
{
    public int Id { get; set; }

    public int SelllerId { get; set; }

    public DateTime OrderDate { get; set; }

    public int? OrderStatusId { get; set; }

    public decimal TotalAmount { get; set; }

    public int? PaymentMethodId { get; set; }

    public int? PaymentstatusId { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public string? BillingAddress { get; set; }

    public string? ShippingMethod { get; set; }

    public string? TrackingNumber { get; set; }

    public DateTime EstimatedDeliveryDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int UserId { get; set; }

    public virtual TblOrderStatus? OrderStatus { get; set; }

    public virtual TblPaymentMethod? PaymentMethod { get; set; }

    public virtual TblPaymentStatus? Paymentstatus { get; set; }

    public virtual TblSeller Selller { get; set; } = null!;

    public virtual ICollection<TblCouponUsage> TblCouponUsages { get; set; } = new List<TblCouponUsage>();

    public virtual ICollection<TblDeliveryAssignment> TblDeliveryAssignments { get; set; } = new List<TblDeliveryAssignment>();

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();

    public virtual ICollection<TblShipment> TblShipments { get; set; } = new List<TblShipment>();

    public virtual ICollection<TblTransaction> TblTransactions { get; set; } = new List<TblTransaction>();

    public virtual TblUser User { get; set; } = null!;
}
