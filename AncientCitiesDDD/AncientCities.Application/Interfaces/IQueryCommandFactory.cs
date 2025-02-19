namespace AncientCities.Application.Interfaces
{
    public interface IQueryCommandFactory
    {
        T Create<T>() where T : class;
    }
}
