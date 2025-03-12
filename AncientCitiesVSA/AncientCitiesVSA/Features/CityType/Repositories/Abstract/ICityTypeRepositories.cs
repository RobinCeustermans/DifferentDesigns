namespace Features.CityType.Repositories.Abstract
{
    using CityType = AncientCitiesVSA.Features.CityType.DomainModels.CityType;

    public interface ICityTypeRepository
    {
        Task<IEnumerable<CityType>> GetAllAsync();
        Task<CityType?> GetByIdAsync(int id);
        Task AddAsync(CityType cityType);
        Task UpdateAsync(CityType cityType);
        Task DeleteAsync(CityType cityType);
    }
}