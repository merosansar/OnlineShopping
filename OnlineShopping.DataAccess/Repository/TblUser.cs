using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblUser
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? FullName { get; set; }

    public string? PhoneNo { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public string? Zone { get; set; }

    public string? District { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public int StatusId { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? ProfilePicUrl { get; set; }

    public int? RoleId { get; set; }

    public int GenderId { get; set; }

    public DateOnly? Dob { get; set; }

    public virtual TblGender Gender { get; set; } = null!;

    public virtual TblRole? Role { get; set; }

    public virtual TblStatus Status { get; set; } = null!;

    public virtual ICollection<TblCart> TblCarts { get; set; } = new List<TblCart>();

    public virtual ICollection<TblComment> TblComments { get; set; } = new List<TblComment>();

    public virtual ICollection<TblCouponUsage> TblCouponUsages { get; set; } = new List<TblCouponUsage>();

    public virtual ICollection<TblNotification> TblNotifications { get; set; } = new List<TblNotification>();

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();

    public virtual ICollection<TblTransaction> TblTransactions { get; set; } = new List<TblTransaction>();

    public virtual ICollection<TblUserActivity> TblUserActivities { get; set; } = new List<TblUserActivity>();

    public virtual ICollection<TblUserProfile> TblUserProfiles { get; set; } = new List<TblUserProfile>();

    public virtual ICollection<TblWishlist> TblWishlists { get; set; } = new List<TblWishlist>();
}
