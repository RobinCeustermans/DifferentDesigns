namespace AncientCitiesVSA.Features.CityType.DeleteCityType
{
    public interface IDeleteCityTypeHandler
    {
        Task<bool> ExecuteAsync(int id);
    }
}
