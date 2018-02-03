using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace hastakayit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       SqlConnection baglanti = new SqlConnection("server=AHMETVOLKANDURG\\SQLEXPRESS; Initial Catalog=hastakayitp;Integrated Security=True");
       /* class metotlistele 
        {           
            public void listele()
            {
                SqlConnection baglanti = new SqlConnection("server=AHMETVOLKANDURG\\SQLEXPRESS; Initial Catalog=hastakayitp;Integrated Security=True");
                baglanti.Open();
                string select = "select * from hasta";
                SqlDataAdapter da = new SqlDataAdapter(select, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
        }*/
        public void button1_Click(object sender, EventArgs e)//listele - lists
        {
            baglanti.Open();
            string select = "select * from hasta";
            SqlDataAdapter da = new SqlDataAdapter(select,baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        public void button4_Click(object sender, EventArgs e)//ekle - add
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO hasta (h_ad,h_soyad,h_cins,h_dtarih,h_ktarih,h_bolum) VALUES (@h_adi,@h_soyadi,@h_cinsi,@h_dtarihi,@h_ktarihi,@h_bolumu)",baglanti);
            komut.Parameters.AddWithValue("@h_adi", textBox1.Text);
            komut.Parameters.AddWithValue("@h_soyadi", textBox2.Text);
            komut.Parameters.AddWithValue("@h_cinsi", comboBox2.Text);
            komut.Parameters.AddWithValue("@h_dtarihi", textBox3.Text);
            komut.Parameters.AddWithValue("@h_ktarihi", textBox4.Text);
            komut.Parameters.AddWithValue("@h_bolumu", comboBox1.Text);
            komut.ExecuteNonQuery();            
            string select = "select * from hasta";
            SqlDataAdapter da = new SqlDataAdapter(select, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;            
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }
        private void button2_Click(object sender, EventArgs e)//güncelle - update
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update hasta set h_ad='" + textBox1.Text + "',h_soyad='" + textBox2.Text + "',h_cins='" + comboBox2.Text + "',h_dtarih='" + textBox3.Text + "',h_ktarih='" + textBox4.Text + "',h_bolum='" + comboBox1.Text + "' where h_id='" + textBox5.Text+"'", baglanti);
            komut.ExecuteNonQuery();
            string select = "select * from hasta";
            SqlDataAdapter da = new SqlDataAdapter(select, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void button3_Click(object sender, EventArgs e)//kaldır - remove
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from hasta where h_id=@h_idi", baglanti);
            komut.Parameters.AddWithValue("@h_idi", textBox5.Text);
            komut.ExecuteNonQuery();
            string select = "select * from hasta";
            SqlDataAdapter da = new SqlDataAdapter(select, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            textBox5.Clear();
        }
       private void button5_Click(object sender, EventArgs e)//ara - search
        {
             baglanti.Open();
             SqlCommand komut = new SqlCommand("select * from hasta where h_ad like '%" + textBox6.Text + "%'"+"and h_soyad like '%" + textBox7.Text + "%'", baglanti);
             SqlDataAdapter da = new SqlDataAdapter(komut);
             DataSet ds = new DataSet();
             da.Fill(ds);
             dataGridView1.DataSource = ds.Tables[0];
             baglanti.Close();
            textBox6.Clear();
            textBox7.Clear();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string h_id = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string h_ad = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string h_soyad = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string h_cins = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string h_dtarih = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string h_ktarih = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string h_bolum = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();

            textBox5.Text = h_id;
            textBox1.Text = h_ad;
            textBox2.Text = h_soyad;
            comboBox2.Text = h_cins;
            textBox3.Text = h_dtarih;
            textBox4.Text = h_ktarih;
            comboBox1.Text = h_bolum;
        }
    }
}
