using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Robots_Helper_2._0
{
    public class SavePoint
    {
        public string title {  get; set; } = string.Empty;
        public Vector3 position { get; set; }
        public float rotation { get; set; }
    }
}
