using System.ComponentModel.DataAnnotations.Schema;

namespace life_designer.Model
{
    [Table("Data")]
    public class Data
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("IdCategory")]
        public int IdCategory { get; set; }
        [Column("Text")]
        public string Text { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Category Category { get; set; }

    }
}
