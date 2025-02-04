using System;
using System.Collections.Generic;

namespace Scan2Dine.EntityModels;

/// <summary>
/// Channel Payment Order Table
/// </summary>
public partial class OsChannelPayOrder
{
    /// <summary>
    /// ID
    /// </summary>
    public int FId { get; set; }

    /// <summary>
    /// Inner payment order numbers
    /// </summary>
    public string FPayOrderNo { get; set; } = null!;

    /// <summary>
    /// Payment type: 10-PayPal
    /// </summary>
    public string FPayType { get; set; } = null!;

    /// <summary>
    /// Channel numbers
    /// </summary>
    public string? FChannelNo { get; set; }

    /// <summary>
    /// Channel payment order number for payment
    /// </summary>
    public string? FChannelPayOrderNo { get; set; }

    /// <summary>
    /// Payment status 0-No pay; 1-Paid; 2-Payment failed
    /// </summary>
    public string FPayStatus { get; set; } = null!;

    /// <summary>
    /// Order amount
    /// </summary>
    public long FPayAmount { get; set; }

    /// <summary>
    /// Payment time
    /// </summary>
    public string FPayTime { get; set; } = null!;

    /// <summary>
    /// Remark
    /// </summary>
    public string? FRemark { get; set; }

    /// <summary>
    /// Record updated time
    /// </summary>
    public string FUpdateTime { get; set; } = null!;

    /// <summary>
    /// Record created time
    /// </summary>
    public string FCreatedTime { get; set; } = null!;

    /// <summary>
    /// Channel merchant number
    /// </summary>
    public string? FChannelMercId { get; set; }
}
