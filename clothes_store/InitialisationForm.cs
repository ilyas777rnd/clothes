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

namespace clothes_store
{
    public partial class InitialisationForm : Form
    {
        public InitialisationForm()
        {
            InitializeComponent();
            this.login_textBox.Text = "nikitanechaev";
            this.password_textBox.Text = "1337228";
        }

        public NpgsqlConnection ConnectToDatabase => new NpgsqlConnection("Server=localhost;Port=7777;DataBase=clothes;User Id=postgres;Password=0000");

      

        

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn1 = ConnectToDatabase;
            conn1.Open();


            NpgsqlCommand comm1 = new NpgsqlCommand();
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.Text;

            comm1.CommandText = $"SELECT id FROM customers WHERE user_login='{login_textBox.Text}' AND user_password='{password_textBox.Text}'";
            NpgsqlDataReader rdr1 = comm1.ExecuteReader();

            comm1.Dispose();

            if (rdr1.HasRows)
            {
                CustomerForm CusF = new CustomerForm();
                CusF.Show();
                rdr1.Read();
                CusF.custumer_id = rdr1.GetInt32(0).ToString();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Логин или пароль НЕ верны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            conn1.Dispose();
            conn1.Close();
        }

      

        private void exit_app_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void enter_admin_without_password_button_Click(object sender, EventArgs e)
        {

            if (login_textBox.Text == "admin" && password_textBox.Text == "7777")
            {
                AdminForm AdF = new AdminForm();
                AdF.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Логин или пароль НЕ верны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void InitialisationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void worker_enter_button_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn1 = ConnectToDatabase;
            conn1.Open();


            NpgsqlCommand comm1 = new NpgsqlCommand();
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.Text;

            comm1.CommandText = $"SELECT * FROM stuff WHERE login='{login_textBox.Text}' AND password='{password_textBox.Text}'";
            NpgsqlDataReader rdr1 = comm1.ExecuteReader();

            comm1.Dispose();

            if (rdr1.HasRows)
            {
                rdr1.Read();

                if (rdr1.GetString(6) == "worker")
                {
                    WorkerForm WF = new WorkerForm();
                    WF.Show();
                    this.Hide();
                }
                else
                {
                    AdminForm AdF = new AdminForm();
                    AdF.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Логин или пароль НЕ верны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            conn1.Dispose();
            conn1.Close();
        }

        private void customer_button_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn1 = ConnectToDatabase;
            conn1.Open();


            NpgsqlCommand comm1 = new NpgsqlCommand();
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.Text;

            comm1.CommandText = $"SELECT id FROM customers WHERE user_login='{login_textBox.Text}' AND user_password='{password_textBox.Text}'";
            NpgsqlDataReader rdr1 = comm1.ExecuteReader();

            comm1.Dispose();

            if (rdr1.HasRows)
            {
                CustomerForm CusF = new CustomerForm();
                CusF.Show();
                rdr1.Read();
                CusF.custumer_id = rdr1.GetInt32(0).ToString();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Логин или пароль НЕ верны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            conn1.Dispose();
            conn1.Close();
        }
    }
}
