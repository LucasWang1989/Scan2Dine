using System;
using System.Collections.Generic;

namespace Scan2Dine.EntityModels;

/// <summary>
/// Channel Refund Order Table
/// </summary>
public partial class OsChannelRefundOrder
{
    /// <summary>
    /// ID
    /// </summary>
    public long FId { get; set; }

    /// <summary>
    /// Inner original payment order numbers
    /// </summary>
    public string? FOriPayOrderNo { get; set; }

    /// <summary>
    /// Inner refund order numbers
    /// </summary>
    public string? FRefundOrderNo { get; set; }

    /// <summary>
    /// Channel refund order numbers
    /// </summary>
    public string? FChannelRefundOrderNo { get; set; }

    /// <summary>
    /// Payment type: 10-PayPal
    /// </summary>
    public string FPayType { get; set; } = null!;

    /// <summary>
    /// Channel number
    /// </summary>
    public string? FChannelNo { get; set; }

    /// <summary>
    /// Refund amount
    /// </summary>
    public long FRefundAmount { get; set; }

    /// <summary>
    /// Refund time
    /// </summary>
    public string FRefundTime { get; set; } = null!;

    /// <summary>
    /// Remark
    /// </summary>
    public string? FRemark { get; set; }

    /// <summary>
    /// Refund status: 0-no refunded;1-Refund success;2-Refund failure;3-Refunding
    /// </summary>
    public string? FRefundStatus { get; set; }

    /// <summary>
    /// Record updated time
    /// </summary>
    public string FUpdateTime { get; set; } = null!;

    /// <summary>
    /// Record created time
    /// </summary>
    public string FCreatedTime { get; set; } = null!;

    /// <summary>
    /// Channel merchant ID
    /// </summary>
    public string? FChannelMercId { get; set; }

    /// <summary>
    /// Refund failure reasons
    /// </summary>
    public string? FFailReasons { get; set; }
}
