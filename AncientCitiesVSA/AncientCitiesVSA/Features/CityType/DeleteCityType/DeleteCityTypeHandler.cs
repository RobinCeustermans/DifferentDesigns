using Features.CityType.Repositories.Abstract;

namespace AncientCitiesVSA.Features.CityType.DeleteCityType
{
    public class DeleteCityTypeHandler : IDeleteCityTypeHandler
    {
        private readonly ICityTypeRepository _cityTypeRepository;

        public DeleteCityTypeHandler(ICityTypeRepository cityTypeRepository)
        {
            _cityTypeRepository = cityTypeRepository;
        }

        public async Task<bool> ExecuteAsync(int id)
        {
            var cityType = await _cityTypeRepository.GetByIdAsync(id);
            if (cityType == null)
                return false;

            await _cityTypeRepository.DeleteAsync(cityType);
            return true;
        }
    }
}
