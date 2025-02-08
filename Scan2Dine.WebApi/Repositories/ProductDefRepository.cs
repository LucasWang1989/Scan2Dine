using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Caching.Memory;
using Scan2Dine.EntityModels;

namespace Scan2Dine.WebApi.Repositories;

public class ProductDefRepository: IProductDefRepository
{
    private readonly IMemoryCache _memoryCache;
    
    private readonly MemoryCacheEntryOptions _cacheEntryOptions = new MemoryCacheEntryOptions()
    {
        SlidingExpiration = TimeSpan.FromMinutes(30)
    };

    private OsDbContext _db;

    public ProductDefRepository(OsDbContext db, IMemoryCache memoryCache)
    {
        _db = db;
        _memoryCache = memoryCache;
    }
    
    public async Task<int?> CreateAsync(OsProductDef pd)
    {
        EntityEntry<OsProductDef> added = await _db.OsProductDefs.AddAsync(pd);
        int affected = await _db.SaveChangesAsync();
        if (affected == 1)
        {
            _memoryCache.Set(pd.FId, pd, _cacheEntryOptions);
            return affected;
        }
        return null;
    }

    public Task<OsProductDef[]> RetrieveAllAsync()
    {
        return _db.OsProductDefs.ToArrayAsync();
    }

    public Task<OsProductDef?> RetrieveAsync(string id)
    {
        if (_memoryCache.TryGetValue(id, out OsProductDef? fromCache))
            return Task.FromResult(fromCache);

        OsProductDef? fromDb = _db.OsProductDefs.FirstOrDefault(pd => pd.FId == long.Parse(id));

        if (fromDb is null) return Task.FromResult(fromDb);

        _memoryCache.Set(fromDb.FId, fromDb, _cacheEntryOptions);

        return Task.FromResult(fromDb)!;
    }
}