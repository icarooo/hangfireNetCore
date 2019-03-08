using Microsoft.EntityFrameworkCore;

namespace hangfire
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options): base(options)
        { }

        
        
        
    }
}