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

namespace giriş_sistemii
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        // SqlConnection baglanti= new SqlConnection("Data Source=46.45.178.125;Initial Catalog=aliemre_;Persist Security Info=True;User ID=aliemre_hsm;Password=Ali132004");
        //SqlConnection baglanti = new SqlConnection("Server=46.45.178.125;Database=qubeesof_db;Uid=qubeesof_un;Password=p9Di1Cf8F;");
        SqlConnection baglanti = new SqlConnection("Server=176.53.74.79;Database=birfikri_db;Uid=birfikri_un;Password=t5Af6Cm1C;");

        public static string uns;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("select un,pw from tb_users where un='" + textBox1.Text + "'and pw='" + textBox2.Text + "'", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    uns = textBox1.Text;
                    MessageBox.Show("Giriş Başarılı");
                    Form2 frm2 = new Form2();
                    frm2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Bulunamadı");
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
