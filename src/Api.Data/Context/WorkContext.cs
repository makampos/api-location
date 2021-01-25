using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class WorkContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public WorkContext(DbContextOptions<WorkContext> options) : base (options)
        {

        }
        
        protected override void OnModelCreating (ModelBuilder modelbuilder) {
            base.OnModelCreating(modelbuilder);
        }
    }
}