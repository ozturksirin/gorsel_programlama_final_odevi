﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ogrenci_kayıt_sistemi
{
    public partial class FrmMesajlar : Form
    {
        public FrmMesajlar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void GelenMesajlar()
        {
            SqlCommand komut = new SqlCommand("Select * From TblMesajlar where  alıcı=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void GidenMesajlar()
        {
            SqlCommand komut = new SqlCommand("Select * From TblMesajlar where Gonderen=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt); //hata var 
            dataGridView2.DataSource = dt;
        }

        public string numara;
        private void FrmMesajlar_Load(object sender, EventArgs e)
        {
            MskGonderen.Text = numara;
            GelenMesajlar();
            GidenMesajlar();

        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TblMesajlar (Gonderen,Alıcı,Baslı,Icerık)values (@p1,@p2,@p3,@p4)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskGonderen.Text);
            komut.Parameters.AddWithValue("@p2", MskAlıcı.Text);
            komut.Parameters.AddWithValue("@p3", TxtKonu.Text);
            komut.Parameters.AddWithValue("@p4", RchMesaj.Text);
            komut.ExecuteNonQuery(); //hata var executeNonQuery YAzan heryerde hata var

            MessageBox.Show("Mesajınız İletildi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bgl.baglanti().Close();
            GelenMesajlar();
            GidenMesajlar();    


        }
    }
}
