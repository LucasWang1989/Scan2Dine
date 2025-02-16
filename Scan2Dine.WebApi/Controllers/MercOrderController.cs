using Microsoft.AspNetCore.Mvc;
using Scan2Dine.EntityModels;
using Scan2Dine.WebApi.DTO;
using Scan2Dine.WebApi.Repositories;

namespace Scan2Dine.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MercOrderController: ControllerBase
{
    private IMercOrderRepository _repo;
    
    public MercOrderController(IMercOrderRepository mercOrderRepository)
    {
        _repo = mercOrderRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OsMercOrder>))]
    public async Task<IEnumerable<OsMercOrder>> GetMercOrder()
    {
        return await _repo.RetrieveAllAsync();
    }

    [HttpGet("{orderNo}/details")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OsOrderProduct>))]
    public async Task<IEnumerable<OrderProductDto>> GetOrderProduct(string orderNo)
    {
        return await _repo.RetrieveDetailAsync(orderNo);
    }
}