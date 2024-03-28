using GibsLifesMicroWebApp.Model.Domain;

namespace GibsLifesMicroWebApp.Repositories
{
    public interface IPolicyMasRepository
    {
        Task<List<PolicyMas>> GetAllAsync();
        Task<PolicyMas?> GetByPolicyIDAsync(long policyID);

        Task<PolicyMas> CreateAsync(PolicyMas policyMas);
    }
}
