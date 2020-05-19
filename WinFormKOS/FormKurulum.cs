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
    public partial class FormKurulum : Form
    {
        public FormKurulum()
        {
            InitializeComponent();
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAd.Text)|| 
                string.IsNullOrEmpty(txtSoyad.Text)|| 
                string.IsNullOrEmpty(txtKullaniciAdi.Text)|| 
                string.IsNullOrEmpty(txtSifre.Text)|| 
                string.IsNullOrEmpty(txtSoyad.Text))
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!");
                return;
            }

            if (txtSifre.Text!=txtSifreTekrar.Text)
            {
                MessageBox.Show("Şifre Tekrarı Uyuşmuyor !");
                return;
                ;
            }

            List<SqlParameter> parameters=new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TCKimlikNo",SqlDbType.Char){Value = txtTCKimlikNo.Text});
            parameters.Add(new SqlParameter("@adi", SqlDbType.VarChar) { Value = txtAd.Text });
            parameters.Add(new SqlParameter("@soyadi", SqlDbType.VarChar) { Value = txtSoyad.Text });
            parameters.Add(new SqlParameter("@KullaniciAdi", SqlDbType.VarChar) { Value = txtKullaniciAdi.Text });
            parameters.Add(new SqlParameter("@sifre", SqlDbType.VarChar) { Value = txtSifre.Text });
            IDataBase.executeNonQuery("insert into kullanicilar (TCKimlikNo,adi,soyadi,kullaniciAdi,sifre) values (@TCKimlikNo,@adi,@soyadi,@kullaniciAdi,@sifre) ", parameters);

            FormLogin formLogin=new FormLogin();
            formLogin.Show();
            this.Hide();
        }
    }
}
