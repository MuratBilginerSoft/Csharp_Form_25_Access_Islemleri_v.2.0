using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

namespace Veri_Tabanı_İşlemleri
{
    public partial class Form1 : Form
    {
        string yol1 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Personel.accdb";

        OleDbConnection bağlantı;
        OleDbCommand komut1;
        OleDbDataAdapter kayıt;
        DataTable tablo;

        public void veritabanınabağlan()
        {
            try
            {
               bağlantı = new OleDbConnection(yol1);
               
            }
            catch (OleDbException ex)
            {

                MessageBox.Show(" "+ex);
            }
           
          
        }


        public void verial()

        {
            string sorgu = "Select * from PersonelBilgileri";


            bağlantı.Open();

            komut1 = new OleDbCommand(sorgu,bağlantı);
            kayıt = new OleDbDataAdapter(komut1);
            tablo = new DataTable();
            
            kayıt.Fill(tablo);
            
            bağlantı.Close();
        
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            veritabanınabağlan();
            verial();

            int x = int.Parse(textBox1.Text);

            label6.Text = tablo.Rows[x]["tc_kimlik"].ToString();
            label7.Text = tablo.Rows[x]["personel_no"].ToString();
            label8.Text = tablo.Rows[x]["ad"].ToString();
            label9.Text = tablo.Rows[x]["soyad"].ToString();
            
        }
    }
}
