using System.Data.Entity;

namespace BfuDay2.Models
{
    public class BfuContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public BfuContext() : base("Context")
        {

        }
    }
}