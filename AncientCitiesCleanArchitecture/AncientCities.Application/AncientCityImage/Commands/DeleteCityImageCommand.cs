using AncientCities.Domain.Interfaces.Data;
using AutoMapper;

namespace AncientCities.Application.AncientCityImage.Commands
{
    public class DeleteCityImageCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCityImageCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(int id)
        {
            var cityImage = await _unitOfWork.CityImageRepository.GetAsync(x => x.Id == id);
            if (cityImage != null) 
            {
                _unitOfWork.CityImageRepository.Remove(cityImage);
                await _unitOfWork.SaveAsync();
            }
        } 
    }
}
