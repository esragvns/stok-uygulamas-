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

namespace GorselStok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection komut = new SqlConnection("Data Source=DESKTOP-J75DSQI\\SQLEXPRESS;Initial Catalog=GorselProgStok;Integrated Security=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            string t3 = textBox3.Text;
            string t4 = textBox4.Text;
            string t5 = textBox5.Text;
            string t6 = textBox6.Text;

            komut.Open();
            SqlCommand kom = new SqlCommand("INSERT INTO MALZEMELER(MalzemeKodu, MalzemeAdi, YilikSatis, BirimFiyat,MinStok, TSuresi) VALUES ('"+t1+ "' ,'" + t2 + "' , '" + t3 + "', '" + t4 + "', '" + t5 + "', '" + t6 + "') ", komut);
            kom.ExecuteNonQuery();
            komut.Close();
            listele();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()
        {
            komut.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Malzemeler",komut);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            komut.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text;
            komut.Open();
            SqlCommand kom = new SqlCommand("DELETE FROM MALZEMELER WHERE MalzemeKodu=('"+t1+"')",komut);  
            kom.ExecuteNonQuery();
            komut.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            string t3 = textBox3.Text;
            string t4 = textBox4.Text;
            string t5 = textBox5.Text;
            string t6 = textBox6.Text;

            komut.Open();
            SqlCommand kom = new SqlCommand("UPDATE MALZEMELER SET MalzemeKodu='"+t1+ "', MalzemeAdi='" + t2 + "', YilikSatis='" + t3 + "', BirimFiyat='" + t4 + "', MinStok='" + t5 + "', TSuresi='" + t6 + "' WHERE MalzemeKodu='" + t1 + "' ", komut);
            kom.ExecuteNonQuery();
            komut.Close();
            listele();

        }
    }
}
