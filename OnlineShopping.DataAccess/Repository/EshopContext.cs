using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopping.DataAccess.Repository;

public partial class EshopContext : DbContext
{
    public EshopContext()
    {
    }

    public EshopContext(DbContextOptions<EshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAddress> TblAddresses { get; set; }

    public virtual DbSet<TblAddressType> TblAddressTypes { get; set; }

    public virtual DbSet<TblBrand> TblBrands { get; set; }

    public virtual DbSet<TblCart> TblCarts { get; set; }

    public virtual DbSet<TblCartItem> TblCartItems { get; set; }

    public virtual DbSet<TblCartStatus> TblCartStatuses { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblColor> TblColors { get; set; }

    public virtual DbSet<TblComment> TblComments { get; set; }

    public virtual DbSet<TblCoupon> TblCoupons { get; set; }

    public virtual DbSet<TblCouponUsage> TblCouponUsages { get; set; }

    public virtual DbSet<TblDeliveryAssignment> TblDeliveryAssignments { get; set; }

    public virtual DbSet<TblDeliveryAssignmentStatus> TblDeliveryAssignmentStatuses { get; set; }

    public virtual DbSet<TblDeliveryPartner> TblDeliveryPartners { get; set; }

    public virtual DbSet<TblDeliveryPartnerPerformance> TblDeliveryPartnerPerformances { get; set; }

    public virtual DbSet<TblGender> TblGenders { get; set; }

    public virtual DbSet<TblItem> TblItems { get; set; }

    public virtual DbSet<TblNotification> TblNotifications { get; set; }

    public virtual DbSet<TblNotificationStatus> TblNotificationStatuses { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }

    public virtual DbSet<TblOrderStatus> TblOrderStatuses { get; set; }

    public virtual DbSet<TblPaymentMethod> TblPaymentMethods { get; set; }

    public virtual DbSet<TblPaymentStatus> TblPaymentStatuses { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProductDetail> TblProductDetails { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblSeller> TblSellers { get; set; }

    public virtual DbSet<TblShipment> TblShipments { get; set; }

    public virtual DbSet<TblShippingMethod> TblShippingMethods { get; set; }

    public virtual DbSet<TblShippingStatus> TblShippingStatuses { get; set; }

    public virtual DbSet<TblStatus> TblStatuses { get; set; }

    public virtual DbSet<TblSubCategory> TblSubCategories { get; set; }

    public virtual DbSet<TblTrackingNumber> TblTrackingNumbers { get; set; }

    public virtual DbSet<TblTransaction> TblTransactions { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserActivity> TblUserActivities { get; set; }

    public virtual DbSet<TblUserProfile> TblUserProfiles { get; set; }

    public virtual DbSet<TblWarranty> TblWarranties { get; set; }

    public virtual DbSet<TblWishlist> TblWishlists { get; set; }

    public virtual DbSet<TblWishlistItem> TblWishlistItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblAddre__3214EC076E7DC50E");

            entity.ToTable("tblAddress");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AtypeId).HasColumnName("ATypeId");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Zone)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Atype).WithMany(p => p.TblAddresses)
                .HasForeignKey(d => d.AtypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblAddres__AType__04AFB25B");
        });

        modelBuilder.Entity<TblAddressType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblAddre__3214EC07A225B719");

            entity.ToTable("tblAddressType");

            entity.HasIndex(e => e.Name, "UQ__tblAddre__737584F632CEC7D8").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblBrand__3214EC07E35D7D23");

            entity.ToTable("tblBrand");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCart__3214EC07C055FDEE");

            entity.ToTable("tblCart");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CartStatus).WithMany(p => p.TblCarts)
                .HasForeignKey(d => d.CartStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblCart__CartSta__477199F1");

            entity.HasOne(d => d.User).WithMany(p => p.TblCarts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblCart__UserId__73852659");
        });

        modelBuilder.Entity<TblCartItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCartI__3214EC0798F62EA3");

