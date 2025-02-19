namespace AncientCities.Domain.Common.BaseEntities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity other) 
                return false;
            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
