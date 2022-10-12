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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
          
        }

        public string custumer_id
        {
            get
            {
                return customer_id_label.ToString();
            }
            set
            {
                this.customer_id_label.Text = value;
            }
        }


        public NpgsqlConnection ConnectToDatabase => new NpgsqlConnection("Server=localhost;Port=7777;DataBase=clothes;User Id=postgres;Password=0000");



        private void CustomerForm_Load(object sender, EventArgs e)
        {


            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = $"SELECT list_of_products.id,list_of_products.product_name, list_of_products.price, list_of_products.color,list_of_products.ammount," +
                    $" size_sex.sex_size,size_sex.description," +
                    $"brands.name_of_brand" +
                    $" FROM brands " +
                    $"JOIN (size_sex JOIN list_of_products ON list_of_products.size_id = size_sex.id) ON  brands.id = list_of_products.brands_id; ";

            NpgsqlDataReader rdr = comm.ExecuteReader();

            if (rdr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(rdr);
                dataGridView1.DataSource = dt;
            }

            comm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            price_textBox.Text = trackBar1.Value.ToString();
        }


        string BolsheMenshe;

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
            BolsheMenshe = "PRICE < " + price_textBox.Text;
            get_products_button.Enabled = true;
        }

        private void price_textBox_TextChanged(object sender, EventArgs e)
        {
            if (bolshe_radioButton.Checked)
            {
                BolsheMenshe = "PRICE>" + price_textBox.Text;
            }

            if (menshe_radioButton.Checked)
            {
                BolsheMenshe = "PRICE<" + price_textBox.Text;
            }
        }

        private void promo_code_button_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn1 = ConnectToDatabase;
            conn1.Open();


            NpgsqlCommand comm1 = new NpgsqlCommand();
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.Text;

            comm1.CommandText = $"SELECT the_code FROM promo_code WHERE the_code='{promo_code_textBox.Text}';";
            NpgsqlDataReader rdr1 = comm1.ExecuteReader();

            comm1.Dispose();

            if (rdr1.HasRows)
            {
                rdr1.Read();
                promo_code_textBox.Text = rdr1.GetString(0);
                MessageBox.Show("Ваш промокод будет учтён при формировании заказа", "УРА!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Такого промокода не существует", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                promo_code_textBox.Clear();

            }
        }

        private void calculate_price_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.GetCellCount(DataGridViewElementStates.Selected) != 8)
            {
                MessageBox.Show("Выберите покупаемый товар!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //textBox3.Text = dataGridView1.GetCellCount(DataGridViewElementStates.Selected).ToString();
            }
            else
            {

                //-----------------------------------Рассчитываем цену товара-------------------------
                NpgsqlConnection conn1 = ConnectToDatabase;
                conn1.Open();

                NpgsqlCommand comm1 = new NpgsqlCommand();
                comm1.Connection = conn1;
                comm1.CommandType = CommandType.Text;

                comm1.CommandText = $"SELECT price FROM list_of_products WHERE id={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()};";
                NpgsqlDataReader rdr1 = comm1.ExecuteReader();

                comm1.Dispose();

                if (rdr1.HasRows)
                {
                    rdr1.Read();
                    product_price_textBox.Text = rdr1.GetInt32(0).ToString();

                }

                comm1.Dispose();
                conn1.Dispose();
                conn1.Close();

                //-----------------------------------Рассчитали цену товара-----------------------------


                //-----------------------------------Рассчитываем скидку-------------------------------

                NpgsqlConnection conn2 = ConnectToDatabase;
                conn2.Open();

                NpgsqlCommand comm2 = new NpgsqlCommand();
                comm2.Connection = conn2;
                comm2.CommandType = CommandType.Text;

                comm2.CommandText = $"SELECT sale_in_percent FROM promo_code WHERE the_code='{promo_code_textBox.Text}';";
                NpgsqlDataReader rdr2 = comm2.ExecuteReader();


                double getsale = 0;
                double getprice = double.Parse(product_price_textBox.Text);

                if (rdr2.HasRows)
                {
                    rdr2.Read();
                    sale_in_percent_textBox.Text = rdr2.GetInt32(0).ToString();
                    getsale = double.Parse(product_price_textBox.Text) * (double.Parse(sale_in_percent_textBox.Text) / 100);
                    sale_textBox.Text = (getsale).ToString();
                    end_price_textBox.Text = (getprice - getsale).ToString();

                }
                else
                {
                    sale_textBox.Text = "0";
                    sale_in_percent_textBox.Text = "0";
                    end_price_textBox.Text = product_price_textBox.Text;
                }


                //-----------------------------------Рассчитали  скидку-------------------------------
            }
        }

        private void order_button_Click(object sender, EventArgs e)
        {
            if (product_price_textBox.Text != "" && adress_richTextBox.Text != "")
            {

                NpgsqlConnection conn2 = ConnectToDatabase;
                conn2.Open();

                NpgsqlCommand comm2 = new NpgsqlCommand();
                comm2.Connection = conn2;
                comm2.CommandType = CommandType.Text;
                comm2.CommandType = CommandType.Text;

                if (dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value.ToString() =="1")
                {
                    comm2.CommandText = $"DELETE FROM list_of_products  WHERE id={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()};";
                    NpgsqlDataReader rdr2 = comm2.ExecuteReader();
                }
                else
                {
                    comm2.CommandText = $"UPDATE list_of_products SET ammount = ammount-1 WHERE id = {dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()}; ";
                    NpgsqlDataReader rdr2 = comm2.ExecuteReader();
                }
               

                NpgsqlConnection conn1 = ConnectToDatabase;
                conn1.Open();

                NpgsqlCommand comm1 = new NpgsqlCommand();
                comm1.Connection = conn1;
                comm1.CommandType = CommandType.Text;

                //                INSERT INTO public.booking
                //("customers_id","adress_booking","promo_code","product_price","sale","end_price","list_of_products_id")


                if (promo_code_textBox.Text != "")
                {
                    comm1.CommandText = $"INSERT INTO public.booking " +
                   $"(customers_id,adress_booking,promo_code,product_price,sale,end_price,list_of_products_id,status)" +
                   $"VALUES ({customer_id_label.Text}, '{adress_richTextBox.Text}','{promo_code_textBox.Text}',{product_price_textBox.Text},{sale_textBox.Text},{end_price_textBox.Text},{dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()},'собирается') ;";
                    NpgsqlDataReader rdr = comm1.ExecuteReader();

                }
                else
                {
                    comm1.CommandText = $"INSERT INTO public.booking " +
                  $"(customers_id,adress_booking,promo_code,product_price,sale,end_price,list_of_products_id,status)" +
                  $"VALUES ({customer_id_label.Text}, '{adress_richTextBox.Text}',null,{product_price_textBox.Text},null,{product_price_textBox.Text},{dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()},'собирается') ;";
                    NpgsqlDataReader rdr = comm1.ExecuteReader();
                }

                comm1.Dispose();


                MessageBox.Show("Товар успешно заказан!");
            }
            else
            {
                MessageBox.Show("Вы не ввели все данные чтобы заказать товар!!!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void get_reviews_button_Click(object sender, EventArgs e)
        {


            NpgsqlConnection conn1 = ConnectToDatabase;
            conn1.Open();

            NpgsqlCommand comm1 = new NpgsqlCommand();
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.Text;


            if (dataGridView1.GetCellCount(DataGridViewElementStates.Selected) != 9)
            {

                comm1.CommandText = $" SELECT review.product_name,review.score,customers.name, customers.surname,review.text" +
                                    $" FROM review JOIN customers ON review.customer_review = customers.id;";
                NpgsqlDataReader rdr = comm1.ExecuteReader();

                if (rdr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Сори, отзывы на этот товар еще не сделали.Станьте первым!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                comm1.CommandText = $" SELECT review.product_name,review.score,customers.name, customers.surname,review.text" +
                                    $" FROM review JOIN customers ON review.customer_review = customers.id" +
                                    $" WHERE product_name='{dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString()}';";
                NpgsqlDataReader rdr = comm1.ExecuteReader();


                if (rdr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Сори, отзывы на этот товар еще не сделали.Станьте первым!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }




        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            string value_of_score = trackBar2.Value.ToString().Remove(1);

            value_of_score += ".";

            value_of_score += trackBar2.Value.ToString().Remove(0, 1);

            score_textBox.Text = value_of_score;
        }

        private void insert_review_button_Click(object sender, EventArgs e)
        {
            if (score_textBox.Text == "" || review_text_richTextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля для создания отзыва!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dataGridView1.GetCellCount(DataGridViewElementStates.Selected) == 8)
                {

                    NpgsqlConnection conn1 = ConnectToDatabase;
                    conn1.Open();

                    NpgsqlCommand comm1 = new NpgsqlCommand();
                    comm1.Connection = conn1;
                    comm1.CommandType = CommandType.Text;
        
                    comm1.CommandText = $"INSERT INTO public.review " +
                                        $"(customer_review,score,text,product_name)" +
                                        $" VALUES ({customer_id_label.Text}, {score_textBox.Text},'{review_text_richTextBox.Text}','{dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString()}') ;";

                    NpgsqlDataReader rdr = comm1.ExecuteReader();

                   

                }
                else
                {
                    MessageBox.Show("Выберите товар, на который хотите оставить отзыв!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void back_to_init_button_Click(object sender, EventArgs e)
        {

            InitialisationForm InitF = new InitialisationForm();
            InitF.Show();
            this.Hide();
        }

        private void CustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void show_table_button_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = ConnectToDatabase;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            if (listBox1.SelectedItem.ToString() == "list_of_products")
            {
                comm.CommandText = $"SELECT list_of_products.id,list_of_products.product_name, list_of_products.price, list_of_products.color,list_of_products.ammount," +
                     $" size_sex.sex_size,size_sex.description," +
                     $"brands.name_of_brand" +
                     $" FROM brands " +
                     $"JOIN (size_sex JOIN list_of_products ON list_of_products.size_id = size_sex.id) ON  brands.id = list_of_products.brands_id; ";
            }
            else
            {
                if (listBox1.SelectedItem.ToString() == "booking")
                {
                    comm.CommandText = $" SELECT booking.id,customers.name,customers.surname,list_of_products.product_name, " +
                            $"booking.adress_booking,booking.promo_code,booking.product_price,booking.sale,booking.end_price " +
                            $"FROM customers  " +
                            $"JOIN (list_of_products JOIN booking ON list_of_products.id = booking.list_of_products_id) ON  customers.id = booking.customers_id " +
                            $"WHERE customers.id={customer_id_label.Text}";
                }
                else
                {
                    comm.CommandText = $"SELECT * FROM {listBox1.SelectedItem.ToString()}";
                }

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
    }
}
