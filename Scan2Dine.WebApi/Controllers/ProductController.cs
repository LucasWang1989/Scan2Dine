using Microsoft.AspNetCore.Mvc;
using Scan2Dine.EntityModels;
using Scan2Dine.WebApi.Repositories;

namespace Scan2Dine.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductDefRepository _repo;
    
    // Constructor injects repository registered in Program.cs.
    public ProductController(IProductDefRepository repo)
    {
        _repo = repo;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OsProductDef>))]
    public async Task<IEnumerable<OsProductDef>> GetProducts()
    {
            return await _repo.RetrieveAllAsync();
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateProduct([FromBody] OsProductDef product)
    {
        if (product is null) return BadRequest();

        int? effected = await _repo.CreateAsync(product);

        if (effected != 1) return BadRequest("Repository failed to create customer.");

        return Created();
    }
}
