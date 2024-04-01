using GibsLifesMicroWebApp.Model.Domain;

namespace GibsLifesMicroWebApp.Repositories
{
    public interface ISubRisksRepository
    {
        Task<List<SubRisks>> GetAllAsync();
    }
}
