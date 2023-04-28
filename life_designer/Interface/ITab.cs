using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace life_designer.Interface
{
    public interface ITab
    {
        string Name { get; set; }
        List<string> Content { get; set; }
    }

    public abstract class Tab : ITab
    {
        public string Name { get; set; }
        public List<string> Content { get; set; }

    }

}
