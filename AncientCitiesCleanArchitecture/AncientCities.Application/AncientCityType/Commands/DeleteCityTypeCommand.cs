using AncientCities.Domain.Interfaces.Data;

namespace AncientCities.Application.AncientCityType.Commands
{
    public class DeleteCityTypeCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityTypeCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(int id)
        {
            var cityType = await _unitOfWork.CityTypeRepository.GetAsync(x => x.Id == id);
            if (cityType != null)
            {
                _unitOfWork.CityTypeRepository.Remove(cityType);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
