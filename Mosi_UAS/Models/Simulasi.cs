using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mosi_UAS.Controllers;

namespace Mosi_UAS.Models
{
    class Simulasi
    {
        strFormat format = new strFormat();
        private int _i;
        //VARIABEL
        //Bilangan Acak
        private double _z;
        //Waktu Kedatangan Pelanggan
        private double _x;
        //Pemotongan rambut
        private double _y;
        //Kumulatif Kedatangan Pelanggan
        private double _a;
        //Waktu pelanggan menunggu cuci rambut
        private double _b;
        //Waktu Cuci rambut
        private double _c;
        //Waktu Selesai Cuci
        private double _d;
        //Waktu pelanggan tunggu potong rambut
        private double _e;
        //Waktu selesai potong
        private double _f;
        //Waktu menganggur tukang potong
        private double _g;
        
        public Simulasi(int i,double z, double x, double y, double a, double b, double c, double d, double e, double f, double g)
        {
            _i = i;
            _z = z;
            _x = x;
            _y = y;
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _e = e;
            _f = f;
            _g = g;
        }

        public int No
        {
            get { return _i; }
        }

        public double Bilangan_Acak
        {
            get { return format.str(_z); }
        }

        public double Kedatangan_Plg
        {
            get { return format.str(_x); }
        }

        public double Pemotongan_Rambut
        {
            get { return format.str(_y); }
        }

        public double Kumulatif_Plg_Datang
        {
            get { return format.str(_a); }
        }

        public double Plg_tg_Cuci_Rambut
        {
            get { return format.str(_b); }
        }

        public double Cuci_Rambut
        {
            get { return format.str(_c); }
        }

        public double Sls_Cuci_rambut
        {
            get { return format.str(_d); }
        }

        public double Plg_tg_Potong_rambut
        {
            get { return format.str(_e); }
        }
        public double Sls_Potong_Rambut
        {
            get { return format.str(_f); }
        }

        public double Petugas_potong_nganggur
        {
            get { return format.str(_g); }
        }
    }
}
