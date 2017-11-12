using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosi_UAS.Controllers
{
    class rng_controller
    {
        public int zi(int a, int m, int z)
        {
            return ((a * z) % m);
        }

        public double ui(int z, int m)
        {
            return ((double)z / (double)m);
        }
    }
}
