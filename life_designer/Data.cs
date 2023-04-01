using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace life_designer
{
    public class Data
    {

        public int Id { get; set; }
        public int IdCategory { get; set; }
        public string Text { get; set; }
        public virtual Category Category { get; set; }

    }
}
