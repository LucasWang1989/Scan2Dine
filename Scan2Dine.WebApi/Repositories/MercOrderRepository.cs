using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Scan2Dine.EntityModels;
using Scan2Dine.WebApi.DTO;

namespace Scan2Dine.WebApi.Repositories;

public class MercOrderRepository: IMercOrderRepository
{
    private readonly IMemoryCache _memoryCache;

    private readonly MemoryCacheEntryOptions _cacheEntryOptions = new()
    {
        SlidingExpiration = TimeSpan.FromMinutes(30)
    };

    private OsDbContext _dbContext;

    public MercOrderRepository(OsDbContext dbContext, IMemoryCache memoryCache)
    {
        _dbContext = dbContext;
        _memoryCache = memoryCache;
    }
    
    
    public Task<int?> CreateAsync(OsMercOrder morder)
    {
        throw new NotImplementedException();
    }

    public Task<OsMercOrder[]> RetrieveAllAsync()
    {
        return _dbContext.OsMercOrders.ToArrayAsync();
    }

    public Task<OsMercOrder?> RetrieveAsync(string orderNo)
    {
        throw new NotImplementedException();
    }

    public Task<OrderProductDto[]> RetrieveDetailAsync(string orderNo)
    {
        return _dbContext.OsOrderProducts
            .Join(_dbContext.OsProductDefs,
                op => op.FProductId,
                pd => pd.FId,
                (op, pd) => new { op, pd })
            .Join(_dbContext.OsMercOrders,
                temp => temp.op.FOrderNo,
                mo => mo.FOrderNo,
                (temp, mo) => new OrderProductDto
                {
                    FOrderNo = temp.op.FOrderNo,
                    FAmount = temp.op.FAmount,
                    PayStatus = mo.FPayStatus,
                    OrderStatus = mo.FOrderStatus,
                    CookingStatus = mo.FCookingStatus,
                    TableNo = mo.FTableNo,
                    ProductId = temp.pd.FId,
                    ProductName = temp.pd.FName,
                    ProductPrice = temp.pd.FPrice,
                    ProductDesc = temp.pd.FDesc,
                    ProductImgPath = temp.pd.FImgPath
                })
            .Where(x => x.FOrderNo == orderNo)
            .ToArrayAsync();
    }
}