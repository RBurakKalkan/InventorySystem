using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InventorySystemParams.Queries.GetListStockStatus;
public class GetListbyProductIdPaginatedDto
{
    public string Name { get; set; }
    public string FriendlyName { get; set; }
    public string Brand { get; set; }
    public string SKU { get; set; }
    public string Category { get; set; }
    public string MainUnit { get; set; }
    public decimal Price { get; set; }
    public decimal StockQuantity { get; set; }
}

