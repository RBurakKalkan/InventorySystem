﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Categories 
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public int ParentCategoryID { get; set; }
}
