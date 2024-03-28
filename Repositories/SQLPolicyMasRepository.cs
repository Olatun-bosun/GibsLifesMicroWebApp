using GibsLifesMicroWebApp.Data;
using GibsLifesMicroWebApp.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace GibsLifesMicroWebApp.Repositories
{
    public class SQLPolicyMasRepository : IPolicyMasRepository
    {
        private readonly DataContext dbContext;
        public SQLPolicyMasRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<PolicyMas> CreateAsync(PolicyMas policyMas)
        {
            await dbContext.PolicyMaster.AddAsync(policyMas);
            await dbContext.SaveChangesAsync();
            return policyMas;
        }

        public async Task<List<PolicyMas>> GetAllAsync()
        {
            return await dbContext.PolicyMaster.ToListAsync();
        }

        public async Task<PolicyMas?> GetByPolicyIDAsync(long policyID)
        {
            return await dbContext.PolicyMaster.FirstOrDefaultAsync(x => x.PolicyID == policyID);
        }
    }
}
