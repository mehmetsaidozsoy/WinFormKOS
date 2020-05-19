using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormKOS.Model;

namespace WinFormKOS
{
    public partial class FormEmanet : Form
    {
        public FormEmanet()
        {
            InitializeComponent();
        }

        int okuyucuId = 0;
        int kitapId = 0;
        int cezaTL = 0;

        private void FormEmanet_Load(object sender, EventArgs e)
        {
            okuyucularLoad();
            kitaplarLoad();
        }

        void getOkuyucuProfil()
        {
            pictureProfil.ImageLocation = Helper.profilPath(0);
            lblAdSoyad.Text = "";
            lblSinif.Text = "";
            lblOkulNo.Text = "";
            lblGecikmeBedeli.Text = "";
            cezaTL = 0;

            foreach (DataRow row in IDataBase.DataToDataTable("select * from okuyucular where aktif = 1 and id = @id", new SqlParameter("@id", SqlDbType.Int) { Value = okuyucuId }).Rows)
            {
                pictureProfil.ImageLocation = Helper.profilPath(okuyucuId);
                lblAdSoyad.Text = row["adi"].ToString() + " " + row["soyadi"].ToString();
                lblSinif.Text = row["sinifi"].ToString();
                lblOkulNo.Text = row["okulNo"].ToString();
                lblGecikmeBedeli.Text = "YOK";

                cezaTL = getGecikmeBedeli();
                if (cezaTL > 0)
                {
                    lblGecikmeBedeli.Text = "Gecikme Bedeli " + string.Format("{0:C}", cezaTL);
                    lblGecikmeBedeli.BackColor = Color.Red;
                }
                else
                {
                    lblGecikmeBedeli.Text = "Uygun";
                    lblGecikmeBedeli.BackColor = Color.Transparent;
                }
                kitapId = getEmanetId();
                getKitapProfil();
            }
        }

        void getKitapProfil()
        {
            lblKayitNo.Text = "";
            lblKitapAdi.Text = "";
            lblYazarAdi.Text = "";

            foreach (DataRow row in IDataBase.DataToDataTable("select * from kitaplar where aktif = 1 and id = @id", new SqlParameter("@id", SqlDbType.Int) { Value = kitapId }).Rows)
            {
                lblKayitNo.Text = row["kayitNo"].ToString();
                lblKitapAdi.Text = row["kitapAdi"].ToString();
                lblYazarAdi.Text = row["yazarAdi"].ToString();
            }
        }

        void okuyucularLoad()
        {
            dgOkuyucular.DataSource = IDataBase.DataToDataTable(
                "select * from okuyucular where aktif = 1 and adi+' '+soyadi like @search",
                    new SqlParameter("@search", SqlDbType.VarChar) { Value = string.Format("%{0}%", txtFiltreleOkuyucu.Text) });

        }

        void kitaplarLoad()
        {
            dgKitaplar.DataSource = IDataBase.DataToDataTable(
                "select * from kitaplar where aktif = 1 and durum = 1 and kitapAdi like @search",
                    new SqlParameter("@search", SqlDbType.VarChar) { Value = string.Format("%{0}%", txtFiltreleKitap.Text) });

        }

        void emanetEt()
        {
            if (kitapId == 0 || okuyucuId == 0)
            {
                MessageBox.Show("Kitap veya okuyucu seçmediniz!");
                return;
            }

            if (getEmanetId() > 0)
            {
                MessageBox.Show("Seçili okuyucunun emaneti var!");
                return;
            }


            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@kitapId", SqlDbType.Int) { Value = kitapId });
            parameters.Add(new SqlParameter("@okuyucuId", SqlDbType.Int) { Value = okuyucuId });
            parameters.Add(new SqlParameter("@emanetVerilisTarihi", SqlDbType.Date) { Value = DateTime.Now });
            parameters.Add(new SqlParameter("@emanetGeriAlmaTarihi", SqlDbType.Date) { Value = DateTime.Now.AddDays(30) });

            IDataBase.executeNonQuery(
                "update kitaplar set durum = 0 where id = @kitapId " +
                "insert into emanetler (kitapId, okuyucuId, emanetVerilisTarihi, emanetGeriAlmaTarihi) values (@kitapId, @okuyucuId, @emanetVerilisTarihi, @emanetGeriAlmaTarihi)", parameters);

            kitaplarLoad();
        }

