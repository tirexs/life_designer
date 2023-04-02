using System.ComponentModel.DataAnnotations.Schema;

namespace life_designer
{
    [Table("Data")]
    public class Data
    {

        public int Id { get; set; }
        public int IdCategory { get; set; }
        public string Text { get; set; }
        public virtual Category Category { get; set; }

    }
}
