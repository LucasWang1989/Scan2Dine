using Scan2Dine.EntityModels;

namespace Scan2Dine.Mvc.Models;

public class OrderProductModel: OsOrderProduct
{
    public long ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public long ProductPrice { get; set; }
    public string ProductDesc { get; set; } = null!;
    public string ProductImgPath { get; set; } = null!;
    
    public string PayStatus { get; set; } = null!;
    public string OrderStatus { get; set; } = null!;
    public string CookingStatus { get; set; } = null!;
    public string TableNo { get; set; } = null!;
}