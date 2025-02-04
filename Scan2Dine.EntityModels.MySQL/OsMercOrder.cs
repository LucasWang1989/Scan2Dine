using System;
using System.Collections.Generic;

namespace Scan2Dine.EntityModels;

/// <summary>
/// Merchant Order Table
/// </summary>
public partial class OsMercOrder
{
    /// <summary>
    /// ID
    /// </summary>
    public long FId { get; set; }

    /// <summary>
    /// Order numbers
    /// </summary>
    public string FOrderNo { get; set; } = null!;

    /// <summary>
    /// Table numbers
    /// </summary>
    public string FTableNo { get; set; } = null!;

    /// <summary>
    /// Merchant ID
    /// </summary>
    public string FMercId { get; set; } = null!;

    /// <summary>
    /// Shop numbers
    /// </summary>
    public string? FShopId { get; set; }

    /// <summary>
    /// Payment type: 10-PayPal online
    /// </summary>
    public string FPayType { get; set; } = null!;

    /// <summary>
    /// Order status: 0-Pre created; 1-Created; 2-Finished; 3-Cancelled
    /// </summary>
    public string FOrderStatus { get; set; } = null!;

    /// <summary>
    /// Refund status: 0-No refund; 1-Partial refund; 2-Full refund
    /// </summary>
    public string FRefundStatus { get; set; } = null!;

    /// <summary>
    /// Payment status: 0-No pay; 1-Paid; 2-Payment failed
    /// </summary>
    public string FPayStatus { get; set; } = null!;

    /// <summary>
    /// Cooking status: 0-Pending; 1-Delivered; 2-Canceled
    /// </summary>
    public string FCookingStatus { get; set; } = null!;

    /// <summary>
    /// Order amount
    /// </summary>
    public long FOrderAmount { get; set; }

    /// <summary>
    /// Refundable amount
    /// </summary>
    public long? FResidueRefundAmount { get; set; }

    /// <summary>
    /// Amount refunded
    /// </summary>
    public long? FAlreadyRefundAmount { get; set; }

    /// <summary>
    /// Product details
    /// </summary>
    public string? FProductDesc { get; set; }

    /// <summary>
    /// Record updated date
    /// </summary>
    public string FUpdateDate { get; set; } = null!;

    /// <summary>
    /// Record updated time
    /// </summary>
    public string FUpdateTime { get; set; } = null!;

    /// <summary>
    /// Record created date
    /// </summary>
    public string FCreatedDate { get; set; } = null!;

    /// <summary>
    /// Record created time
    /// </summary>
    public string FCreatedTime { get; set; } = null!;

    /// <summary>
    /// Order type: 1-payment order 2-refund order
    /// </summary>
    public string? FOrderType { get; set; }

    /// <summary>
    /// Extended field
    /// </summary>
    public string? FExtPara { get; set; }

    /// <summary>
    /// Reserved field
    /// </summary>
    public string? FReserved { get; set; }

    /// <summary>
    /// Reserved field 2
    /// </summary>
    public string? FReserved1 { get; set; }

    /// <summary>
    /// Reserved field 3
    /// </summary>
    public string? FReserved2 { get; set; }
}
