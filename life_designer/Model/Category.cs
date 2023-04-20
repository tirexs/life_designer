using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace life_designer.Model
{
    [Table("Category")]
    public class Category
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        public virtual ICollection<Data> Datas { get; set;}

    }
}
