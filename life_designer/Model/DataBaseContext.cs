using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace life_designer.Model
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
        }



        public DbSet<Category> Categorys { get; set; }
        public DbSet<Data> datas { get; set; }
        public DbSet<UserLogin> userLogins { get; set; }

        

    }
}
