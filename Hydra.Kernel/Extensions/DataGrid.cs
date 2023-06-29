using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Kernel.Extensions
{
    public class DataGrid
    {
        public int Start { get; set; }
        public int Size { get; set; }
        public string Filters { get; set; }
        public string GlobalFilter { get; set; }
        public string Sorting { get; set; }
    }
}
