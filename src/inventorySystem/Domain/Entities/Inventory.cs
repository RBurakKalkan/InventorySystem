using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Inventory 
{
    public string SKU { get; set; }
    public string Unit { get; set; }
    public string FriendlyName { get; set; }
}
