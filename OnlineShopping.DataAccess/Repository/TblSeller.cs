using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblSeller
{
    public int Id { get; set; }

    public string SellerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? PhoneNo { get; set; }

    public string? Address { get; set; }

    public string? Country { get; set; }

    public string? Province { get; set; }

    public string? Zone { get; set; }

    public string? District { get; set; }

    public string? City { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public double? Rating { get; set; }

    public int? TotalSale { get; set; }

    public string? ProfilePicUrl { get; set; }

    public string? BusinessName { get; set; }

    public string? BusinessLicenseNo { get; set; }

    public string? BankAccountNo { get; set; }

    public string? BankName { get; set; }

    public string? TaxId { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? Description { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public int StatusId { get; set; }

    public virtual TblStatus Status { get; set; } = null!;

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();

    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
