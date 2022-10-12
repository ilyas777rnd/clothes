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
    public partial class WorkerForm : Form
    {
        public WorkerForm()
        {
            InitializeComponent();
        }

        public NpgsqlConnection ConnectToDatabase => new NpgsqlConnection("Server=localhost;Port=7777;DataBase=clothes;User Id=postgres;Password=0000");
        string LessOrBigger;
        string hand_type_string;
        string brand_string;
        string color_string;
        string size_string;

       


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
                 $"WHERE {LessOrBigger}";

            if (LessOrBigger==null || LessOrBigger.Equals(""))
            {
                comm.CommandText = comm.CommandText + " list_of_products.id>0 ";
            }


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

            //description_of_product_richTextBox.Text = comm.CommandText;
            //MessageBox.Show(comm.CommandText);

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
            LessOrBigger = "PRICE>" + price_textBox.Text;
            //get_products_button.Enabled = true;
        }

       
      

      

        private void price_textBox_TextChanged_1(object sender, EventArgs e)
        {
            if (bolshe_radioButton.Checked)
            {
                LessOrBigger = "PRICE>" + price_textBox.Text;
            }

            if (menshe_radioButton.Checked)
            {
                LessOrBigger = "PRICE<" + price_textBox.Text;
            }
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            price_textBox.Text = trackBar1.Value.ToString();
        }

        private void menshe_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            LessOrBigger = "PRICE<" + price_textBox.Text;
            //get_products_button.Enabled = true;
        }

        private void add_product_button_Click(object sender, EventArgs e)
        {

            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = $"INSERT INTO public.list_of_products " +
                $"(product_name,price,color,ammount,brands_id,hand_type,size_id) " +
                $"VALUES ('{description_of_product_richTextBox.Text}',{price_of_product_textBox.Text},'{color_string}',{ammount_textBox.Text},{brand_string},'{hand_type_string}',{size_string});";

            NpgsqlDataReader rdr = comm.ExecuteReader();


            comm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        

        private void polo_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            hand_type_string = polo_radioButton.Text;
        }

        private void tshirt_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            hand_type_string = polo_radioButton.Text;
        }

        private void red_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            color_string = red_radioButton.Text;
        }

        private void white_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            color_string = white_radioButton.Text;
        }

        private void yellow_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            color_string = yellow_radioButton.Text;
        }

        private void black_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            color_string = black_radioButton.Text;
        }

        private void grey_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            color_string = grey_radioButton.Text;
        }

        private void adidas_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            brand_string = "1";
        }

        private void nike_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            brand_string = "3";
        }

        private void puma_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            brand_string = "4";
        }

        private void reebok_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            brand_string = "2";
        }

        private void ralf_lauren_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            brand_string = "5";
        }

        private void MXS_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "1";
        }

        private void MS_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "2";
        }

        private void MM_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "3";
        }

        private void ML_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "4";
        }

        private void MXL_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "5";
        }

        private void MXXL_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "6";
        }

        private void MXXXL_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "7";
        }

        private void WXS_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "8";
        }

        private void WS_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "9";
        }

        private void WM_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "10";
        }

        private void WL_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "11";
        }

        private void WXL_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "12";
        }

        private void WXXL_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "13";
        }

        private void WXXXL_radioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            size_string = "14";
        }

        private void delete_button_Click(object sender, EventArgs e)
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
                       
                            comm.CommandText = $"DELETE FROM {tables_listBox.SelectedItem.ToString()} WHERE id={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()}";
                            MessageBox.Show("Вы удалили товар!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    else 
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

        private void add_product_button_Click_1(object sender, EventArgs e)
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

        private void exist_product__add_button_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;


            if (dataGridView1.GetCellCount(DataGridViewElementStates.Selected) == 9)
            {
                comm.CommandText = $"UPDATE list_of_products SET ammount = ammount+{exist_product_textBox.Text}" +
                    $" WHERE id = {dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()};";

                NpgsqlDataReader rdr = comm.ExecuteReader();
                get_products_button.PerformClick();

            }
            else
            {
                MessageBox.Show("Выберите 1 товар!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void show_table_button_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            string selected_table = tables_listBox.SelectedItem.ToString();
          
                
                if (selected_table == "booking")
                {
                    comm.CommandText = $" SELECT booking.id,customers.name,customers.surname,list_of_products.product_name, " +
                                  $"booking.adress_booking,booking.promo_code,booking.product_price,booking.sale,booking.end_price, booking.status " +
                                  $"FROM customers  " +
                                  $"JOIN (list_of_products JOIN booking ON list_of_products.id = booking.list_of_products_id) ON  customers.id = booking.customers_id;";
                }
                
                else if (selected_table == "review")
                {
                    comm.CommandText = $" SELECT review.product_name,review.score,customers.name, customers.surname,review.text" +
                                     $" FROM review JOIN customers ON review.customer_review = customers.id;";
                }

            else if (selected_table == "list_of_products")
            {
                comm.CommandText = $"SELECT list_of_products.id,list_of_products.product_name, list_of_products.price, list_of_products.color, list_of_products.ammount, " +
                 $" brands.name_of_brand, list_of_products.hand_type, size_sex.sex_size, size_sex.description " +
                 $" FROM brands " +
                 $" JOIN (size_sex JOIN list_of_products ON list_of_products.size_id = size_sex.id) ON  brands.id = list_of_products.brands_id ";
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

        private void change_price_button_Click(object sender, EventArgs e)
        {
            if(tables_listBox.SelectedItem.ToString()=="list_of_products")
            {
                NpgsqlConnection conn = ConnectToDatabase;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;

                if (dataGridView1.Columns.Count > 7)
                {
                    comm.CommandText =
                    $"UPDATE list_of_products SET price = {price_changed_richTextBox.Text}" +
                    $" WHERE  id ={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()};";
                    //    $" WHERE  product_name ='{dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString()}' and color='{dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString()}';";
                    NpgsqlDataReader rdr = comm.ExecuteReader();

                    get_products_button.PerformClick();
                    MessageBox.Show("Цена изменена!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Выберите запись целиком!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите верную таблицу для изменения данных!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
               

        }

        private void back_to_init_button_Click(object sender, EventArgs e)
        {
            InitialisationForm InitF = new InitialisationForm();
            InitF.Show();
            this.Hide();
        }

        private void change_adress_button_Click(object sender, EventArgs e)
        {
            if (tables_listBox.Text == "booking")
            {
                NpgsqlConnection conn = ConnectToDatabase;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;


                if (dataGridView1.Columns.Count == 9)
                {
                    comm.CommandText =
                    $"UPDATE booking SET adress_booking = '{adress_change_richTextBox.Text}'" +
                    $" WHERE id ={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()};";
                    NpgsqlDataReader rdr = comm.ExecuteReader();

                    show_table_button.PerformClick();
                    MessageBox.Show("Адрес изменен!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Выберите одну запись целиком!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите верную таблицу для изменения данных!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            tables_listBox.SelectedItem = "list_of_products";
        }

        private void WorkerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1[9, dataGridView1.CurrentCell.RowIndex].Value.ToString()=="собирается")
            {
                change_adress_button.Enabled = true;
            }
            else
            {
                change_adress_button.Enabled = false;
            }
        }

        private void change_status_button_Click(object sender, EventArgs e)
        {
            if (tables_listBox.SelectedItem.ToString()=="booking")
            {
                NpgsqlConnection conn = ConnectToDatabase;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;

                comm.CommandText =
                       $"UPDATE booking SET status = 'отправлен'" +
                       $" WHERE status ='собирается' and id ={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()} ;";
                NpgsqlDataReader rdr = comm.ExecuteReader();

                show_table_button.PerformClick();
                MessageBox.Show("Статус заказа изменен!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите таблицу заказов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
    }
}
