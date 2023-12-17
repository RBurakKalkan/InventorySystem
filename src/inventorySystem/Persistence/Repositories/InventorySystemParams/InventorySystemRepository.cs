
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Application.Features.InventorySystemParams.Queries.GetListStockStatus;
using Application.Services.Repositories.InventorySystemParams;

namespace Persistence.Repositories.InventorySystemParams;

public class InventorySystemRepository : IInventorySystemRepository
{
    BaseDbContext Context { get; set; }
    public InventorySystemRepository(BaseDbContext context)
    {
        Context = context;
    }

    public async Task<List<GetListbyProductIdPaginatedDto>> GetProductInventory(int productId)
    {
        var query = from p in Context.Products
                    join pi in Context.ProductInventories on p.Id equals pi.ProductID
                    join i in Context.Inventories on pi.SKU equals i.SKU
                    join c in Context.Categories on p.Id equals c.Id
                    from uc in Context.UnitConversions.Where(uc => uc.SKU == i.SKU).DefaultIfEmpty()
                    from sm in Context.StockMovements.Where(sm => sm.SKU == i.SKU).DefaultIfEmpty()
                    from pc in Context.Categories.Where(pc => pc.Id == c.ParentCategoryID).DefaultIfEmpty()
                    where p.Id == productId
                    group new { p, i, uc, sm, c, pc } by new { p.Name, i.FriendlyName, p.Brand, i.SKU, c.CategoryName, ParentCategoryName = pc.CategoryName, i.Unit, p.Price } into g
                    select new GetListbyProductIdPaginatedDto
                    {
                        Name = g.Key.Name,
                        FriendlyName = g.Key.FriendlyName,
                        Brand = g.Key.Brand,
                        SKU = g.Key.SKU,
                        Category = String.IsNullOrEmpty(g.Key.ParentCategoryName) ? g.Key.CategoryName : g.Key.ParentCategoryName + " > " + g.Key.CategoryName,
                        MainUnit = g.Key.Unit,
                        Price = g.Key.Price,
                        StockQuantity = g.Sum(x =>
                            (x.sm.MovementType == "IN" ? (x.uc.BaseUnit != x.i.Unit && x.uc.ConvertedUnit == x.i.Unit ? x.sm.Quantity * x.uc.ConversionFactor : x.sm.Quantity) : 0) -
                            (x.sm.MovementType == "OUT" ? (x.uc.BaseUnit != x.i.Unit && x.uc.ConvertedUnit == x.i.Unit ? x.sm.Quantity * x.uc.ConversionFactor : x.sm.Quantity) : 0)
                        )
                    };


        return await query.ToListAsync();
    }
    public async Task<List<GetListStockStatusDto>> GetAllInventory()
    {
        var query = from p in Context.Products
                    join pi in Context.ProductInventories on p.Id equals pi.ProductID
                    join i in Context.Inventories on pi.SKU equals i.SKU
                    join c in Context.Categories on p.CategoryID equals c.Id
                    from uc in Context.UnitConversions.Where(uc => uc.SKU == i.SKU).DefaultIfEmpty()
                    from sm in Context.StockMovements.Where(sm => sm.SKU == i.SKU).DefaultIfEmpty()
                    from pc in Context.Categories.Where(pc => pc.Id == c.ParentCategoryID).DefaultIfEmpty()
                    group new { p, i, uc, sm, c, pc } by new { p.Name, i.FriendlyName, p.Brand, p.Price, i.Unit, c.CategoryName, ParentCategoryName = pc.CategoryName } into g
                    select new GetListStockStatusDto
                    {
                        Name = g.Key.Name,
                        FriendlyName = g.Key.FriendlyName,
                        Brand = g.Key.Brand,
                        Price = g.Key.Price,
                        SalesUnit = g.Key.Unit ?? "Adet",
                        StockStatus = g.Sum(x =>
                            (x.sm.MovementType == "IN" ? (x.uc.BaseUnit != x.i.Unit && x.uc.ConvertedUnit == x.i.Unit ? x.sm.Quantity * x.uc.ConversionFactor : x.sm.Quantity) : 0) -
                            (x.sm.MovementType == "OUT" ? (x.uc.BaseUnit != x.i.Unit && x.uc.ConvertedUnit == x.i.Unit ? x.sm.Quantity * x.uc.ConversionFactor : x.sm.Quantity) : 0)
                        ),
                        CategoryName = String.IsNullOrEmpty(g.Key.ParentCategoryName) ? g.Key.CategoryName : g.Key.ParentCategoryName + " > " + g.Key.CategoryName
                    };

        var result = await query.OrderBy(x => x.Name).ToListAsync();
        return result;
    }
}