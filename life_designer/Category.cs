using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace life_designer
{
    [Table("Category")]
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Data> Datas { get; set;}

    }
}
