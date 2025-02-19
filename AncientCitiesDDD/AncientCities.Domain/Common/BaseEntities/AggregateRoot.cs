using AncientCities.Domain.Common.Interfaces;
using System.Collections.Generic;

namespace AncientCities.Domain.Common.BaseEntities
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        //You could add domain events here
    }
}
