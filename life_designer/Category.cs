using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace life_designer
{
    [Table("Category")]
    public class Category
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Data> Datas { get; set;}

    }
}
