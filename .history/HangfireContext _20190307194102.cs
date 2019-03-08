using Microsoft.EntityFrameworkCore;

namespace hangfire
{
    public class HangfireContext : DbContext
{
    public HangfireContext() : base("name=BancoContext")
    {
       // Database.SetInitializer<HangfireContext>(null);
       // Database.CreateIfNotExists();
    }
}
}