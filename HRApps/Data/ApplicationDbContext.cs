using HRApps.Models.DataPelamar;
using Microsoft.EntityFrameworkCore;

namespace HRApps.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Pelamar> Pelamars { get; set; }
    }
}
