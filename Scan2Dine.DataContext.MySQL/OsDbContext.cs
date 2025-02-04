using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Scan2Dine.EntityModels;

public partial class OsDbContext : DbContext
{
    public OsDbContext()
    {
    }

    public OsDbContext(DbContextOptions<OsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OsChannelPayOrder> OsChannelPayOrders { get; set; }

    public virtual DbSet<OsChannelRefundOrder> OsChannelRefundOrders { get; set; }

    public virtual DbSet<OsMercOrder> OsMercOrders { get; set; }

    public virtual DbSet<OsOrderProduct> OsOrderProducts { get; set; }

    public virtual DbSet<OsProductDef> OsProductDefs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=root;database=os_db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OsChannelPayOrder>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PRIMARY");

            entity.ToTable("os_channel_pay_order", tb => tb.HasComment("Channel Payment Order Table"));

            entity.HasIndex(e => e.FPayOrderNo, "idx_f_order_no");

            entity.HasIndex(e => e.FId, "uniq_f_id").IsUnique();

            entity.Property(e => e.FId)
                .HasComment("ID")
                .HasColumnType("int(10)")
                .HasColumnName("F_ID");
            entity.Property(e => e.FChannelMercId)
                .HasMaxLength(128)
                .HasComment("Channel merchant number")
                .HasColumnName("F_CHANNEL_MERC_ID");
            entity.Property(e => e.FChannelNo)
                .HasMaxLength(20)
                .HasComment("Channel numbers")
                .HasColumnName("F_CHANNEL_NO");
            entity.Property(e => e.FChannelPayOrderNo)
                .HasMaxLength(64)
                .HasComment("Channel payment order number for payment")
                .HasColumnName("F_CHANNEL_PAY_ORDER_NO");
            entity.Property(e => e.FCreatedTime)
                .HasMaxLength(32)
                .HasComment("Record created time")
                .HasColumnName("F_CREATED_TIME");
            entity.Property(e => e.FPayAmount)
                .HasComment("Order amount")
                .HasColumnType("bigint(20)")
                .HasColumnName("F_PAY_AMOUNT");
            entity.Property(e => e.FPayOrderNo)
                .HasMaxLength(64)
                .HasComment("Inner payment order numbers")
                .HasColumnName("F_PAY_ORDER_NO");
            entity.Property(e => e.FPayStatus)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("Payment status 0-No pay; 1-Paid; 2-Payment failed")
                .HasColumnName("F_PAY_STATUS");
            entity.Property(e => e.FPayTime)
                .HasMaxLength(20)
                .HasComment("Payment time")
                .HasColumnName("F_PAY_TIME");
            entity.Property(e => e.FPayType)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasComment("Payment type: 10-PayPal")
                .HasColumnName("F_PAY_TYPE");
            entity.Property(e => e.FRemark)
                .HasMaxLength(64)
                .HasComment("Remark")
                .HasColumnName("F_REMARK");
            entity.Property(e => e.FUpdateTime)
                .HasMaxLength(32)
                .HasComment("Record updated time")
                .HasColumnName("F_UPDATE_TIME");
        });

        modelBuilder.Entity<OsChannelRefundOrder>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PRIMARY");

            entity.ToTable("os_channel_refund_order", tb => tb.HasComment("Channel Refund Order Table"));

            entity.HasIndex(e => e.FRefundOrderNo, "uniq_fefund_order_no").IsUnique();

            entity.Property(e => e.FId)
                .HasComment("ID")
                .HasColumnType("bigint(20)")
                .HasColumnName("F_ID");
            entity.Property(e => e.FChannelMercId)
                .HasMaxLength(60)
                .HasComment("Channel merchant ID")
                .HasColumnName("F_CHANNEL_MERC_ID");
            entity.Property(e => e.FChannelNo)
                .HasMaxLength(20)
                .HasComment("Channel number")
                .HasColumnName("F_CHANNEL_NO");
            entity.Property(e => e.FChannelRefundOrderNo)
                .HasMaxLength(64)
                .HasComment("Channel refund order numbers")
                .HasColumnName("F_CHANNEL_REFUND_ORDER_NO");
            entity.Property(e => e.FCreatedTime)
                .HasMaxLength(32)
                .HasComment("Record created time")
                .HasColumnName("F_CREATED_TIME");
            entity.Property(e => e.FFailReasons)
                .HasMaxLength(255)
                .HasComment("Refund failure reasons")
                .HasColumnName("F_FAIL_REASONS");
            entity.Property(e => e.FOriPayOrderNo)
                .HasMaxLength(64)
                .HasComment("Inner original payment order numbers")
                .HasColumnName("F_ORI_PAY_ORDER_NO");
            entity.Property(e => e.FPayType)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasComment("Payment type: 10-PayPal")
                .HasColumnName("F_PAY_TYPE");
            entity.Property(e => e.FRefundAmount)
                .HasComment("Refund amount")
                .HasColumnType("bigint(20)")
                .HasColumnName("F_REFUND_AMOUNT");
            entity.Property(e => e.FRefundOrderNo)
                .HasMaxLength(64)
                .HasComment("Inner refund order numbers")
                .HasColumnName("F_REFUND_ORDER_NO");
            entity.Property(e => e.FRefundStatus)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("Refund status: 0-no refunded;1-Refund success;2-Refund failure;3-Refunding")
                .HasColumnName("F_REFUND_STATUS");
            entity.Property(e => e.FRefundTime)
                .HasMaxLength(20)
                .HasComment("Refund time")
                .HasColumnName("F_REFUND_TIME");
            entity.Property(e => e.FRemark)
                .HasMaxLength(64)
                .HasComment("Remark")
                .HasColumnName("F_REMARK");
            entity.Property(e => e.FUpdateTime)
                .HasMaxLength(32)
                .HasComment("Record updated time")
                .HasColumnName("F_UPDATE_TIME");
        });

        modelBuilder.Entity<OsMercOrder>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PRIMARY");

            entity.ToTable("os_merc_order", tb => tb.HasComment("Merchant Order Table"));

            entity.HasIndex(e => e.FOrderNo, "uniq_f_order_no").IsUnique();

            entity.Property(e => e.FId)
                .HasComment("ID")
                .HasColumnType("bigint(20)")
                .HasColumnName("F_ID");
            entity.Property(e => e.FAlreadyRefundAmount)
                .HasComment("Amount refunded")
                .HasColumnType("bigint(20)")
                .HasColumnName("F_ALREADY_REFUND_AMOUNT");
            entity.Property(e => e.FCookingStatus)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("Cooking status: 0-Pending; 1-Delivered; 2-Canceled")
                .HasColumnName("F_COOKING_STATUS");
            entity.Property(e => e.FCreatedDate)
                .HasMaxLength(8)
                .HasComment("Record created date")
                .HasColumnName("F_CREATED_DATE");
            entity.Property(e => e.FCreatedTime)
                .HasMaxLength(6)
                .HasComment("Record created time")
                .HasColumnName("F_CREATED_TIME");
            entity.Property(e => e.FExtPara)
                .HasComment("Extended field")
                .HasColumnType("text")
                .HasColumnName("F_EXT_PARA");
            entity.Property(e => e.FMercId)
                .HasMaxLength(20)
                .HasComment("Merchant ID")
                .HasColumnName("F_MERC_ID");
            entity.Property(e => e.FOrderAmount)
                .HasComment("Order amount")
                .HasColumnType("bigint(20)")
                .HasColumnName("F_ORDER_AMOUNT");
            entity.Property(e => e.FOrderNo)
                .HasMaxLength(64)
                .HasComment("Order numbers")
                .HasColumnName("F_ORDER_NO");
            entity.Property(e => e.FOrderStatus)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("Order status: 0-Pre created; 1-Created; 2-Finished; 3-Cancelled")
                .HasColumnName("F_ORDER_STATUS");
            entity.Property(e => e.FOrderType)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("Order type: 1-payment order 2-refund order")
                .HasColumnName("F_ORDER_TYPE");
            entity.Property(e => e.FPayStatus)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("Payment status: 0-No pay; 1-Paid; 2-Payment failed")
                .HasColumnName("F_PAY_STATUS");
            entity.Property(e => e.FPayType)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasComment("Payment type: 10-PayPal online")
                .HasColumnName("F_PAY_TYPE");
            entity.Property(e => e.FProductDesc)
                .HasMaxLength(128)
                .HasComment("Product details")
                .HasColumnName("F_PRODUCT_DESC");
            entity.Property(e => e.FRefundStatus)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("Refund status: 0-No refund; 1-Partial refund; 2-Full refund")
                .HasColumnName("F_REFUND_STATUS");
            entity.Property(e => e.FReserved)
                .HasMaxLength(30)
                .HasComment("Reserved field")
                .HasColumnName("F_RESERVED");
            entity.Property(e => e.FReserved1)
                .HasMaxLength(30)
                .HasComment("Reserved field 2")
                .HasColumnName("F_RESERVED_1");
            entity.Property(e => e.FReserved2)
                .HasMaxLength(30)
                .HasComment("Reserved field 3")
                .HasColumnName("F_RESERVED_2");
            entity.Property(e => e.FResidueRefundAmount)
                .HasComment("Refundable amount")
                .HasColumnType("bigint(20)")
                .HasColumnName("F_RESIDUE_REFUND_AMOUNT");
            entity.Property(e => e.FShopId)
                .HasMaxLength(20)
                .HasComment("Shop numbers")
                .HasColumnName("F_SHOP_ID");
            entity.Property(e => e.FTableNo)
                .HasMaxLength(3)
                .HasComment("Table numbers")
                .HasColumnName("F_TABLE_NO");
            entity.Property(e => e.FUpdateDate)
                .HasMaxLength(8)
                .HasComment("Record updated date")
                .HasColumnName("F_UPDATE_DATE");
            entity.Property(e => e.FUpdateTime)
                .HasMaxLength(6)
                .HasComment("Record updated time")
                .HasColumnName("F_UPDATE_TIME");
        });

        modelBuilder.Entity<OsOrderProduct>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PRIMARY");

            entity.ToTable("os_order_product", tb => tb.HasComment("Product In Order Table"));

            entity.HasIndex(e => new { e.FOrderNo, e.FProductId }, "uniq_f_order_no").IsUnique();

            entity.Property(e => e.FId)
                .HasComment("ID")
                .HasColumnType("bigint(20)")
                .HasColumnName("F_ID");
            entity.Property(e => e.FAmount)
                .HasMaxLength(128)
                .HasComment("Product amount")
                .HasColumnName("F_AMOUNT");
            entity.Property(e => e.FCreatedDate)
                .HasMaxLength(8)
                .HasComment("Record created date")
                .HasColumnName("F_CREATED_DATE");
            entity.Property(e => e.FCreatedTime)
                .HasMaxLength(6)
                .HasComment("Record created time")
                .HasColumnName("F_CREATED_TIME");
            entity.Property(e => e.FOrderNo)
                .HasMaxLength(64)
                .HasComment("Order number")
                .HasColumnName("F_ORDER_NO");
            entity.Property(e => e.FProductId)
                .HasMaxLength(5)
                .HasComment("Product ID")
                .HasColumnName("F_PRODUCT_ID");
            entity.Property(e => e.FUpdateDate)
                .HasMaxLength(8)
                .HasComment("Record updated date")
                .HasColumnName("F_UPDATE_DATE");
            entity.Property(e => e.FUpdateTime)
                .HasMaxLength(6)
                .HasComment("Record updated time")
                .HasColumnName("F_UPDATE_TIME");
        });

        modelBuilder.Entity<OsProductDef>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PRIMARY");

            entity.ToTable("os_product_def", tb => tb.HasComment("Product Definition Table"));

            entity.HasIndex(e => e.FName, "uniq_product_def").IsUnique();

            entity.Property(e => e.FId)
                .HasComment("ID")
                .HasColumnType("bigint(20)")
                .HasColumnName("F_ID");
            entity.Property(e => e.FCreatedDate)
                .HasMaxLength(8)
                .HasComment("Record created date")
                .HasColumnName("F_CREATED_DATE");
            entity.Property(e => e.FCreatedTime)
                .HasMaxLength(6)
                .HasComment("Record created time")
                .HasColumnName("F_CREATED_TIME");
            entity.Property(e => e.FDesc)
                .HasComment("Product description")
                .HasColumnType("text")
                .HasColumnName("F_DESC");
            entity.Property(e => e.FImgPath)
                .HasMaxLength(128)
                .HasComment("Product image path")
                .HasColumnName("F_IMG_PATH");
            entity.Property(e => e.FName)
                .HasMaxLength(64)
                .HasComment("Product name")
                .HasColumnName("F_NAME");
            entity.Property(e => e.FPrice)
                .HasComment("Product price")
                .HasColumnType("bigint(20)")
                .HasColumnName("F_PRICE");
            entity.Property(e => e.FUpdateDate)
                .HasMaxLength(8)
                .HasComment("Record updated date")
                .HasColumnName("F_UPDATE_DATE");
            entity.Property(e => e.FUpdateTime)
                .HasMaxLength(6)
                .HasComment("Record updated time")
                .HasColumnName("F_UPDATE_TIME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
