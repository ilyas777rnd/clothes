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
using System.Diagnostics;

namespace clothes_store
{
    public partial class OtkatForm : Form
    {
        public OtkatForm()
        {
            InitializeComponent();
        }

        public NpgsqlConnection ConnectToDatabase => new NpgsqlConnection("Server=localhost;Port=7777;DataBase=clothes;User Id=postgres;Password=0000");

        private void show_okkat_tables_button_Click(object sender, EventArgs e)
        {


            if (otkat_tables_listBox.SelectedIndex.ToString() != null)
            {

                NpgsqlConnection conn = ConnectToDatabase;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;

                //if (otkat_tables_listBox.SelectedItem.ToString() == "booking_otkat")
                //{
                //    comm.CommandText =
                //    $" SELECT booking_otkat.id,customers.name,customers.surname,list_of_products.product_name, " +
                //    $"booking_otkat.adress_booking,booking_otkat.promo_code,booking_otkat.product_price,booking_otkat.sale,booking_otkat.end_price,booking_otkat.Edit,booking_otkat.Time_edit " +
                //    $"FROM customers  " +
                //    $"JOIN (list_of_products JOIN booking_otkat ON list_of_products.id = booking_otkat.list_of_products_id) ON  customers.id = booking_otkat.customers_id;";
                //}

                //if (otkat_tables_listBox.SelectedItem.ToString() == "list_of_products_otkat")
                //{
                //    comm.CommandText =
                // $"SELECT list_of_products_otkat.id,list_of_products_otkat.product_name, list_of_products_otkat.price, list_of_products_otkat.color,list_of_products_otkat.ammount,list_of_products.hand_type, list_of_products_otkat.Edit, list_of_products_otkat.Time_edit" +
                // $" size_sex.sex_size,size_sex.description," +
                // $" brands.name_of_brand" +
                // $" FROM brands " +
                // $"JOIN (size_sex JOIN list_of_products ON list_of_products.size_id = size_sex.id) ON  brands.id = list_of_products_otkat.brands_id;";

                //}
                //else
                {
                    comm.CommandText = $"SELECT * FROM {otkat_tables_listBox.SelectedItem.ToString()}";
                }


                NpgsqlDataReader rdr = comm.ExecuteReader();

                if (rdr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    otkat_dataGridView.DataSource = dt;
                }
                else
                {
                    otkat_tables_listBox.Show();
                    MessageBox.Show("Таблица пуста!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите таблицу, которую хотите отобразить!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void otkat_tables_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (otkat_tables_listBox.SelectedItem.ToString() == "stuff_otkat")
            {
                stuff_otkat_button.Enabled = true;
                products_otkat_button.Enabled = false;
                customers_otkat_button.Enabled = false;
                booking_otkat_button.Enabled = false;

            }

            if (otkat_tables_listBox.SelectedItem.ToString() == "list_of_products_otkat")
            {
                stuff_otkat_button.Enabled = false;
                products_otkat_button.Enabled = true;
                customers_otkat_button.Enabled = false;
                booking_otkat_button.Enabled = false;
            }

            if (otkat_tables_listBox.SelectedItem.ToString() == "customers_otkat")
            {
                stuff_otkat_button.Enabled = false;
                products_otkat_button.Enabled = false;
                customers_otkat_button.Enabled = true;
                booking_otkat_button.Enabled = false;
            }

            if (otkat_tables_listBox.SelectedItem.ToString() == "booking_otkat")
            {
                stuff_otkat_button.Enabled = false;
                products_otkat_button.Enabled = false;
                customers_otkat_button.Enabled = false;
                booking_otkat_button.Enabled = true;
            }

        }

        private void stuff_otkat_button_Click(object sender, EventArgs e)
        {
            if (otkat_dataGridView.GetCellCount(DataGridViewElementStates.Selected) > 8)
            {

                NpgsqlConnection conn = ConnectToDatabase;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                NpgsqlCommand comm1 = new NpgsqlCommand();
                comm1.Connection = conn;
                comm1.CommandType = CommandType.Text;
                NpgsqlCommand comm2 = new NpgsqlCommand();
                comm2.Connection = conn;
                comm2.CommandType = CommandType.Text;
                NpgsqlCommand comm3 = new NpgsqlCommand();
                comm3.Connection = conn;
                comm3.CommandType = CommandType.Text;

                if (otkat_dataGridView[7, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString() == "DELETE")
                {

                    comm.CommandText = $"INSERT INTO public.stuff" +
                   $"(login, password, name, surname, patronimic, post)" +
                   $"VALUES" +
                   $"('{otkat_dataGridView[1, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}'," +
                   $" '{otkat_dataGridView[2, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $" '{otkat_dataGridView[3, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $" '{otkat_dataGridView[4, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $" '{otkat_dataGridView[5, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $" '{otkat_dataGridView[6, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}');";

                    NpgsqlDataReader rdr = comm.ExecuteReader();
                    rdr.DisposeAsync();

                    comm.Dispose();



                    comm1.CommandText = $"DELETE FROM stuff_otkat WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()};";

                    NpgsqlDataReader rdr1 = comm1.ExecuteReader();

                    comm.Dispose();
                    conn.Dispose();
                    conn.Close();
                }


                if (otkat_dataGridView[7, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString() == "INSERT")
                {


                    comm2.CommandText = $"DELETE FROM stuff_otkat WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}; ";                    
                    NpgsqlDataReader rdr2 = comm2.ExecuteReader();

                    rdr2.DisposeAsync();

                    comm2.Dispose();

                    comm3.CommandText = $"DELETE FROM stuff WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()};";
                    NpgsqlDataReader rdr3 = comm3.ExecuteReader();

                    comm3.Cancel();
                    comm3.Dispose();

                    comm2.Dispose();
                    conn.Dispose();
                    conn.Close();

                }
               
            }
            else
            {
                MessageBox.Show("Выберите запись целиком!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            show_otkat_tables_button.PerformClick();
        }

        private void delete_otkat_button_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = $"DELETE FROM {otkat_tables_listBox.SelectedItem.ToString()} WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}";

            NpgsqlDataReader rdr = comm.ExecuteReader();

            comm.Dispose();
            conn.Dispose();
            conn.Close();

            show_otkat_tables_button.PerformClick();
        }

        private void customers_otkat_button_Click(object sender, EventArgs e)
        {
            if (otkat_dataGridView.GetCellCount(DataGridViewElementStates.Selected) > 8)
            {

                NpgsqlConnection conn = ConnectToDatabase;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                NpgsqlCommand comm1 = new NpgsqlCommand();
                comm1.Connection = conn;
                comm1.CommandType = CommandType.Text;
                NpgsqlCommand comm2 = new NpgsqlCommand();
                comm2.Connection = conn;
                comm2.CommandType = CommandType.Text;
                NpgsqlCommand comm3 = new NpgsqlCommand();
                comm3.Connection = conn;
                comm3.CommandType = CommandType.Text;

                if (otkat_dataGridView[7, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString() == "DELETE")
                {

                    comm.CommandText = $"INSERT INTO public.customers" +
                   $"(name, surname, user_login, user_password,user_mail,credit_card_id)" +
                   $"VALUES" +
                   $"('{otkat_dataGridView[1, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $"'{otkat_dataGridView[2, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $"'{otkat_dataGridView[3, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $"'{otkat_dataGridView[4, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $"'{otkat_dataGridView[5, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $"{otkat_dataGridView[6, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()});";

                    NpgsqlDataReader rdr = comm.ExecuteReader();
                    rdr.DisposeAsync();

                    comm.Dispose();



                    comm1.CommandText = $"DELETE FROM customers_otkat WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()};";

                    NpgsqlDataReader rdr1 = comm1.ExecuteReader();

                    comm.Dispose();
                    conn.Dispose();
                    conn.Close();
                }


                if (otkat_dataGridView[7, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString() == "INSERT")
                {


                    comm2.CommandText = $"DELETE FROM customers_otkat WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}; ";
                    NpgsqlDataReader rdr2 = comm2.ExecuteReader();

                    rdr2.DisposeAsync();

                    comm2.Dispose();

                    comm3.CommandText = $"DELETE FROM customers WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()};";
                    NpgsqlDataReader rdr3 = comm3.ExecuteReader();

                    comm3.Cancel();
                    comm3.Dispose();

                    comm2.Dispose();
                    conn.Dispose();
                    conn.Close();

                }

            }
            else
            {
                MessageBox.Show("Выберите запись целиком!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            show_otkat_tables_button.PerformClick();
        }

        private void booking_otkat_button_Click(object sender, EventArgs e)
        {
            if (otkat_dataGridView.GetCellCount(DataGridViewElementStates.Selected) > 9)
            {

                NpgsqlConnection conn = ConnectToDatabase;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                NpgsqlCommand comm1 = new NpgsqlCommand();
                comm1.Connection = conn;
                comm1.CommandType = CommandType.Text;
                NpgsqlCommand comm2 = new NpgsqlCommand();
                comm2.Connection = conn;
                comm2.CommandType = CommandType.Text;
                NpgsqlCommand comm3 = new NpgsqlCommand();
                comm3.Connection = conn;
                comm3.CommandType = CommandType.Text;
                NpgsqlCommand comm4 = new NpgsqlCommand();
                comm4.Connection = conn;
                comm4.CommandType = CommandType.Text;
                NpgsqlCommand comm5 = new NpgsqlCommand();
                comm5.Connection = conn;
                comm5.CommandType = CommandType.Text;

                if (otkat_dataGridView[9, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString() == "DELETE")
                {

                    comm.CommandText = $"INSERT INTO public.booking" +
                   $"(customers_id,adress_booking,promo_code,product_price,sale,end_price,list_of_products_id,status)" +  //1,2,3,4,5,6,9
                   $"VALUES" +
                   $"({otkat_dataGridView[1, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                   $"'{otkat_dataGridView[2, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $"'{otkat_dataGridView[3, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $"{otkat_dataGridView[4, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +                
                   $"{otkat_dataGridView[5, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                   $"{otkat_dataGridView[6, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                   $"{otkat_dataGridView[7, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}," +
                   $"'{otkat_dataGridView[8, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}');";

                    NpgsqlDataReader rdr = comm.ExecuteReader();
                    rdr.DisposeAsync();

                    comm.Dispose();



                    comm1.CommandText = $"DELETE FROM booking_otkat WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()};";

                    NpgsqlDataReader rdr1 = comm1.ExecuteReader();

                    comm.Dispose();
                    conn.Dispose();
                    conn.Close();
                }


                if (otkat_dataGridView[8, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString() == "INSERT")
                {


                    comm2.CommandText = $"DELETE FROM booking_otkat WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}; ";
                    NpgsqlDataReader rdr2 = comm2.ExecuteReader();

                    rdr2.DisposeAsync();

                    comm2.Dispose();

                    comm3.CommandText = $"DELETE FROM booking WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()};";
                    NpgsqlDataReader rdr3 = comm3.ExecuteReader();

                    comm3.Cancel();
                    comm3.Dispose();

                    comm2.Dispose();
                    conn.Dispose();
                    conn.Close();

                }


                if (otkat_dataGridView[8, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString() == "UPDATE")
                {



                    comm4.CommandText =
                        $"UPDATE booking SET " +
                        $"customers_id = {otkat_dataGridView[1, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                        $"adress_booking = '{otkat_dataGridView[2, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                        $"promo_code = '{otkat_dataGridView[3, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                        $"product_price = {otkat_dataGridView[4, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                        $"sale = {otkat_dataGridView[5, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                        $"end_price = {otkat_dataGridView[6, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                        $"list_of_products_id = {otkat_dataGridView[7, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()} " +
                        $"status = {otkat_dataGridView[7, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}" +

                        $" WHERE id = {otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()};";


                    NpgsqlDataReader rdr4 = comm4.ExecuteReader();

                    rdr4.DisposeAsync();

                    comm4.Dispose();

                    comm5.CommandText = $"DELETE FROM  booking_otkat WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()};";
                    NpgsqlDataReader rdr5 = comm5.ExecuteReader();

                    comm5.Cancel();
                    comm5.Dispose();

                }


            }
            else
            {
                MessageBox.Show("Выберите запись целиком!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            show_otkat_tables_button.PerformClick();
        }

        private void formated_out_booking_button_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText =
            $" SELECT booking_otkat.id,customers.name,customers.surname,list_of_products.product_name, " +
            $"booking_otkat.adress_booking,booking_otkat.promo_code,booking_otkat.product_price,booking_otkat.sale,booking_otkat.end_price,booking_otkat.Edit,booking_otkat.Time_edit " +
            $"FROM customers  " +
            $"JOIN (list_of_products JOIN booking_otkat ON list_of_products.id = booking_otkat.list_of_products_id) ON  customers.id = booking_otkat.customers_id;";

            NpgsqlDataReader rdr = comm.ExecuteReader();

            if (rdr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(rdr);
                otkat_dataGridView.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Таблица пуста!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void formated_out_products_button_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
      

             comm.CommandText =
             $"SELECT list_of_products_otkat.id,list_of_products_otkat.product_name, list_of_products_otkat.price, list_of_products_otkat.color,list_of_products_otkat.ammount,list_of_products_otkat.hand_type, " +
             $" size_sex.sex_size,size_sex.description," +
             $" brands.name_of_brand, list_of_products_otkat.edit, list_of_products_otkat.time_edit" +
             $" FROM brands " +
             $"JOIN (size_sex JOIN list_of_products_otkat ON list_of_products_otkat.size_id = size_sex.id) ON  brands.id = list_of_products_otkat.brands_id;";


            NpgsqlDataReader rdr = comm.ExecuteReader();

            if (rdr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(rdr);
                otkat_dataGridView.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Таблица пуста!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void products_otkat_button_Click(object sender, EventArgs e)
        {
            if (otkat_dataGridView.GetCellCount(DataGridViewElementStates.Selected) > 8)
            {

                NpgsqlConnection conn = ConnectToDatabase;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                NpgsqlCommand comm1 = new NpgsqlCommand();
                comm1.Connection = conn;
                comm1.CommandType = CommandType.Text;
                NpgsqlCommand comm2 = new NpgsqlCommand();
                comm2.Connection = conn;
                comm2.CommandType = CommandType.Text;
                NpgsqlCommand comm3 = new NpgsqlCommand();
                comm3.Connection = conn;
                comm3.CommandType = CommandType.Text;
                NpgsqlCommand comm4 = new NpgsqlCommand();
                comm4.Connection = conn;
                comm4.CommandType = CommandType.Text;
                NpgsqlCommand comm5 = new NpgsqlCommand();
                comm5.Connection = conn;
                comm5.CommandType = CommandType.Text;


                if (otkat_dataGridView[8, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString() == "DELETE")
                {

                    comm.CommandText = $"INSERT INTO list_of_products" +
                   $" (product_name, price , color, ammount, brands_id, hand_type, size_id) " +  
                   $" VALUES " +
                   $"('{otkat_dataGridView[1, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $"{otkat_dataGridView[2, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                   $"'{otkat_dataGridView[3, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $"{otkat_dataGridView[4, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                   $"{otkat_dataGridView[5, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                   $"'{otkat_dataGridView[6, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                   $"{otkat_dataGridView[7, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()});";

                    //MessageBox.Show(comm.CommandText);
                    NpgsqlDataReader rdr = comm.ExecuteReader();
                    rdr.DisposeAsync();

                    comm.Dispose();


                    comm1.CommandText = $"DELETE FROM list_of_products_otkat WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}; ";
                    NpgsqlDataReader rdr1 = comm1.ExecuteReader();

                    comm1.Cancel();
                    comm1.Dispose();

                    comm.Dispose();
                    conn.Dispose();
                    conn.Close();

                }


                if (otkat_dataGridView[8, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString() == "INSERT")
                {


                    comm2.CommandText = $"DELETE FROM list_of_products_otkat WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}; ";
                    NpgsqlDataReader rdr2 = comm2.ExecuteReader();

                    rdr2.DisposeAsync();

                    comm2.Dispose();

                    comm3.CommandText = $"DELETE FROM  list_of_products WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()};";
                    NpgsqlDataReader rdr3 = comm3.ExecuteReader();

                    comm3.Cancel();
                    comm3.Dispose();

                    comm2.Dispose();
                    conn.Dispose();
                    conn.Close();

                }


                if (otkat_dataGridView[8, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString() == "UPDATE")
                {


                    comm4.CommandText =
                        $"UPDATE list_of_products SET " +
                        $"product_name = '{otkat_dataGridView[1, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                        $"price = {otkat_dataGridView[2, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                        $"color = '{otkat_dataGridView[3, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                        $"ammount = {otkat_dataGridView[4, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                        $"brands_id = {otkat_dataGridView[5, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}, " +
                        $"hand_type = '{otkat_dataGridView[6, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}', " +
                        $"size_id = {otkat_dataGridView[7, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()}" +
                        $" WHERE id = {otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()};";


                    NpgsqlDataReader rdr4 = comm4.ExecuteReader();

                    rdr4.DisposeAsync();

                    comm4.Dispose();

                    comm5.CommandText = $"DELETE FROM  list_of_products_otkat WHERE id={otkat_dataGridView[0, otkat_dataGridView.CurrentCell.RowIndex].Value.ToString()};";
                    NpgsqlDataReader rdr5 = comm5.ExecuteReader();

                    comm5.Cancel();
                    comm5.Dispose();

                   

                }



            }
            else
            {
                MessageBox.Show("Выберите запись целиком!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            show_otkat_tables_button.PerformClick();
        }
    }
}
