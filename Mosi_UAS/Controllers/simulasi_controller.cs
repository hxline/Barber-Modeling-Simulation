using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosi_UAS.Controllers
{
    class simulasi_controller
    {
        strFormat format = new strFormat();

        //FUNGSI
        //Kumulatif Kedatangan
        public double a(double x, double a)
        {
            return format.str(x + a);
        }

        //Waktu pelanggan menunggu cuci rambut
        public double b(double d, double a)
        {
            return format.str(d - a);
        }

        //Waktu Selesai Cuci
        public double d(double a, double b, double c)
        {
            return format.str(a + b + c);
        }

        //Waktu pelanggan tunggu potong rambut
        public double e(double f, double d)
        {
            return format.str(f - d);
        }

        //Waktu selesai potong
        public double f(double d, double y)
        {
            return format.str(d + y);
        }

        //Waktu menganggur tukang potong
        public double g(double d, double f)
        {
            return format.str(d - f);
        }
    }
}
