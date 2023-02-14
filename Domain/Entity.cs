using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace i_want_buy.Domain;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public String CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string EditedBy { get; set; }
    public DateTime EditedAt { get; set; }
}