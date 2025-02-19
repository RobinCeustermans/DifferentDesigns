using AncientCities.Domain.Aggregates.CityTypeAggregate.Repositories;
using AncientCities.Domain.Common.Interfaces;

namespace AncientCities.Application.UseCases.CityType.Commands
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
            var cityType = await _unitOfWork.CityTypeRepository.GetByIdAsync(id);
            if (cityType != null)
            {
                _unitOfWork.CityTypeRepository.Remove(cityType);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
