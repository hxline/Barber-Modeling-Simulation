using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosi_UAS.Controllers
{
    class strFormat
    {
        public double str(double nilai)
        {
            return double.Parse(String.Format("{0:0.000}", nilai));
        }
    }
}
