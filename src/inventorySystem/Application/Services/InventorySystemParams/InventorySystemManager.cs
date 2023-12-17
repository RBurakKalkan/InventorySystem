
using Application.Features.InventorySystemParams.Rules;
using Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Drawing;
using Application.Features.InventorySystemParams.Queries.GetListStockStatus;
using Application.Services.Repositories.InventorySystemParams;

namespace Application.Services.InventorySystemParams;

public class InventorySystemManager : IInventorySystemService
{
    private readonly IInventorySystemRepository _categoriesRepository;
    private readonly CategoriesBusinessRules _categoriesBusinessRules;

    public InventorySystemManager(IInventorySystemRepository categoriesRepository, CategoriesBusinessRules categoriesBusinessRules)
    {
        _categoriesRepository = categoriesRepository;
        _categoriesBusinessRules = categoriesBusinessRules;
    }

    public async Task<IPaginate<GetListStockStatusDto>> GetList(int index = 0, int size = 10, CancellationToken cancellationToken = default) 
    {
        IList<GetListStockStatusDto> categoriesParamsList = await _categoriesRepository.GetAllInventory();

        IPaginate<GetListStockStatusDto> paginatedResult = new Paginate<GetListStockStatusDto>(categoriesParamsList, index, size, from: 0);

        return paginatedResult;
    }

    public async Task< IPaginate<GetListbyProductIdPaginatedDto>> GetListByProductId(int productId,
        int index = 0,
        int size = 10,
        CancellationToken cancellationToken = default)
    {
        IList<GetListbyProductIdPaginatedDto> categoriesParamsList = await _categoriesRepository.GetProductInventory(productId);

        IPaginate<GetListbyProductIdPaginatedDto> paginatedResult = new Paginate<GetListbyProductIdPaginatedDto>(categoriesParamsList, index, size, from: 0);

        return paginatedResult;
    }
}
