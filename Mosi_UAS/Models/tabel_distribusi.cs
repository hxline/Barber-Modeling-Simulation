using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosi_UAS.Models
{
    class tabel_distribusi
    {
        private string _waktu;
        private int _frekuensi = 0;

        public tabel_distribusi(string waktu, int frekuensi)
        {
            _waktu = waktu;
            _frekuensi = frekuensi;
        }

        public string Waktu
        {
            get { return _waktu; }
        }

        public int Frekuensi
        {
            get { return _frekuensi; }
        }
    }
}
