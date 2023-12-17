using Application.Features.InventorySystemParams.Queries.GetListStockStatus;
using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories.InventorySystemParams;
public interface IInventorySystemRepository
{
    public Task<List<GetListStockStatusDto>> GetAllInventory();
    public Task<List<GetListbyProductIdPaginatedDto>> GetProductInventory(int productId);
}
