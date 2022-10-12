using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Security.Cryptography;

namespace clothes_store
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        public NpgsqlConnection ConnectToDatabase => new NpgsqlConnection("Server=localhost;Port=7777;DataBase=clothes;User Id=postgres;Password=0000");

        public string EncodeString(string originalString)
        {
            String codedstring = "";

            string hash = "f0xle@rn";

            byte[] data = UTF8Encoding.UTF8.GetBytes(originalString);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    codedstring = Convert.ToBase64String(results, 0, results.Length);
                }
            }

            return codedstring;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitialisationForm init = new InitialisationForm();
            init.Show();
            this.Hide();
        }



      

      

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string data_format;
            string dt1;
            string dt2;
            data_format = dateTimePicker1.Value.ToString();

            data_format = data_format.Remove(0, 3);
           data_format = data_format.Remove(7);
            dt1 = data_format.Remove(3);
            dt2 = data_format.Remove(0, 5);

            
            end_date_textBox.Text = dt1+dt2;
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {

            InitialisationForm init = new InitialisationForm();
            init.Show();
            this.Hide();
        }

        private void registration_button_Click(object sender, EventArgs e)
        {

            if (name_textBox.Text == "" || surname_textBox.Text == "" || login_textBox.Text == "" || password_textBox.Text == "" || email_textBox.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Введены не все данные для создания новой записи!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NpgsqlConnection conn = ConnectToDatabase;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;

                comm.CommandText = $"INSERT INTO public.customers" +
                    $"(name,surname,user_login,user_password,user_mail,credit_card_id)" +
                    $"VALUES ('{name_textBox.Text}', '{surname_textBox.Text}','{login_textBox.Text}','{password_textBox.Text}','{email_textBox.Text}',{textBox6.Text}); ";
                NpgsqlDataReader rdr = comm.ExecuteReader();

                comm.Dispose();
                conn.Dispose();
                conn.Close();
            }
        }

        private void add_card_button_Click(object sender, EventArgs e)
        {
            if (owner_textBox.Text == "" || the_code_textBox.Text == "" || cvv_textBox.Text == "" || end_date_textBox.Text == "")
            {
                MessageBox.Show("Введены не все данные для создания новой записи!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NpgsqlConnection conn = ConnectToDatabase;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;

                string the_code_codestring = EncodeString(the_code_textBox.Text);
                string svv_code_string = EncodeString(cvv_textBox.Text);

                comm.CommandText = $"INSERT INTO public.credit_card" +
                    $"(customer,card_code,cart_cvv,cart_end_date)" +
                    $"VALUES ('{owner_textBox.Text}', '{the_code_codestring}','{svv_code_string }','{end_date_textBox.Text}'); ";
                NpgsqlDataReader rdr = comm.ExecuteReader();

                comm.Dispose();
                conn.Dispose();
                conn.Close();


                NpgsqlConnection conn1 = ConnectToDatabase;
                conn1.Open();
                NpgsqlCommand comm1 = new NpgsqlCommand();
                comm1.Connection = conn1;
                comm1.CommandType = CommandType.Text;

                comm1.CommandText = $"SELECT max(id) FROM credit_card";


                NpgsqlDataReader rdr1 = comm1.ExecuteReader();

                // textBox6.Text = (int.Parse(rdr1.GetString(0)) + 1).ToString();

                while (rdr1.Read())//для получения определенных значений по выбранному айдишнику
                {
                    string card_id = rdr1.GetInt32(0).ToString();
                    textBox6.Text = card_id;
                }


                comm1.Dispose();
                conn1.Dispose();
                conn1.Close();
            }
        }
    }
}
