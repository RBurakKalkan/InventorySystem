using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class UnitConversion 
{
    public string SKU { get; set; }
    public string BaseUnit { get; set; }
    public string ConvertedUnit { get; set; }
    public decimal ConversionFactor { get; set; }
}

