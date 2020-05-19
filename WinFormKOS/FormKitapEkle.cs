﻿using System;
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
            dg.DataSource = IDataBase.DataToDataTable("select * from kitaplar where aktif=1");
        }

        void kitapEkle()
        {
            List<SqlParameter> parameters =new List<SqlParameter>();
            parameters.Add(new SqlParameter("@kayitNo",SqlDbType.Int){Value=txtKayitNo.Text});
            parameters.Add(new SqlParameter("@kitapAdi", SqlDbType.VarChar) { Value = txtKitapAdi.Text });
            parameters.Add(new SqlParameter("@yazarAdi", SqlDbType.VarChar) { Value = cbbYazarAdi.Text });
            parameters.Add(new SqlParameter("@yayinevi", SqlDbType.VarChar) { Value = cbbYayinevi.Text });
            parameters.Add(new SqlParameter("@basimYili", SqlDbType.VarChar) { Value = txtBasimYil.Text });
            parameters.Add(new SqlParameter("@sayfaSayisi", SqlDbType.VarChar) { Value = txtSayfaSayisi.Text });
            parameters.Add(new SqlParameter("@tur", SqlDbType.VarChar) { Value = cbbTur.Text });
            parameters.Add(new SqlParameter("@aciklama", SqlDbType.VarChar) { Value = txtAciklama.Text });
            parameters.Add(new SqlParameter("@dolap", SqlDbType.VarChar) { Value = cbbDolap.Text });
            parameters.Add(new SqlParameter("@raf", SqlDbType.VarChar) { Value = txtRaf.Text });
            parameters.Add(new SqlParameter("@sira", SqlDbType.VarChar) { Value = txtSira.Text});

            IDataBase.executeNonQuery("insert into kitaplar(kayitNo,kitapAdi,yazarAdi,yayinevi,basimYili,sayfaSayisi,tur,aciklama,dolap,raf,sira) values (@kayitNo,@kitapAdi,@yazarAdi,@yayinevi,@basimYili,@sayfaSayisi,@tur,@aciklama,@dolap,@raf,@sira)", parameters);
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            kitapEkle();
            kitaplarLoad();
        }
    }
}
