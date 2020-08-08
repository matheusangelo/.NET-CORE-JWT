using Login.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Login.Domain.Infra.Contexts
{
    public class LoginSampleContext : DbContext
    {
        public LoginSampleContext(DbContextOptions options) : base(options)
        {

        }

        
        public DbSet<User> users { get; set; }
    }
}