            entity.ToTable("tblCartItem");

            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cart).WithMany(p => p.TblCartItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblCartIt__CartI__76619304");

            entity.HasOne(d => d.Product).WithMany(p => p.TblCartItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblCartIt__Produ__7755B73D");
        });

        modelBuilder.Entity<TblCartStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCartS__3214EC072ECF7426");

            entity.ToTable("tblCartStatus");

            entity.HasIndex(e => e.Name, "UQ__tblCartS__737584F600D4DBAF").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCateg__3214EC07CBD38256");

            entity.ToTable("tblCategory");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblColor__3214EC0750099305");

            entity.ToTable("tblColor");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblComme__3214EC077F268075");

            entity.ToTable("tblComment");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.TblComments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblCommen__Produ__67DE6983");

            entity.HasOne(d => d.User).WithMany(p => p.TblComments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblCommen__UserI__68D28DBC");
        });

        modelBuilder.Entity<TblCoupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCoupo__3214EC0711199A37");

            entity.ToTable("tblCoupon");

            entity.HasIndex(e => e.Code, "UQ__tblCoupo__A25C5AA77FBEDA35").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UsageCount).HasDefaultValue(0);
        });

        modelBuilder.Entity<TblCouponUsage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCoupo__3214EC07A1D2DAFB");

            entity.ToTable("tblCouponUsage");

            entity.Property(e => e.UsageDate).HasColumnType("datetime");

            entity.HasOne(d => d.Coupon).WithMany(p => p.TblCouponUsages)
                .HasForeignKey(d => d.CouponId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblCoupon__Coupo__19AACF41");

            entity.HasOne(d => d.Order).WithMany(p => p.TblCouponUsages)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblCoupon__Order__1B9317B3");

            entity.HasOne(d => d.User).WithMany(p => p.TblCouponUsages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblCoupon__UserI__1A9EF37A");
        });

        modelBuilder.Entity<TblDeliveryAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblDeliv__3214EC07283C0983");

            entity.ToTable("tblDeliveryAssignment");

            entity.Property(e => e.AssignmentDate).HasColumnType("datetime");
            entity.Property(e => e.DassignmentStatusId).HasColumnName("DAssignmentStatusId");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            entity.HasOne(d => d.DassignmentStatus).WithMany(p => p.TblDeliveryAssignments)
                .HasForeignKey(d => d.DassignmentStatusId)
                .HasConstraintName("FK__tblDelive__DAssi__681373AD");

            entity.HasOne(d => d.Order).WithMany(p => p.TblDeliveryAssignments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblDelive__Order__662B2B3B");

            entity.HasOne(d => d.Partner).WithMany(p => p.TblDeliveryAssignments)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblDelive__Partn__671F4F74");
        });

        modelBuilder.Entity<TblDeliveryAssignmentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblDeliv__3214EC07C988A630");

            entity.ToTable("tblDeliveryAssignmentStatus");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblDeliveryPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblDeliv__3214EC0769CF68A0");

            entity.ToTable("tblDeliveryPartner");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactPersonEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactPersonPnoneNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.Zone)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Status).WithMany(p => p.TblDeliveryPartners)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__tblDelive__Statu__57DD0BE4");
        });

        modelBuilder.Entity<TblDeliveryPartnerPerformance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblDeliv__3214EC072F878ABD");

            entity.ToTable("tblDeliveryPartnerPerformance");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Feedback)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Partner).WithMany(p => p.TblDeliveryPartnerPerformances)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblDelive__Partn__5AB9788F");
        });

        modelBuilder.Entity<TblGender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblGende__3214EC07C535A930");

            entity.ToTable("tblGender");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblItem__3214EC0779958CF5");

            entity.ToTable("tblItem");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.SubCat).WithMany(p => p.TblItems)
                .HasForeignKey(d => d.SubCatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblItem__SubCatI__02FC7413");
        });

        modelBuilder.Entity<TblNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblNotif__3214EC073633F593");

            entity.ToTable("tblNotification");

            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.NotificationDate).HasColumnType("datetime");

            entity.HasOne(d => d.NotificationStatus).WithMany(p => p.TblNotifications)
                .HasForeignKey(d => d.NotificationStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblNotifi__Notif__55009F39");

            entity.HasOne(d => d.User).WithMany(p => p.TblNotifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblNotifi__UserI__540C7B00");
        });

        modelBuilder.Entity<TblNotificationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblNotif__3214EC07758560AD");

            entity.ToTable("tblNotificationStatus");

            entity.HasIndex(e => e.Name, "UQ__tblNotif__737584F67CF52560").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblOrder__3214EC07BFE65744");

            entity.ToTable("tblOrders");

            entity.Property(e => e.BillingAddress).HasColumnType("text");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.EstimatedDeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ShippingAddress).HasColumnType("text");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("FK__tblOrders__Order__40058253");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK__tblOrders__Payme__40F9A68C");

            entity.HasOne(d => d.Paymentstatus).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.PaymentstatusId)
                .HasConstraintName("FK__tblOrders__Payme__41EDCAC5");

            entity.HasOne(d => d.Selller).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.SelllerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblOrders__Selll__3F115E1A");

            entity.HasOne(d => d.User).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblOrders__UserI__467D75B8");
        });

        modelBuilder.Entity<TblOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblOrder__3214EC075F700CE1");

            entity.ToTable("tblOrderDetails");

            entity.Property(e => e.Discount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblOrderD__Order__43A1090D");

            entity.HasOne(d => d.Product).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblOrderD__Produ__44952D46");
        });

        modelBuilder.Entity<TblOrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblOrder__3214EC07B6CF7D75");

            entity.ToTable("tblOrderStatus");

            entity.HasIndex(e => e.StatusName, "UQ__tblOrder__05E7698AAC511C9C").IsUnique();

            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblPaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblPayme__3214EC07E497274F");

            entity.ToTable("tblPaymentMethod");

            entity.HasIndex(e => e.Name, "UQ__tblPayme__737584F6C0C1FB86").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblPaymentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblPayme__3214EC07052E3C1D");

            entity.ToTable("tblPaymentStatus");

            entity.HasIndex(e => e.Name, "UQ__tblPayme__737584F6A7AF5C1B").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblProdu__3214EC07290350BE");

            entity.ToTable("tblProduct");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblProduc__Categ__1CBC4616");

            entity.HasOne(d => d.Item).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblProduc__ItemI__1DB06A4F");

            entity.HasOne(d => d.Seller).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__tblProduc__selle__6CA31EA0");

            entity.HasOne(d => d.SubCat).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.SubCatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblProduc__SubCa__1EA48E88");
        });

        modelBuilder.Entity<TblProductDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblProdu__3214EC07DBAA0AAE");

            entity.ToTable("tblProductDetail");

            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Dimensions)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Height).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Length).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Material)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductModel)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PromotionEndDate).HasColumnType("datetime");
            entity.Property(e => e.PromotionStartDate).HasColumnType("datetime");
            entity.Property(e => e.SellerSku)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SellerSKU");
            entity.Property(e => e.SpecialPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Specifications)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Warranty)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Width).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.TblProductDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblProduc__Produ__7167D3BD");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblRole__3214EC0786D23CF8");

            entity.ToTable("tblRole");

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblSeller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblSelle__3214EC07BA9D5635");

            entity.ToTable("tblSellers");

            entity.HasIndex(e => e.Email, "UQ__tblSelle__A9D10534CF382D3D").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BankAccountNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BusinessLicenseNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BusinessName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePicUrl)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rating).HasDefaultValue(0.0);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.SellerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TaxId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalSale).HasDefaultValue(0);
            entity.Property(e => e.WebsiteUrl)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Zone)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Status).WithMany(p => p.TblSellers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblSeller__Statu__3C34F16F");
        });

        modelBuilder.Entity<TblShipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblShipm__3214EC071B197CA2");

            entity.ToTable("tblShipment");

            entity.Property(e => e.ActualDeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EstimatedDeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Method).WithMany(p => p.TblShipments)
                .HasForeignKey(d => d.MethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblShipme__Metho__11158940");

            entity.HasOne(d => d.Order).WithMany(p => p.TblShipments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblShipme__Order__10216507");

            entity.HasOne(d => d.Status).WithMany(p => p.TblShipments)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblShipme__Statu__12FDD1B2");

            entity.HasOne(d => d.Tracking).WithMany(p => p.TblShipments)
                .HasForeignKey(d => d.TrackingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblShipme__Track__1209AD79");
        });

        modelBuilder.Entity<TblShippingMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblShipp__3214EC07D17C4D7D");

            entity.ToTable("tblShippingMethod");

            entity.HasIndex(e => e.Name, "UQ__tblShipp__737584F6CF5E32CA").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblShippingStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblShipp__3214EC0701DBBD64");

            entity.ToTable("tblShippingStatus");

            entity.HasIndex(e => e.Name, "UQ__tblShipp__737584F689DA2440").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblStatu__3214EC07CE841568");

            entity.ToTable("tblStatus");

            entity.HasIndex(e => e.Name, "UQ__tblStatu__737584F6916D4742").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblSubCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblSubCa__3214EC078C6409A7");

            entity.ToTable("tblSubCategory");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Cat).WithMany(p => p.TblSubCategories)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblSubCat__CatId__5FB337D6");
        });

        modelBuilder.Entity<TblTrackingNumber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblTrack__3214EC077BF3E3EB");

            entity.ToTable("tblTrackingNumber");

            entity.HasIndex(e => e.Number, "UQ__tblTrack__78A1A19D208C6AD6").IsUnique();

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Number)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblTrans__3214EC07BCD70E85");

            entity.ToTable("tblTransaction");

            entity.HasIndex(e => e.TranReferenceNo, "UQ__tblTrans__016DC266D2A43603").IsUnique();

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.TranReferenceNo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblTransa__Order__1F63A897");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblTransa__Payme__214BF109");

            entity.HasOne(d => d.TranStatus).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.TranStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblTransa__TranS__22401542");

            entity.HasOne(d => d.User).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblTransa__UserI__2057CCD0");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC07AE6B0A58");

            entity.ToTable("tblUser");

            entity.HasIndex(e => e.Email, "UQ__tblUser__A9D10534C4479B27").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__tblUser__C9F28456F4EECD34").IsUnique();

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePicUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Zone)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Gender).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUser__GenderI__54CB950F");

            entity.HasOne(d => d.Role).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__tblUser__RoleId__4A8310C6");

            entity.HasOne(d => d.Status).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUser__StatusI__498EEC8D");
        });

        modelBuilder.Entity<TblUserActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUserA__3214EC07FC84C074");

            entity.ToTable("tblUserActivity");

            entity.Property(e => e.ActivityType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.TblUserActivities)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserAc__UserI__6DCC4D03");
        });

        modelBuilder.Entity<TblUserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUserP__3214EC07E2F619AE");

            entity.ToTable("tblUserProfile");

            entity.Property(e => e.Bio)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SocialLink)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.WebSiteUrl)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.TblUserProfiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__UserI__6AEFE058");
        });

        modelBuilder.Entity<TblWarranty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblWarra__3214EC075AA5C91E");

            entity.ToTable("tblWarranty");

            entity.Property(e => e.CoverageDetails)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Period)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.ServiceInfo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TermsConditions)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(75)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblWishlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblWishl__3214EC078BE6F05A");

            entity.ToTable("tblWishlist");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.TblWishlists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblWishli__UserI__7B264821");
        });

        modelBuilder.Entity<TblWishlistItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblWishl__3214EC07B8239512");

            entity.ToTable("tblWishlistItem");

            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.WishlistId).HasColumnName("wishlistId");

            entity.HasOne(d => d.Product).WithMany(p => p.TblWishlistItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblWishli__Produ__7EF6D905");

            entity.HasOne(d => d.Wishlist).WithMany(p => p.TblWishlistItems)
                .HasForeignKey(d => d.WishlistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblWishli__wishl__7E02B4CC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
