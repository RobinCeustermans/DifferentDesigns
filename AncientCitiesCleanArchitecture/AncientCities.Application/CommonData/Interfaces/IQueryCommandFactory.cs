namespace AncientCities.Application.CommonData.Interfaces
{
    public interface IQueryCommandFactory
    {
        T Create<T>() where T : class;
    }
}
