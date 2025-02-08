using Scan2Dine.EntityModels;

namespace Scan2Dine.WebApi.Repositories;

public interface IProductDefRepository
{
    Task<int?> CreateAsync(OsProductDef pd);
    Task<OsProductDef[]> RetrieveAllAsync();
    Task<OsProductDef?> RetrieveAsync(string orderNo);
}