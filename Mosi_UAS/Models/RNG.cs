using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosi_UAS.Models
{
    class RNG
    {
        private int _i = 0;
        private int _z = 0;
        private int _zi = 0;
        private double _ui = 0;

        public RNG(int i, int z, int zi, double ui)
        {
            _i = i;
            _z = z;
            _zi = zi;
            _ui = ui;
        }

        public int i
        {
            get { return _i; }
        }
        public int z
        {
            get { return _z; }
        }
        public int zi
        {
            get { return _zi; }
        }
        public string ui
        {
            get { return String.Format("{0:0.000}",_ui); }
        }
    }
}
