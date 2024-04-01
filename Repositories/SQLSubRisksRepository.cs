using GibsLifesMicroWebApp.Data;
using GibsLifesMicroWebApp.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace GibsLifesMicroWebApp.Repositories
{
    public class SQLSubRisksRepository : ISubRisksRepository
    {
        private readonly DataContext dbContext;
        public SQLSubRisksRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<SubRisks>> GetAllAsync()
        {
            return await dbContext.SubRisks.ToListAsync();
        }
    }
}
