using AncientCities.Domain.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientCities.Application.AncientCity.Commands
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
            var city = await _unitOfWork.CityRepository.GetAsync(x => x.Id == id);
            if (city != null)
            {
                _unitOfWork.CityRepository.Remove(city);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
