using AncientCities.Domain.Common.Interfaces;

namespace AncientCities.Application.UseCases.City.Commands
{
    public class DeleteCityCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCityCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(int id)
        {
            var city = await _unitOfWork.CityRepository.GetByIdAsync(id);
            if (city != null)
            {
                _unitOfWork.CityRepository.Remove(city);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
