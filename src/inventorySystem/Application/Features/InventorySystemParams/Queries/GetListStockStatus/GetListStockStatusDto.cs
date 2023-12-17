using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InventorySystemParams.Queries.GetListStockStatus;
public class GetListStockStatusDto
{
    public string Name { get; set; }
    public string FriendlyName { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public string SalesUnit { get; set; }
    public decimal StockStatus { get; set; }
    public string CategoryName { get; set; }
}

