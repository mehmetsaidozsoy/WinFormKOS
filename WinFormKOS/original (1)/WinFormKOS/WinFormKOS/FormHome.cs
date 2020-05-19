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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        void dataGridViewLoad()
        {
            dgEmanetler.DataSource = IDataBase.DataToDataTable("select kayitNo as [Kayıt No], kitapAdi as [Kitap Adı], yazarAdi as [Yazar Adı], yayinevi as [Yayınevi], basimYili as [Basım Yılı], sayfaSayisi as [Sayfa Sayısı], tur as [Tür] from kitaplar where aktif = 1 and durum = 0");
            dgMevcutKitaplar.DataSource = IDataBase.DataToDataTable("select kayitNo as [Kayıt No], kitapAdi as [Kitap Adı], yazarAdi as [Yazar Adı], yayinevi as [Yayınevi], basimYili as [Basım Yılı], sayfaSayisi as [Sayfa Sayısı], tur as [Tür] from kitaplar where aktif = 1 and durum = 1");
            dgOkuyucular.DataSource = IDataBase.DataToDataTable("select adi as [Adı], soyadi as [Soyadı], cinsiyeti as [Cinsiyeti], sinifi as [Sınıfı], okulNo as [Okul No], cepTel as [Cep Telefonu], adres as [Adres]  from okuyucular where aktif = 1");
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            FormKitapEkle formKitapEkle = new FormKitapEkle();
            formKitapEkle.Show();
        }

        private void btnOkuyucuEkle_Click(object sender, EventArgs e)
        {
            FormOkuyucuEkle formOkuyucuEkle = new FormOkuyucuEkle();
            formOkuyucuEkle.Show();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit();
            formEdit.Show();
        }

        private void btnEmanetIslem_Click(object sender, EventArgs e)
        {
            FormEmanet formEmanet = new FormEmanet();
            formEmanet.Show();
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            FormIstatistik formIstatistik = new FormIstatistik();
            formIstatistik.Show();
        }

        private void FormHome_Activated(object sender, EventArgs e)
        {
            dataGridViewLoad();
        }
    }
}
