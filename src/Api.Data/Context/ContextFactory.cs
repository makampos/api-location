using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<WorkContext>
    {
        public WorkContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=LocationDb;Uid=root;Pwd=root";
            var optionBuilder = new DbContextOptionsBuilder<WorkContext>();
            optionBuilder.UseMySql (connectionString);
            return new WorkContext(optionBuilder.Options);
        }
    }
}