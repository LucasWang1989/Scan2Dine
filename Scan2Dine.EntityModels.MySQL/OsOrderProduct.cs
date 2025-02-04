using System;
using System.Collections.Generic;

namespace Scan2Dine.EntityModels;

/// <summary>
/// Product In Order Table
/// </summary>
public partial class OsOrderProduct
{
    /// <summary>
    /// ID
    /// </summary>
    public long FId { get; set; }

    /// <summary>
    /// Order number
    /// </summary>
    public string FOrderNo { get; set; } = null!;

    /// <summary>
    /// Product ID
    /// </summary>
    public string FProductId { get; set; } = null!;

    /// <summary>
    /// Product amount
    /// </summary>
    public string FAmount { get; set; } = null!;

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
}
