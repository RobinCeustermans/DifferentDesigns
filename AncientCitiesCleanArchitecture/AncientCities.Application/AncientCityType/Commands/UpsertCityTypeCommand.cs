using AncientCities.Domain.Entities;
using AncientCities.Domain.Interfaces.Data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientCities.Application.AncientCityType.Commands
{
    public class UpsertCityTypeCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpsertCityTypeCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(CityTypeDto cityTypeDto)
        {
            var cityType = _mapper.Map<CityType>(cityTypeDto);

            if (cityType.Id == 0)
            {
                _unitOfWork.CityTypeRepository.Add(cityType);
            }
            else
            {
                _unitOfWork.CityTypeRepository.Update(cityType);
            }

            await _unitOfWork.SaveAsync();
        }
    }
}