        void sureUzat()
        {
            if (kitapId == 0 || okuyucuId == 0)
            {
                MessageBox.Show("Kitap veya okuyucu seçmediniz!");
                return;
            }

            if (getEmanetId() == 0)
            {
                MessageBox.Show("Seçili okuyucunun emaneti yok!");
                return;
            }


            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@kitapId", SqlDbType.Int) { Value = kitapId });
            parameters.Add(new SqlParameter("@emanetVerilisTarihi", SqlDbType.Date) { Value = DateTime.Now });
            parameters.Add(new SqlParameter("@emanetGeriAlmaTarihi", SqlDbType.Date) { Value = DateTime.Now.AddDays(30) });

            IDataBase.executeNonQuery("update emanetler set emanetVerilisTarihi = @emanetVerilisTarihi, emanetGeriAlmaTarihi = @emanetGeriAlmaTarihi where kitapId = @kitapId", parameters);

            getOkuyucuProfil();
            kitaplarLoad();
        }

        void dusumYap()
        {
            if (kitapId == 0 || okuyucuId == 0)
            {
                MessageBox.Show("Kitap veya okuyucu seçmediniz!");
                return;
            }

            if (getEmanetId() == 0)
            {
                MessageBox.Show("Seçili okuyucunun emaneti yok!");
                return;
            }


            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@kitapId", SqlDbType.Int) { Value = kitapId });
            parameters.Add(new SqlParameter("@emanetIslemTarihi", SqlDbType.Date) { Value = DateTime.Now });

            IDataBase.executeNonQuery(
                "update kitaplar set durum = 1 where id = @kitapId " +
                "update emanetler set emanetIslemTarihi = @emanetIslemTarihi, durum = 1 where kitapId = @kitapId", parameters);

            getOkuyucuProfil();
            kitaplarLoad();
        }

        int getGecikmeBedeli()
        {
            int cezaTL = 1;
            int gunFark = 0;
            foreach (DataRow row in IDataBase.DataToDataTable("select * from emanetler where okuyucuId = @id and durum = 0 and aktif = 1", new SqlParameter("@id", SqlDbType.Int) { Value = okuyucuId }).Rows)
            {
                TimeSpan timeSpan = DateTime.Now - Convert.ToDateTime(row["emanetGeriAlmaTarihi"]);
                gunFark = timeSpan.Days;
            }
            if (gunFark > 0)
            {
                return (gunFark * cezaTL);
            }
            return 0;
        }

        int getEmanetId()
        {
            foreach (DataRow row in IDataBase.DataToDataTable("select * from emanetler where okuyucuId = @id and durum = 0 and aktif = 1", new SqlParameter("@id", SqlDbType.Int) { Value = okuyucuId }).Rows)
            {
                return Convert.ToInt32(row["kitapId"]);
            }
            return 0;
        }

        private void txtFiltreleOkuyucu_TextChanged(object sender, EventArgs e)
        {
            okuyucularLoad();
        }

        private void txtFiltreleKitap_TextChanged(object sender, EventArgs e)
        {
            kitaplarLoad();
        }

        private void dgOkuyucular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                okuyucuId = Convert.ToInt32(dgOkuyucular.Rows[e.RowIndex].Cells["id"].Value);
                getOkuyucuProfil();
            }
        }

        private void dgKitaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                if (okuyucuId == 0)
                {
                    MessageBox.Show("Okuyucu seçiniz!");
                    return;
                }

                if (getEmanetId() > 0)
                {
                    MessageBox.Show("Okuyucunun emaneti var!");
                    return;
                }

                kitapId = Convert.ToInt32(dgKitaplar.Rows[e.RowIndex].Cells["id"].Value);
                getKitapProfil();
            }
        }

        private void btnEmanetEt_Click(object sender, EventArgs e)
        {
            emanetEt();
        }

        private void btnSureUzat_Click(object sender, EventArgs e)
        {
            if (cezaTL > 0)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Okuyucunun " + string.Format("{0:C}", cezaTL) + " gecikme bedeli teslim alındı mı?", "Gecikme Bedeli", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    sureUzat();
                }
            }
            else
            {
                sureUzat();
            }
        }

        private void btnDusumYap_Click(object sender, EventArgs e)
        {
            if (cezaTL > 0)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Okuyucunun " + string.Format("{0:C}", cezaTL) + " gecikme bedeli teslim alındı mı?", "Gecikme Bedeli", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dusumYap();
                }
            }
            else
            {
                dusumYap();
            }
        }
    }
}
