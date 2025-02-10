using System.Numerics;
using Scan2Dine.EntityModels;

namespace Scan2Dine.Mvc.Models;

public class ProductModel: OsProductDef
{
    public BigInteger DishNumber { get; set; }
    public string OrderNo { get; set; } = null!;
    public string PayStatus { get; set; } = null!;
    public string OrderStatus { get; set; } = null!;
    public string CookingStatus { get; set; } = null!;
    public string TableNo { get; set; } = null!;
}