using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace i_want_buy.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; } = true;
}