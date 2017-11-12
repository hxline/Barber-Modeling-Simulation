using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosi_UAS.Controllers
{
    class rvg_controller
    {
        strFormat format = new strFormat();

        public double eksponensial(double u)
        {
            return format.str((-18.77 * (Math.Log(u))) * 60);
        }

        public double uniform(double u)
        {
            return format.str((10 + ((20-10)* u)) * 60);
        }
    }
}
