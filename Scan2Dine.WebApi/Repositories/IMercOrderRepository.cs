using Scan2Dine.EntityModels;
using Scan2Dine.WebApi.DTO;

namespace Scan2Dine.WebApi.Repositories;

public interface IMercOrderRepository
{
    Task<int?> CreateAsync(OsMercOrder morder);
    Task<OsMercOrder[]> RetrieveAllAsync();
    Task<OsMercOrder?> RetrieveAsync(string orderNo);

    Task<OrderProductDto[]> RetrieveDetailAsync(string orderNo);
}