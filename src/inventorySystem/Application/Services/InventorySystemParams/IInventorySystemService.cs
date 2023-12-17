using Application.Features.InventorySystemParams.Queries.GetListStockStatus;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.InventorySystemParams;

public interface IInventorySystemService
{
    public Task<IPaginate<GetListbyProductIdPaginatedDto>> GetListByProductId(int productId,
            int index = 0,
            int size = 10,
            CancellationToken cancellationToken = default);
    public Task<IPaginate<GetListStockStatusDto>> GetList(
        int index = 0,
        int size = 10,
        CancellationToken cancellationToken = default);
}
