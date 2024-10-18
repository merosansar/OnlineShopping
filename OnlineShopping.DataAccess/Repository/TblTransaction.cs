using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblTransaction
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal Amount { get; set; }

    public int PaymentMethodId { get; set; }

    public int TranStatusId { get; set; }

    public string? TranReferenceNo { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TblOrder Order { get; set; } = null!;

    public virtual TblPaymentMethod PaymentMethod { get; set; } = null!;

    public virtual TblPaymentStatus TranStatus { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}
