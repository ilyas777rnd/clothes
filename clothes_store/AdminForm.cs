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
using System.Security.Cryptography;

namespace clothes_store
{
    public partial class AdminForm : Form
    {

        string BolsheMenshe;
        string hand_type_string;
        string brand_string;
        string color_string;
        string size_string;

        public AdminForm()
        {
            InitializeComponent();           
           
        }
        public NpgsqlConnection ConnectToDatabase => new NpgsqlConnection("Server=localhost;Port=7777;DataBase=clothes;User Id=postgres;Password=0000");

        private void show_table_button_Click(object sender, EventArgs e)//отобраение таблицы в datagrid
        {
            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            if (tables_listBox.SelectedItem.ToString() == "booking")

            {
                comm.CommandText = $" SELECT booking.id,customers.name,customers.surname,list_of_products.product_name, " +
                              $"booking.adress_booking,booking.promo_code,booking.product_price,booking.sale,booking.end_price " +
                              $"FROM customers  " +
                              $"JOIN (list_of_products JOIN booking ON list_of_products.id = booking.list_of_products_id) ON  customers.id = booking.customers_id;";
            }      
           
             if (tables_listBox.SelectedItem.ToString() == "review")
             {
                    comm.CommandText = $" SELECT review.product_name,review.score,customers.name, customers.surname,review.text" +
                                $" FROM review JOIN customers ON review.customer_review = customers.id;";
             }
             else
             {
                comm.CommandText = $"SELECT * FROM {tables_listBox.SelectedItem.ToString()}";
             }
          
            NpgsqlDataReader rdr = comm.ExecuteReader();

            if (rdr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(rdr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Таблица пуста!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = $"SELECT * FROM size_sex WHERE sex_size='{search_size_textBox.Text}'";
            NpgsqlDataReader rdr = comm.ExecuteReader();
      

            if (rdr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(rdr);
                dataGridView1.DataSource = dt;              
            }
            else
            {
                MessageBox.Show("Такого значения не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comm.Dispose();
            conn.Dispose();
            conn.Close();
           
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = $"SELECT * FROM promo_code WHERE the_code='{search__promocode_textBox.Text}'";
            NpgsqlDataReader rdr = comm.ExecuteReader();

 

            if (rdr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(rdr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Такого значения не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comm.Dispose();
            conn.Dispose();
            conn.Close();
        }

   

        private void Reserved_copy_button_Click(object sender, EventArgs e)
        {
            //дата для имени файла
            DateTime date = new DateTime();
            string d = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString()
                + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            //cmd с указанием пути до pg_dump с параметром
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = @"C:\Program Files\PostgreSQL\13\bin\";
            //C:\Program Files\PostgreSQL\13\bin\pg_dump.exe --file "C:\\Users\\grinr\\Desktop\\1.sql" --host "localhost" --port "5432" --username "postgres" --no-password --verbose --format=c --blobs --encoding "UTF8" "clothes_store_1"
            p.StartInfo.Arguments = "/k pg_dump.exe --file \"C:\\Users\\grinr\\Desktop\\" + d + ".sql\" --host \"localhost\" --port \"5432\" --username \"postgres\" --verbose --format=c --blobs \"clothes_store_1\"";
            p.Start();
            MessageBox.Show("Успешно!");
            p.Close();
        }


        private void Dawnload_copy_button_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "SQL file (*.sql)|*.sql|All files(*.*)|*.*";
            string pathdb = "";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            pathdb = openFileDialog1.FileName;

            //cmd с указанием пути до pg_dump с параметром
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = @"C:\Program Files\PostgreSQL\13\bin\";
            p.StartInfo.Arguments = "/k pg_restore.exe --host \"localhost\" --port \"5432\" --username \"postgres\" --role \"postgres\" --dbname \"clothes_store_2\" --verbose \"" + pathdb + "\"";
            p.Start();
            MessageBox.Show("Успешно!");
            p.Close();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            price_textBox.Text = trackBar1.Value.ToString();
        }

       

        private void get_products_button_Click(object sender, EventArgs e)
        {
            string conditions_size = "";

            string conditions_color = "";

            string conditions_brands = "";

            foreach (var item in size_CheckBox.CheckedItems)
            {
                //conditions_size += "AND " + item + " ";              
                conditions_size += $"sex_size='{item}' OR ";
            }

            foreach (var item in brand_checkedListBox.CheckedItems)
            {
                conditions_brands += $"name_of_brand='{item}' OR ";
            }

            if (conditions_brands != "")
            {
                conditions_brands = conditions_brands.Remove(conditions_brands.Length - 3);
                conditions_brands = "(" + conditions_brands + ")";
            }



            if (conditions_size != "")
            {
                conditions_size = conditions_size.Remove(conditions_size.Length - 3);
            }

            foreach (var item in color_checkedListBox.CheckedItems)
            {
                //conditions_size += "AND " + item + " ";  
                if (item.ToString() == "поло" || item.ToString() == "футболка")
                {
                    if (conditions_color != "" && conditions_color.Substring(conditions_color.Length - 4) == " OR ")
                    {
                        conditions_color = "(" + conditions_color + ")";
                        conditions_color = conditions_color.Remove(conditions_color.Length - 4) + ")";
                        conditions_color += " AND ";
                    }
                    conditions_color += $"hand_type='{item}' AND ";
                }
                else
                {
                    conditions_color += $"color='{item}' OR ";
                }
            }

            if (conditions_color != "")
            {
                if (conditions_color.Substring(conditions_color.Length - 3) == "OR ")
                {
                    conditions_color = conditions_color.Remove(conditions_color.Length - 3);
                }
                else
                {
                    conditions_color = conditions_color.Remove(conditions_color.Length - 4);
                }
            }


           

            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;



            comm.CommandText = $"SELECT list_of_products.id,list_of_products.product_name, list_of_products.price, list_of_products.color,list_of_products.ammount,list_of_products.hand_type," +
                 $" size_sex.sex_size,size_sex.description," +
                 $"brands.name_of_brand" +
                 $" FROM brands " +
                 $"JOIN (size_sex JOIN list_of_products ON list_of_products.size_id = size_sex.id) ON  brands.id = list_of_products.brands_id " +
                 $"WHERE {BolsheMenshe}";


            if (conditions_size == "")
            {
                if (conditions_color == "")
                {
                    if (conditions_brands == "")
                    {
                        comm.CommandText = comm.CommandText + ";";
                    }
                    else
                    {
                        comm.CommandText = comm.CommandText + $" AND {conditions_brands};";
                    }
                }
                else
                {
                    if (conditions_brands == "")
                    {
                        comm.CommandText = comm.CommandText + " AND (" + conditions_color + ");";
                    }
                    else
                    {
                        comm.CommandText = comm.CommandText + " AND (" + conditions_color + ")" + $" AND {conditions_brands}; ";
                    }
                }

            }
            else
            {
                if (conditions_color == "")
                {
                    if (conditions_brands == "")
                    {
                        comm.CommandText = comm.CommandText + " AND (" + conditions_size + ");";
                    }
                    else
                    {
                        comm.CommandText = comm.CommandText + $" AND {conditions_brands}" + " AND (" + conditions_size + ");";
                    }
                }
                else
                {
                    if (conditions_brands == "")
                    {
                        comm.CommandText = comm.CommandText + " AND (" + conditions_color + ")" + " AND (" + conditions_size + ");";
                    }
                    else
                    {
                        comm.CommandText = comm.CommandText + " AND (" + conditions_color + ")" + $" AND {conditions_brands}" + " AND (" + conditions_size + ");";
                    }
                }
            }

            description_of_product_richTextBox.Text = comm.CommandText;

            NpgsqlDataReader rdr = comm.ExecuteReader();

            if (rdr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(rdr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Сори, товаров по таким запросам не было найдено", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bolshe_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            BolsheMenshe = "PRICE>" + price_textBox.Text;
            get_products_button.Enabled = true;
        }

        private void menshe_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            BolsheMenshe = "PRICE<" + price_textBox.Text;
            get_products_button.Enabled = true;
        }

        private void price_textBox_TextChanged(object sender, EventArgs e)
        {
            if(bolshe_radioButton.Checked)
            {
                BolsheMenshe = "PRICE>" + price_textBox.Text;
            }

            if (menshe_radioButton.Checked)
            {
                BolsheMenshe = "PRICE<" + price_textBox.Text;
            }
        }

        private void polo_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            hand_type_string = polo_radioButton.Text;
        }

        private void tshirt_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            hand_type_string = polo_radioButton.Text;
        }

        private void red_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            color_string = red_radioButton.Text;
        }

        private void white_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            color_string = white_radioButton.Text;
        }

        private void yellow_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            color_string = yellow_radioButton.Text;
        }

        private void black_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            color_string = black_radioButton.Text;
        }

