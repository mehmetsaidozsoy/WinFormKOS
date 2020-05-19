using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormKOS.Model;

namespace WinFormKOS
{
    public partial class FormIstatistik : Form
    {
        public FormIstatistik()
        {
            InitializeComponent();
        }

        private void FormIstatistik_Load(object sender, EventArgs e)
        {

        }

        void istatistikGor()
        {
            string query = "";
            switch (cbbIstatistik.SelectedIndex)
            {
                case 0:
                    query = "select adi+' '+soyadi as X, COUNT(*) as Y  from emanetler inner join okuyucular on okuyucular.id = emanetler.okuyucuId where okuyucular.aktif = 1 and emanetler.aktif = 1 group by adi+' '+soyadi";
                    break;

                case 1:
                    query = "select kitapAdi as X, COUNT(*) as Y from emanetler inner join kitaplar on kitaplar.id = emanetler.kitapId group by kitapAdi";
                    break;

                case 2:
                    query = "select yazarAdi as X, COUNT(*) as Y from emanetler inner join kitaplar on kitaplar.id = emanetler.kitapId group by yazarAdi";
                    break;

                case 3:
                    query = "select tur as X, COUNT(*) as Y from emanetler inner join kitaplar on kitaplar.id = emanetler.kitapId group by tur";
                    break;

                default:
                    break;
            }

            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }

            foreach (DataRow row in IDataBase.DataToDataTable(query).Rows)
            {
                chart.Series["Durum"].Points.AddXY(row["X"].ToString(), row["Y"].ToString());
            }
        }

        private void cbbIstatistik_SelectedIndexChanged(object sender, EventArgs e)
        {
            istatistikGor();
        }
    }
}
