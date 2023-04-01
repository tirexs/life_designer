using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace life_designer
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext() : base("DataBaseConnectionString")
        {
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Data> datas { get; set; }

    }
}