        private void grey_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            color_string = grey_radioButton.Text;
        }

        private void adidas_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            brand_string = "1";
        }

        private void nike_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            brand_string = "3";
        }

        private void puma_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            brand_string = "4";
        }

        private void reebok_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            brand_string = "2";
        }

        private void ralf_lauren_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            brand_string = "5";
        }

        private void MXS_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "1";
        }

        private void MS_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "2";
        }

        private void MM_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "3";
        }

        private void ML_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "4";
        }

        private void MXL_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "5";
        }

        private void MXXL_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "6";
        }

        private void MXXXL_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "7";
        }

        private void WXS_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "8";
        }

        private void WS_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "9";
        }

        private void WM_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "10";
        }

        private void WL_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "11";
        }

        private void WXL_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "12";
        }

        private void WXXL_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "13";
        }

        private void WXXXL_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            size_string = "14";
        }

        private void otkat_button_Click(object sender, EventArgs e)
        {
            OtkatForm OtkF = new OtkatForm();
            OtkF.Show();          
        }

        private void back_to_init_button_Click(object sender, EventArgs e)
        {
            InitialisationForm InitF = new InitialisationForm();
            InitF.Show();
            this.Hide();
        }
        public string DecodeString(string codedlstring)
        {
            string decodedstring = "";
            string hash = "f0xle@rn";

            byte[] data1 = Convert.FromBase64String(codedlstring);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data1, 0, data1.Length);
                    decodedstring = UTF8Encoding.UTF8.GetString(results);
                }
            }

            return decodedstring;
        }

        private void decode_data_button_Click(object sender, EventArgs e)
        {
            if(tables_listBox.SelectedItem.ToString()=="credit_card")
            {
                if (dataGridView1.GetCellCount(DataGridViewElementStates.Selected) == 5)
                {
                    cart_decoded_richTextBox.Text = DecodeString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                    cvv_decoded_richTextBox.Text = DecodeString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Выберите запись целиком!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Выберите таблицу credit_card!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void make_new_customer_button_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "" || textBox18.Text == "")
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

                comm.CommandText = $"INSERT INTO public.stuff" +
                  $"(login, password, name, surname, patronimic, post)" +
                  $"VALUES('{textBox8.Text}', '{textBox14.Text}', '{textBox15.Text}', '{textBox16.Text}', '{textBox17.Text}', '{textBox18.Text}')";

                NpgsqlDataReader rdr = comm.ExecuteReader();

                comm.Dispose();
                conn.Dispose();
                conn.Close();


            }
        }

        private void make_new_promocode_button_Click(object sender, EventArgs e)
        {
            if (textBox19.Text == "" || textBox20.Text == "" || textBox21.Text == "" || textBox22.Text == "")
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

                comm.CommandText = $"INSERT INTO public.promo_code" +
                  $"(start_date, end_date, sale_in_percent, the_code)" +
                  $"VALUES('{textBox19.Text}', '{textBox20.Text}', '{textBox21.Text}', '{textBox22.Text}')";

                NpgsqlDataReader rdr = comm.ExecuteReader();

                comm.Dispose();
                conn.Dispose();
                conn.Close();


            }
        }

        private void make_new_product_button_Click(object sender, EventArgs e)
        {

            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;



            if (description_of_product_richTextBox.Text != "" && price_of_product_textBox.Text != "" && ammount_textBox.Text != "")
            {
                comm.CommandText = $"INSERT INTO public.list_of_products " +
                    $"(product_name,price,color,ammount,brands_id,hand_type,size_id) " +
                    $"VALUES ('{description_of_product_richTextBox.Text}',{price_of_product_textBox.Text},'{color_string}',{ammount_textBox.Text},{brand_string},'{hand_type_string}',{size_string});";

                NpgsqlDataReader rdr = comm.ExecuteReader();

                get_products_button.PerformClick();

            }
            else
            {
                MessageBox.Show("Выберите все пункты прежде чем добавить товар!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            comm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        private void delete_all_button_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();

            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;


            if (tables_listBox.SelectedItems.Count == 1)
            {
                if (tables_listBox.SelectedItem.ToString() == "size_sex" || tables_listBox.SelectedItem.ToString() == "brands" || tables_listBox.SelectedItem.ToString() == "review")
                {
                    MessageBox.Show($"Вы не можете удалять данные из {tables_listBox.SelectedItem.ToString()}!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите произвести удаление?", "Внимание!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (tables_listBox.SelectedItem.ToString() == "credit_card")
                        {
                            comm.CommandText = $"DELETE FROM {tables_listBox.SelectedItem.ToString()} CASCADE WHERE id={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()} ;";
                        }
                        else
                        {
                            comm.CommandText = $"DELETE FROM {tables_listBox.SelectedItem.ToString()} WHERE id={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()} ;";
                        }

                        NpgsqlDataReader rdr_del = comm.ExecuteReader();

                        if (tables_listBox.SelectedItem.ToString() == "list_of_products")
                        {
                            get_products_button.PerformClick();
                        }
                        if (tables_listBox.SelectedItem.ToString() == "booking")
                        {
                            show_table_button.PerformClick();
                        }

                       

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Вы отменили удаление!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите таблицу для удаления!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            comm.Dispose();
            conn.Dispose();
            conn.Close();
        }
    }
}
