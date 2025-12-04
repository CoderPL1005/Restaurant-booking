using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BACKEND.Model.Entities;
using System.Data;

namespace BACKEND.Model.Context;

public partial class RTCContext : DbContext
{
    public RTCContext(DbContextOptions<RTCContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Roles> Roles { get; set; }
    
    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<BankAccounts> BankAccounts { get; set; }
    public virtual DbSet<MenuCategories> MenuCategories { get; set; }
    public virtual DbSet<MenuItems> MenuItems { get; set; }
    public virtual DbSet<Payments> Payments { get; set; }
    public virtual DbSet<ReservationOrderItems> ReservationOrderItems { get; set; }
    public virtual DbSet<ReservationOrders> ReservationOrders { get; set; }
    public virtual DbSet<Reservations> Reservations { get; set; }
    public virtual DbSet<ReservationTables> ReservationTables { get; set; }
    public virtual DbSet<RestaurantTables> RestaurantTables { get; set; }
    public virtual DbSet<TableHoldDetails> TableHoldDetails { get; set; }
    public virtual DbSet<TableHolds> TableHolds { get; set; }
    public virtual DbSet<TableTemplates> TableTemplates { get; set; }
    public virtual DbSet<UserPoints> UserPoints { get; set; }
    public virtual DbSet<UserVouchers> UserVouchers { get; set; }
    public virtual DbSet<Vouchers> Vouchers { get; set; }
    public virtual DbSet<WaittingList> WaittingLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ================= Roles =================
        modelBuilder.Entity<Roles>(entity =>
        {
            entity.ToTable("Roles");
            entity.HasKey(r => r.RoleId);
            entity.Property(r => r.RoleName).HasMaxLength(50).IsRequired();
        });

        // ================= Users =================
        modelBuilder.Entity<Users>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(u => u.UserId);

            entity.Property(u => u.Username).HasMaxLength(100);
            entity.Property(u => u.PasswordHash).HasMaxLength(255);
            entity.Property(u => u.FullName).HasMaxLength(200);
            entity.Property(u => u.Email).HasMaxLength(200);
            entity.Property(u => u.Phone).HasMaxLength(30);
            entity.Property(u => u.LanguagePref).HasMaxLength(5).HasDefaultValue("vn");
            entity.Property(u => u.IsDeleted).HasDefaultValue(false);
            entity.Property(u => u.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(u => u.UpdatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(u => u.RowVersion).IsRowVersion();

            entity.HasOne(u => u.Role)
                  .WithMany(r => r.Users)
                  .HasForeignKey(u => u.RoleId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(u => u.Email).IsUnique().HasFilter("[Email] IS NOT NULL");
            entity.HasIndex(u => u.Phone).IsUnique().HasFilter("[Phone] IS NOT NULL");
            entity.HasIndex(u => u.Username).IsUnique().HasFilter("[Username] IS NOT NULL");
        });

        // ================= BankAccounts =================
        modelBuilder.Entity<BankAccounts>(entity =>
        {
            entity.ToTable("BankAccounts");
            entity.HasKey(b => b.BankAccountId);

            entity.Property(b => b.BankAccountNumber).IsRequired();
            entity.Property(b => b.BankName).HasMaxLength(200);
            entity.Property(b => b.AccountHolderName).HasMaxLength(200);
            entity.Property(b => b.IsDefault).HasDefaultValue(false);
            entity.Property(b => b.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");

            entity.HasOne(b => b.User)
                  .WithMany(u => u.BankAccounts)
                  .HasForeignKey(b => b.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(b => new { b.UserId, b.BankAccountNumber }).IsUnique();
        });

        // ================= TableTemplates =================
        modelBuilder.Entity<TableTemplates>(entity =>
        {
            entity.ToTable("TableTemplates");
            entity.HasKey(t => t.TemplateId);
            entity.Property(t => t.TemplateCode).HasMaxLength(50).IsRequired();
            entity.Property(t => t.Seats).HasDefaultValue(6);
            entity.Property(t => t.Description).HasMaxLength(400);
        });

        // ================= RestaurantTables =================
        modelBuilder.Entity<RestaurantTables>(entity =>
        {
            entity.ToTable("RestaurantTables");
            entity.HasKey(t => t.TableId);

            entity.Property(t => t.TableCode).HasMaxLength(50).IsRequired();
            entity.Property(t => t.Zone).HasMaxLength(50);
            entity.Property(t => t.Status).HasMaxLength(20).HasDefaultValue("Available");
            entity.Property(t => t.Description).HasMaxLength(400);
            entity.Property(t => t.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(t => t.UpdatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(t => t.IsDeleted).HasDefaultValue(false);
            entity.Property(t => t.RowVersion).IsRowVersion();
            entity.Property(t => t.Price).HasColumnType("decimal(14,2)");

            entity.HasOne(t => t.Template)
                  .WithMany()
                  .HasForeignKey(t => t.TemplateId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // ================= MenuCategories =================
        modelBuilder.Entity<MenuCategories>(entity =>
        {
            entity.ToTable("MenuCategories");
            entity.HasKey(c => c.CategoryId);

            entity.Property(c => c.Name).HasMaxLength(150).IsRequired();
            entity.Property(c => c.Description).HasMaxLength(400);
            entity.Property(c => c.SortOrder).HasDefaultValue(0);
            entity.Property(c => c.isDeleted).HasDefaultValue(false);

            entity.HasIndex(c => c.Name).IsUnique();
        });

        // ================= MenuItems =================
        modelBuilder.Entity<MenuItems>(entity =>
        {
            entity.ToTable("MenuItems");
            entity.HasKey(i => i.ItemId);

            entity.Property(i => i.Code).HasMaxLength(50);
            entity.Property(i => i.Name).HasMaxLength(200).IsRequired();
            entity.Property(i => i.Description).HasMaxLength(1000);
            entity.Property(i => i.ImgUrl).HasMaxLength(255);
            entity.Property(i => i.IsAvailable).HasDefaultValue(true);
            entity.Property(i => i.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(i => i.UpdatedAt).HasDefaultValueSql("SYSUTCDATETIME()");

            entity.HasOne(i => i.Category)
                  .WithMany(c => c.MenuItems)
                  .HasForeignKey(i => i.CategoryId)
                  .OnDelete(DeleteBehavior.SetNull);

            entity.HasIndex(i => i.Code).IsUnique();
        });

        // ================= MenuItemPrices =================
        modelBuilder.Entity<MenuItemPrices>(entity =>
        {
            entity.ToTable("MenuItemPrices");
            entity.HasKey(p => p.PriceId);

            entity.Property(p => p.Price).HasColumnType("decimal(14,2)").IsRequired();
            entity.Property(p => p.Currency).HasMaxLength(10).HasDefaultValue("VND");
            entity.Property(p => p.EffectiveFrom).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(p => p.EffectiveTo);
            entity.HasCheckConstraint("CHK_MenuItemPrices_Range", "[EffectiveTo] IS NULL OR [EffectiveFrom] < [EffectiveTo]");

            entity.HasOne(p => p.Item)
                  .WithMany(i => i.Prices)
                  .HasForeignKey(p => p.ItemId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(p => new { p.ItemId, p.EffectiveFrom });
        });

        // ================= Vouchers =================
        modelBuilder.Entity<Vouchers>(entity =>
        {
            entity.ToTable("Vouchers");
            entity.HasKey(v => v.VoucherId);

            entity.Property(v => v.Code).HasMaxLength(100).IsRequired();
            entity.Property(v => v.Description).HasMaxLength(500);
            entity.Property(v => v.DiscountType).HasMaxLength(20).IsRequired();
            entity.Property(v => v.DiscountValue).HasColumnType("decimal(14,2)");
            entity.Property(v => v.MinSpend).HasColumnType("decimal(14,2)").HasDefaultValue(0);
            entity.Property(v => v.IsActive).HasDefaultValue(true);

            entity.HasCheckConstraint("CHK_VoucherPercent", "[DiscountType] <> 'Percent' OR ([DiscountValue] BETWEEN 0 AND 100)");

            entity.Property(v => v.StartDate);
            entity.Property(v => v.ExpiryDate);

            entity.HasIndex(v => v.Code).IsUnique();
        });

        // ================= UserVouchers =================
        modelBuilder.Entity<UserVouchers>(entity =>
        {
            entity.ToTable("UserVouchers");
            entity.HasKey(uv => uv.UserVoucherId);

            entity.Property(uv => uv.AssignedDate).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(uv => uv.IsUsed).HasDefaultValue(false);
            entity.Property(uv => uv.UsedDate);

            entity.HasOne(uv => uv.User)
                  .WithMany(u => u.UserVouchers)
                  .HasForeignKey(uv => uv.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(uv => uv.Voucher)
                  .WithMany(v => v.UserVouchers)
                  .HasForeignKey(uv => uv.VoucherId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(uv => new { uv.UserId, uv.VoucherId }).IsUnique();
        });

        // ================= UserPoints =================
        modelBuilder.Entity<UserPoints>(entity =>
        {
            entity.ToTable("UserPoints");
            entity.HasKey(up => up.UserId);

            entity.Property(up => up.TotalPoints).HasDefaultValue(0);
            entity.Property(up => up.LastUpdated).HasDefaultValueSql("SYSUTCDATETIME()");

            entity.HasOne(up => up.User)
                  .WithOne(u => u.UserPoints)
                  .HasForeignKey<UserPoints>(up => up.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ================= Reservations =================
        modelBuilder.Entity<Reservations>(entity =>
        {
            entity.ToTable("Reservations");
            entity.HasKey(r => r.ReservationId);

            entity.Property(r => r.ReservationCode).HasMaxLength(50).IsRequired();
            entity.Property(r => r.ReservedAt);
            entity.Property(r => r.StartTime).IsRequired();
            entity.Property(r => r.EndTime).IsRequired();
            entity.Property(r => r.GuestCount).IsRequired();
            entity.Property(r => r.Status).HasMaxLength(20).HasDefaultValue("Confirmed");
            entity.Property(r => r.Notes).HasMaxLength(500);
            entity.Property(r => r.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(r => r.UpdatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(r => r.RowVersion).IsRowVersion();

            entity.HasOne(r => r.User)
                  .WithMany(u => u.Reservations)
                  .HasForeignKey(r => r.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(r => new { r.StartTime, r.EndTime, r.Status });
        });

        // ================= ReservationTables =================
        modelBuilder.Entity<ReservationTables>(entity =>
        {
            entity.ToTable("ReservationTables");
            entity.HasKey(rt => rt.ReservationTableId);

            entity.HasOne(rt => rt.Reservation)
                  .WithMany(r => r.ReservationTables)
                  .HasForeignKey(rt => rt.ReservationId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(rt => rt.Table)
                  .WithMany(t => t.ReservationTables)
                  .HasForeignKey(rt => rt.TableId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(rt => new { rt.ReservationId, rt.TableId }).IsUnique();
        });

        // ================= ReservationOrders =================
        modelBuilder.Entity<ReservationOrders>(entity =>
        {
            entity.ToTable("ReservationOrders");
            entity.HasKey(ro => ro.OrderId);

            entity.Property(ro => ro.OrderType).HasMaxLength(20).HasDefaultValue("PreOrder");
            entity.Property(ro => ro.Status).HasMaxLength(20).HasDefaultValue("Active");
            entity.Property(ro => ro.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(ro => ro.Notes).HasMaxLength(500);

            entity.HasOne(ro => ro.Reservation)
                  .WithMany(r => r.ReservationOrders)
                  .HasForeignKey(ro => ro.ReservationId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ro => ro.CreatedByUser)
                  .WithMany(u => u.ReservationOrders)
                  .HasForeignKey(ro => ro.CreatedBy)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // ================= ReservationOrderItems =================
        modelBuilder.Entity<ReservationOrderItems>(entity =>
        {
            entity.ToTable("ReservationOrderItems");
            entity.HasKey(roi => roi.OrderItemId);

            entity.Property(roi => roi.Quantity).IsRequired();
            entity.Property(roi => roi.Status).HasMaxLength(20).HasDefaultValue("Ordered");
            entity.Property(roi => roi.Notes).HasMaxLength(500);
            entity.Property(roi => roi.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");

            entity.HasOne(roi => roi.Order)
                  .WithMany(o => o.Items)
                  .HasForeignKey(roi => roi.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(roi => roi.Item)
                  .WithMany(i => i.OrderItems)
                  .HasForeignKey(roi => roi.ItemId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // ================= TableHolds =================
        modelBuilder.Entity<TableHolds>(entity =>
        {
            entity.ToTable("TableHolds");
            entity.HasKey(th => th.HoldId);

            entity.Property(th => th.SessionId).HasMaxLength(100).IsRequired();
            entity.Property(th => th.StartTime).IsRequired();
            entity.Property(th => th.HoldStatus).HasMaxLength(20).HasDefaultValue("Holding");
            entity.Property(th => th.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(th => th.ExpireAt).HasDefaultValueSql("DATEADD(MINUTE,5,SYSUTCDATETIME())");

            entity.HasOne(th => th.User)
                  .WithMany(u => u.TableHolds)
                  .HasForeignKey(th => th.UserId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // ================= TableHoldDetails =================
        modelBuilder.Entity<TableHoldDetails>(entity =>
        {
            entity.ToTable("TableHoldDetails");
            entity.HasKey(thd => thd.HoldDetailId);

            entity.HasOne(thd => thd.TableHold)
                  .WithMany(th => th.Details)
                  .HasForeignKey(thd => thd.HoldId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(thd => thd.Table)
                  .WithMany(t => t.TableHoldDetails)
                  .HasForeignKey(thd => thd.TableId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(thd => new { thd.HoldId, thd.TableId }).IsUnique();
        });

        // ================= WaittingList =================
        modelBuilder.Entity<WaittingList>(entity =>
        {
            entity.ToTable("WaittingList");
            entity.HasKey(w => w.WaitingId);

            entity.Property(w => w.GuestName).HasMaxLength(200);
            entity.Property(w => w.Phone).HasMaxLength(30);
            entity.Property(w => w.GuestCount).IsRequired();
            entity.Property(w => w.RequestedAt);
            entity.Property(w => w.Status).HasMaxLength(20).HasDefaultValue("Waiting");
            entity.Property(w => w.Notes).HasMaxLength(500);
            entity.Property(w => w.CreatedAt);

            entity.HasOne(w => w.User)
                  .WithMany(u => u.WaittingList)
                  .HasForeignKey(w => w.UserId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // ================= Payments =================
        modelBuilder.Entity<Payments>(entity =>
        {
            entity.ToTable("Payments");
            entity.HasKey(p => p.PaymentId);

            entity.Property(p => p.Amount).HasColumnType("decimal(14,2)").IsRequired();
            entity.Property(p => p.Currency).HasMaxLength(10).HasDefaultValue("VND");
            entity.Property(p => p.PaymentMethod).HasMaxLength(50).IsRequired();
            entity.Property(p => p.Status).HasMaxLength(20).HasDefaultValue("Pending");
            entity.Property(p => p.TransactionCode).HasMaxLength(200);
            entity.Property(p => p.PaidAt);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");

            entity.HasOne(p => p.Reservation)
                  .WithMany(r => r.Payments)
                  .HasForeignKey(p => p.ReservationId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

    OnModelCreatingPartial(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
