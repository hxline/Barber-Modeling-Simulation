using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mosi_UAS.Models;
using Mosi_UAS.Controllers;

namespace Mosi_UAS
{
    public partial class Form1 : Form
    {
        double z;
        double x;
        double y;
        double a;
        double b;
        double c = 400;
        double d;
        double e;
        double f;
        double g;
        double aTemp;
        double dTemp;
        double fTemp;
        static BindingList<RNG> rng = new BindingList<RNG>();
        static BindingList<tabel_distribusi> ps = new BindingList<tabel_distribusi>();
        static BindingList<tabel_distribusi> pr= new BindingList<tabel_distribusi>();
        static BindingList<Simulasi> sm = new BindingList<Simulasi>();

        public Form1()
        {
            InitializeComponent();
            tabel_ps();
            tabel_pr();
            dataGridViewRNG.DataSource = rng;
            chartPS.DataSource = ps;
            chartPR.DataSource = pr;
            chartSimulasi.DataSource = sm;
            dataGridViewTPS.DataSource = ps;
            dataGridViewTPR.DataSource = pr;
            dataGridViewSimulasi.DataSource = sm;
        }

        #region RNG
        private void hitung(int a, int m, int z)
        {
            rng_controller rng_controller = new rng_controller();
            int n = int.Parse(textBoxJumlah.Text);
            int _zi;
            double _ui;
            int _z = rng_controller.zi(a, m, z);
            double _u = rng_controller.ui(_z, m);
            rng.Add(new RNG(1, z, _z, _u));

            for (int i = 2; i <= n; i++)
            {
                _zi = rng_controller.zi(a, m, _z);
                _ui = rng_controller.ui(_zi, m);

                if (cek(i, _ui))
                {
                    rng.Add(new RNG(i, _z, _zi, _ui));
                    _z = _zi;
                    rng.Clear();
                    MessageBox.Show("Terjadi bilangan acak berulang.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                }

                rng.Add(new RNG(i, _z, _zi, _ui));
                _z = _zi;
            }
        }

        private bool cek(int i, double ui)
        {
            int index_ui = 0;
            string cari_ui = String.Format("{0:0.000}", ui);
            index_ui = (from h in rng where h.ui == cari_ui select h.i).LastOrDefault();

            if (index_ui != 0)
            {
                //MessageBox.Show(index_ui.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region tabel distribusi
        //Pengunjung salon
        private void tabel_ps()
        {
            ps.Add(new tabel_distribusi("5-10",24));
            ps.Add(new tabel_distribusi("11-16", 19));
            ps.Add(new tabel_distribusi("17-22", 15));
            ps.Add(new tabel_distribusi("23-28", 15));
            ps.Add(new tabel_distribusi("29-34", 11));
            ps.Add(new tabel_distribusi("35-40", 5));
            ps.Add(new tabel_distribusi("41-46", 1));
        }

        //Pemotongan rambut
        private void tabel_pr()
        {
            pr.Add(new tabel_distribusi("10", 15));
            pr.Add(new tabel_distribusi("12", 14));
            pr.Add(new tabel_distribusi("14", 15));
            pr.Add(new tabel_distribusi("16", 15));
            pr.Add(new tabel_distribusi("18", 16));
            pr.Add(new tabel_distribusi("20", 15));
        }
        #endregion

        #region Simulasi
        public void generate_simulasi()
        {
            int i = 1;
            double hs = 0;
            rvg_controller rvg = new rvg_controller();
            simulasi_controller simulasi = new simulasi_controller();

            var list_rng = from table in rng select table.ui;
            foreach (var item in list_rng)
            {
                z = double.Parse(item);
                x = rvg.eksponensial(z);
                y = rvg.uniform(z);
                if (i == 1)
                {
                    a = x;
                    b = 0;
                    d = simulasi.d(a, b, c);
                    e = 0;
                    f = simulasi.f(d, y);
                    g = d;
                }
                else
                {
                    a = x + aTemp;
                    b = dTemp - a;
                    
                    if (b < 0)
                    {
                        b = 0;
                    }

                    d = simulasi.d(a, b, c);
                    e = fTemp - d;

                    if (e < 0)
                    {
                        e = 0;
                    }
                    f = simulasi.f(d, y);
                    g = d - fTemp;
                    if (g < 0)
                    {
                        g = 0;
                    }
                }

                aTemp = a;
                dTemp = d;
                fTemp = f;
                hs += g;
                sm.Add(new Simulasi(i,z,x,y,a,b,c,d,e,f,g));
                i++;
            }

            //MessageBox.Show(hs.ToString());
        }
        #endregion

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            rng.Clear();

            int a = int.Parse(textBoxA.Text);
            int m = int.Parse(textBoxM.Text);
            int z = int.Parse(textBoxZ.Text);

            hitung(a, m, z);
            dataGridViewRNG.DataSource = rng;
        }

        private void buttonSimulasi_Click(object sender, EventArgs e)
        {
            sm.Clear();
            generate_simulasi();
            dataGridViewSimulasi.DataSource = sm;
            chartSimulasi.DataSource = sm;
            chartSimulasi.DataBind();
        }
    }
}
