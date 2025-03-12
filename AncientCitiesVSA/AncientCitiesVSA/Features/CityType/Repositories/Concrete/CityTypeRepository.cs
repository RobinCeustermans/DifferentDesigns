using Microsoft.EntityFrameworkCore;
using Features.CityType.Repositories.Abstract;
using AncientCitiesVSA.Infrastructure;

namespace Features.CityType.Repositories.Concrete
{
    public class CityTypeRepository : ICityTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public CityTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AncientCitiesVSA.Features.CityType.DomainModels.CityType>> GetAllAsync()
        {
            return await _context.Types.ToListAsync();
        }

        public async Task<AncientCitiesVSA.Features.CityType.DomainModels.CityType?> GetByIdAsync(int id)
        {
            return await _context.Types.FirstOrDefaultAsync(ct => ct.Id == id);
        }

        public async Task AddAsync(AncientCitiesVSA.Features.CityType.DomainModels.CityType cityType)
        {
            await _context.Types.AddAsync(cityType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AncientCitiesVSA.Features.CityType.DomainModels.CityType cityType)
        {
            _context.Types.Update(cityType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AncientCitiesVSA.Features.CityType.DomainModels.CityType cityType)
        {
            _context.Types.Remove(cityType);
            await _context.SaveChangesAsync();
        }
    }
}
