using System;
using System.Collections.Generic;

namespace Scan2Dine.EntityModels;

/// <summary>
/// Product Definition Table
/// </summary>
public partial class OsProductDef
{
    /// <summary>
    /// ID
    /// </summary>
    public long FId { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    public string FName { get; set; } = null!;

    /// <summary>
    /// Product price
    /// </summary>
    public long FPrice { get; set; }

    /// <summary>
    /// Product description
    /// </summary>
    public string FDesc { get; set; } = null!;

    /// <summary>
    /// Product image path
    /// </summary>
    public string? FImgPath { get; set; }

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
