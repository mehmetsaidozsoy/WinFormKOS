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
    public partial class FormKitapEkle : Form
    {
        public FormKitapEkle()
        {
            InitializeComponent();
        }

        int kitapId = 0;

        private void FormKitapEkle_Load(object sender, EventArgs e)
        {
            comboBoxFill();
            kitaplarLoad();
        }

        void comboBoxFill()
        {
            foreach (DataRow row in IDataBase.DataToDataTable("select * from dolaplar").Rows)
                cbbDolap.Items.Add(row["adi"].ToString());

            foreach (DataRow row in IDataBase.DataToDataTable("select * from turler").Rows)
                cbbTur.Items.Add(row["adi"].ToString());

            foreach (DataRow row in IDataBase.DataToDataTable("select * from yayinevleri").Rows)
                cbbYayinevi.Items.Add(row["adi"].ToString());

            foreach (DataRow row in IDataBase.DataToDataTable("select * from yazarlar").Rows)
                cbbYazarAdi.Items.Add(row["adi"].ToString());

        }

        void kitaplarLoad()
        {
            dg.DataSource = IDataBase.DataToDataTable(
                "select * from kitaplar where aktif = 1 and yazarAdi+' '+kitapAdi like @search",
                    new SqlParameter("@search", SqlDbType.VarChar) { Value = string.Format("%{0}%", txtFiltrele.Text) });

            dg.Columns["id"].Visible = false;
        }

        int getKayitNo()
        {
            foreach (DataRow row in IDataBase.DataToDataTable("select ISNULL(MAX(kayitNo), 0) + 1 from kitaplar where aktif = 1").Rows)
            {
                return Convert.ToInt32(row[0]);
            }
            return 1;
        }

        void kitapEkle()
        {
            int kayitNo = getKayitNo();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@kayitNo", SqlDbType.Int) { Value = kayitNo });
            parameters.Add(new SqlParameter("@kitapAdi", SqlDbType.VarChar) { Value = txtKitapAdi.Text });
            parameters.Add(new SqlParameter("@yazarAdi", SqlDbType.VarChar) { Value = cbbYazarAdi.Text });
            parameters.Add(new SqlParameter("@yayinevi", SqlDbType.VarChar) { Value = cbbYayinevi.Text });
            parameters.Add(new SqlParameter("@basimYili", SqlDbType.VarChar) { Value = txtBasimYil.Text });
            parameters.Add(new SqlParameter("@sayfaSayisi", SqlDbType.VarChar) { Value = txtSayfaSayisi.Text });
            parameters.Add(new SqlParameter("@tur", SqlDbType.VarChar) { Value = cbbTur.Text });
            parameters.Add(new SqlParameter("@aciklama", SqlDbType.VarChar) { Value = txtAciklama.Text });
            parameters.Add(new SqlParameter("@dolap", SqlDbType.VarChar) { Value = cbbDolap.Text });
            parameters.Add(new SqlParameter("@raf", SqlDbType.VarChar) { Value = txtRaf.Text });
            parameters.Add(new SqlParameter("@sira", SqlDbType.VarChar) { Value = txtSira.Text });

            IDataBase.executeNonQuery("insert into kitaplar (kayitNo, kitapAdi, yazarAdi, yayinevi, basimYili, sayfaSayisi, tur, aciklama, dolap, raf, sira) values (@kayitNo, @kitapAdi, @yazarAdi, @yayinevi, @basimYili, @sayfaSayisi, @tur, @aciklama, @dolap, @raf, @sira)", parameters);

            txtKayitNo.Text = kayitNo.ToString();
            kitaplarLoad();

            MessageBox.Show("Kitap ekleme işlemi başarılı");
        }


        void kitapGuncelle()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@kitapAdi", SqlDbType.VarChar) { Value = txtKitapAdi.Text });
            parameters.Add(new SqlParameter("@yazarAdi", SqlDbType.VarChar) { Value = cbbYazarAdi.Text });
            parameters.Add(new SqlParameter("@yayinevi", SqlDbType.VarChar) { Value = cbbYayinevi.Text });
            parameters.Add(new SqlParameter("@basimYili", SqlDbType.VarChar) { Value = txtBasimYil.Text });
            parameters.Add(new SqlParameter("@sayfaSayisi", SqlDbType.VarChar) { Value = txtSayfaSayisi.Text });
            parameters.Add(new SqlParameter("@tur", SqlDbType.VarChar) { Value = cbbTur.Text });
            parameters.Add(new SqlParameter("@aciklama", SqlDbType.VarChar) { Value = txtAciklama.Text });
            parameters.Add(new SqlParameter("@dolap", SqlDbType.VarChar) { Value = cbbDolap.Text });
            parameters.Add(new SqlParameter("@raf", SqlDbType.VarChar) { Value = txtRaf.Text });
            parameters.Add(new SqlParameter("@sira", SqlDbType.VarChar) { Value = txtSira.Text });
            parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = kitapId });

            IDataBase.executeNonQuery("update kitaplar set kitapAdi = @kitapAdi, yazarAdi = @yazarAdi, basimYili = @basimYili, sayfaSayisi = @sayfaSayisi, tur = @tur, aciklama = @aciklama, dolap = @dolap, raf = @raf, sira = @sira where id = @id", parameters);

            kitaplarLoad();

            MessageBox.Show("Kitap güncelleme işlemi başarılı");

        }

        void kitapSil()
        {
            IDataBase.executeNonQuery("update kitaplar set aktif = 0 where id = @id", new SqlParameter("@id", SqlDbType.Int) { Value = kitapId });
            kitaplarLoad();

            MessageBox.Show("Kitap silme işlemi başarılı");
        }


        void temizle()
        {
            kitapId = 0;

            foreach (var item in tableLayoutPanel.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }

                if (item is ComboBox)
                {
                    ((ComboBox)item).Text = "";
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKitapAdi.Text) ||
                string.IsNullOrEmpty(cbbYazarAdi.Text) ||
                string.IsNullOrEmpty(cbbTur.Text))
            {
                MessageBox.Show("Kitap Adı, Yazar Adı ve Kitap Türü alanları boş geçilemez");
                return;
            }

            if (kitapId > 0)
            {
                kitapGuncelle();
            }
            else
            {
                kitapEkle();
            }
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                kitapId = Convert.ToInt32(dg.Rows[e.RowIndex].Cells["id"].Value);

                foreach (DataRow row in IDataBase.DataToDataTable("select * from kitaplar where aktif = 1 and id = @id", new SqlParameter("@id", SqlDbType.Int) { Value = kitapId }).Rows)
                {
                    txtKayitNo.Text = row["kayitNo"].ToString();
                    txtKitapAdi.Text = row["kitapAdi"].ToString();
                    cbbYazarAdi.Text = row["yazarAdi"].ToString();
                    cbbYayinevi.Text = row["yayinevi"].ToString();
                    txtBasimYil.Text = row["basimYili"].ToString();
                    txtSayfaSayisi.Text = row["sayfaSayisi"].ToString();
                    cbbTur.Text = row["tur"].ToString();
                    txtAciklama.Text = row["aciklama"].ToString();
                    cbbDolap.Text = row["dolap"].ToString();
                    txtRaf.Text = row["raf"].ToString();
                    txtSira.Text = row["sira"].ToString();
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (kitapId > 0)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Seçili kitabı silmek istediğinize emin misiniz?", "Kitap Sil", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    kitapSil();
                    temizle();
                }
                else
                {
                    MessageBox.Show("İşlem İptal Edildi!");
                }
            }
            else
            {
                MessageBox.Show("Kitap Seçiniz!");
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void txtFiltrele_TextChanged(object sender, EventArgs e)
        {
            kitaplarLoad();
        }
    }
}
