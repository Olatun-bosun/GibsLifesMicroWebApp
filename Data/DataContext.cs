using GibsLifesMicroWebApp.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace GibsLifesMicroWebApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions dbContextoptions) : base(dbContextoptions)
        {

        }

        public DbSet<PolicyMas> PolicyMaster { get; set; }

    }
}
