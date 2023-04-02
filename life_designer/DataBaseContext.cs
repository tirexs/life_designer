using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace life_designer
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
        }



        public DbSet<Category> Categorys { get; set; }
        public DbSet<Data> datas { get; set; }

    }
}
