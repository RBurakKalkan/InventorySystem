
using Application.Features.InventorySystemParams.Queries.GetListStockStatus;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebAPI.Controllers.CategoriesParams;

[Route("api/[controller]")]
[ApiController]
public class InventorySystemController : BaseController
{
    [HttpGet("ProductId")]
    public async Task<IActionResult> GetListbyProductIdPaginated([FromQuery] int ProductId, [FromQuery] PageRequest pageRequest)
    {
        GetListbyProductIdPaginatedQuery getListCategoriesQuery = new() { productId = ProductId, PageRequest = pageRequest };
        GetListResponse<GetListbyProductIdPaginatedDto> response = await Mediator.Send(getListCategoriesQuery);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetListStockStatus([FromQuery] PageRequest pageRequest)
    {
        GetListStockStatusQuery getListCategoriesQuery = new() {PageRequest = pageRequest };
        GetListResponse<GetListStockStatusDto> response = await Mediator.Send(getListCategoriesQuery);
        return Ok(response);
    }
}