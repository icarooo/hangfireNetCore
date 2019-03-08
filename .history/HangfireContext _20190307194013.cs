using Microsoft.EntityFrameworkCore;

namespace hangfire
{
    public class HangfireContext : DbContext
{
    public HangfireContext(DbContextOptions<BancoContext> options) : base(options)
    {
       // Database.SetInitializer<HangfireContext>(null);
       // Database.CreateIfNotExists();
    }
}
}