using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class StockMovement
{
    public int Id { get; set; }
    public string SKU { get; set; }
    public string MovementType { get; set; }
    public int Quantity { get; set; }
    public DateTime? MovementDate { get; set; }
}

