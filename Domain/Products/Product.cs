using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace i_want_buy.Domain.Products;

public class Product : Entity
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public bool HasStock { get; set; }
    public bool Active { get; set; } = true;
}