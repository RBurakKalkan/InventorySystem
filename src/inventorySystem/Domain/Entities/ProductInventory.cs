using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProductInventory 
{
    public int ProductID { get; set; }
    public string SKU { get; set; }
    public int Quantity { get; set; }
}

