namespace clothes_store
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.show_table_button = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.price_textBox = new System.Windows.Forms.TextBox();
            this.get_products_button = new System.Windows.Forms.Button();
            this.size_CheckBox = new System.Windows.Forms.CheckedListBox();
            this.color_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.brand_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bolshe_radioButton = new System.Windows.Forms.RadioButton();
            this.menshe_radioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.customer_id_label = new System.Windows.Forms.Label();
            this.adress_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.promo_code_textBox = new System.Windows.Forms.TextBox();
            this.promo_code_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.calculate_price_button = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.product_price_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sale_textBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.end_price_textBox = new System.Windows.Forms.TextBox();
            this.order_button = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.sale_in_percent_textBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.get_reviews_button = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.score_textBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.review_text_richTextBox = new System.Windows.Forms.RichTextBox();
            this.insert_review_button = new System.Windows.Forms.Button();
            this.back_to_init_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(408, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1415, 468);
            this.dataGridView1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Items.AddRange(new object[] {
            "list_of_products",
            "review",
            "size_sex",
            "brands",
            "booking"});
            this.listBox1.Location = new System.Drawing.Point(8, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(172, 79);
            this.listBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(201, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Отобразите таблицу";
            // 
            // show_table_button
            // 
            this.show_table_button.BackColor = System.Drawing.Color.PeachPuff;
            this.show_table_button.Location = new System.Drawing.Point(204, 33);
            this.show_table_button.Name = "show_table_button";
            this.show_table_button.Size = new System.Drawing.Size(160, 79);
            this.show_table_button.TabIndex = 5;
            this.show_table_button.Text = "Показать информацию ввыбранной таблицы";
            this.show_table_button.UseVisualStyleBackColor = false;
            this.show_table_button.Click += new System.EventHandler(this.show_table_button_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.BackColor = System.Drawing.Color.Thistle;
            this.trackBar1.Location = new System.Drawing.Point(108, 158);
            this.trackBar1.Maximum = 15000;
            this.trackBar1.Minimum = 500;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(286, 56);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 500;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // price_textBox
            // 
            this.price_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.price_textBox.Location = new System.Drawing.Point(108, 118);
            this.price_textBox.Name = "price_textBox";
            this.price_textBox.Size = new System.Drawing.Size(286, 34);
            this.price_textBox.TabIndex = 9;
            this.price_textBox.Text = "0";
            this.price_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.price_textBox.TextChanged += new System.EventHandler(this.price_textBox_TextChanged);
            // 
            // get_products_button
            // 
            this.get_products_button.BackColor = System.Drawing.Color.Plum;
            this.get_products_button.Enabled = false;
            this.get_products_button.Location = new System.Drawing.Point(8, 417);
            this.get_products_button.Name = "get_products_button";
            this.get_products_button.Size = new System.Drawing.Size(386, 66);
            this.get_products_button.TabIndex = 13;
            this.get_products_button.Text = "Получить выбранные товары";
            this.get_products_button.UseVisualStyleBackColor = false;
            this.get_products_button.Click += new System.EventHandler(this.get_products_button_Click);
            // 
            // size_CheckBox
            // 
            this.size_CheckBox.BackColor = System.Drawing.Color.Thistle;
            this.size_CheckBox.FormattingEnabled = true;
            this.size_CheckBox.Items.AddRange(new object[] {
            "MXS",
            "MS",
            "MM",
            "ML",
            "MXL",
            "MXXL",
            "MXXXL",
            "WXS",
            "WS",
            "WM",
            "WL",
            "WXL",
            "WXXL",
            "WXXXL"});
            this.size_CheckBox.Location = new System.Drawing.Point(8, 118);
            this.size_CheckBox.Name = "size_CheckBox";
            this.size_CheckBox.Size = new System.Drawing.Size(98, 293);
            this.size_CheckBox.TabIndex = 14;
            // 
            // color_checkedListBox
            // 
            this.color_checkedListBox.BackColor = System.Drawing.Color.Thistle;
            this.color_checkedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.color_checkedListBox.FormattingEnabled = true;
            this.color_checkedListBox.Items.AddRange(new object[] {
            "красный",
            "чёрный",
            "белый",
            "серый",
            "желтый",
            "поло",
            "футболка"});
            this.color_checkedListBox.Location = new System.Drawing.Point(108, 210);
            this.color_checkedListBox.MultiColumn = true;
            this.color_checkedListBox.Name = "color_checkedListBox";
            this.color_checkedListBox.Size = new System.Drawing.Size(122, 202);
            this.color_checkedListBox.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(218, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 15);
            this.button2.TabIndex = 18;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(218, 239);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 15);
            this.button3.TabIndex = 19;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(218, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 15);
            this.button4.TabIndex = 20;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button5.Location = new System.Drawing.Point(218, 281);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 15);
            this.button5.TabIndex = 21;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Yellow;
            this.button6.Location = new System.Drawing.Point(218, 302);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(55, 15);
            this.button6.TabIndex = 22;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // brand_checkedListBox
            // 
            this.brand_checkedListBox.BackColor = System.Drawing.Color.Thistle;
            this.brand_checkedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.brand_checkedListBox.FormattingEnabled = true;
            this.brand_checkedListBox.Items.AddRange(new object[] {
            "Adidas",
            "Nike",
            "Reebok",
            "Puma",
            "Ralf Lauren"});
            this.brand_checkedListBox.Location = new System.Drawing.Point(231, 331);
            this.brand_checkedListBox.Name = "brand_checkedListBox";
            this.brand_checkedListBox.Size = new System.Drawing.Size(163, 80);
            this.brand_checkedListBox.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bolshe_radioButton);
            this.groupBox1.Controls.Add(this.menshe_radioButton);
            this.groupBox1.Location = new System.Drawing.Point(273, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 105);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // bolshe_radioButton
            // 
            this.bolshe_radioButton.AutoSize = true;
            this.bolshe_radioButton.Location = new System.Drawing.Point(6, 21);
            this.bolshe_radioButton.Name = "bolshe_radioButton";
            this.bolshe_radioButton.Size = new System.Drawing.Size(80, 21);
            this.bolshe_radioButton.TabIndex = 1;
            this.bolshe_radioButton.TabStop = true;
            this.bolshe_radioButton.Text = "Больше";
            this.bolshe_radioButton.UseVisualStyleBackColor = true;
            this.bolshe_radioButton.CheckedChanged += new System.EventHandler(this.bolshe_radioButton_CheckedChanged);
            // 
            // menshe_radioButton
            // 
            this.menshe_radioButton.AutoSize = true;
            this.menshe_radioButton.Location = new System.Drawing.Point(6, 57);
            this.menshe_radioButton.Name = "menshe_radioButton";
            this.menshe_radioButton.Size = new System.Drawing.Size(82, 21);
            this.menshe_radioButton.TabIndex = 0;
            this.menshe_radioButton.TabStop = true;
            this.menshe_radioButton.Text = "Меньше";
            this.menshe_radioButton.UseVisualStyleBackColor = true;
            this.menshe_radioButton.CheckedChanged += new System.EventHandler(this.menshe_radioButton_CheckedChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(386, 31);
            this.label3.TabIndex = 26;
            this.label3.Text = "СФОРМИРОВАТЬ ЗАКАЗ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customer_id_label
            // 
            this.customer_id_label.AutoSize = true;
            this.customer_id_label.Location = new System.Drawing.Point(12, 9);
            this.customer_id_label.Name = "customer_id_label";
            this.customer_id_label.Size = new System.Drawing.Size(123, 17);
            this.customer_id_label.TabIndex = 27;
            this.customer_id_label.Text = "customer_id_label";
            // 
            // adress_richTextBox
            // 
            this.adress_richTextBox.Location = new System.Drawing.Point(8, 539);
            this.adress_richTextBox.Name = "adress_richTextBox";
            this.adress_richTextBox.Size = new System.Drawing.Size(386, 50);
            this.adress_richTextBox.TabIndex = 28;
            this.adress_richTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightBlue;
            this.label4.Location = new System.Drawing.Point(5, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(389, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Введите адрес доставки";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightBlue;
            this.label5.Location = new System.Drawing.Point(5, 592);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(389, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Введите промокод";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // promo_code_textBox
            // 
            this.promo_code_textBox.Location = new System.Drawing.Point(8, 613);
            this.promo_code_textBox.Name = "promo_code_textBox";
            this.promo_code_textBox.Size = new System.Drawing.Size(288, 22);
            this.promo_code_textBox.TabIndex = 31;
            this.promo_code_textBox.Text = "SALE1";
            // 
            // promo_code_button
            // 
            this.promo_code_button.BackColor = System.Drawing.Color.SkyBlue;
            this.promo_code_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.promo_code_button.Location = new System.Drawing.Point(302, 613);
            this.promo_code_button.Name = "promo_code_button";
            this.promo_code_button.Size = new System.Drawing.Size(92, 23);
            this.promo_code_button.TabIndex = 32;
            this.promo_code_button.Text = "Найти";
            this.promo_code_button.UseVisualStyleBackColor = false;
            this.promo_code_button.Click += new System.EventHandler(this.promo_code_button_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightBlue;
            this.label6.Location = new System.Drawing.Point(5, 639);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(291, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Расчитать стоимость заказа";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // calculate_price_button
            // 
            this.calculate_price_button.BackColor = System.Drawing.Color.SkyBlue;
            this.calculate_price_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calculate_price_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculate_price_button.Location = new System.Drawing.Point(302, 636);
            this.calculate_price_button.Name = "calculate_price_button";
            this.calculate_price_button.Size = new System.Drawing.Size(92, 23);
            this.calculate_price_button.TabIndex = 34;
            this.calculate_price_button.Text = "Рассчитать";
            this.calculate_price_button.UseVisualStyleBackColor = false;
            this.calculate_price_button.Click += new System.EventHandler(this.calculate_price_button_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightBlue;
            this.label7.Location = new System.Drawing.Point(5, 663);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Цена";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // product_price_textBox
            // 
            this.product_price_textBox.Enabled = false;
            this.product_price_textBox.Location = new System.Drawing.Point(2, 683);
            this.product_price_textBox.Name = "product_price_textBox";
            this.product_price_textBox.Size = new System.Drawing.Size(69, 22);
            this.product_price_textBox.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightBlue;
            this.label8.Location = new System.Drawing.Point(77, 663);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 37;
            this.label8.Text = "Скидка";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sale_textBox
            // 
            this.sale_textBox.Enabled = false;
            this.sale_textBox.Location = new System.Drawing.Point(77, 682);
            this.sale_textBox.Name = "sale_textBox";
            this.sale_textBox.Size = new System.Drawing.Size(64, 22);
            this.sale_textBox.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.LightBlue;
            this.label9.Location = new System.Drawing.Point(231, 662);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 18);
            this.label9.TabIndex = 39;
            this.label9.Text = "Итоговая цена";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // end_price_textBox
            // 
            this.end_price_textBox.Enabled = false;
            this.end_price_textBox.Location = new System.Drawing.Point(231, 683);
            this.end_price_textBox.Name = "end_price_textBox";
            this.end_price_textBox.Size = new System.Drawing.Size(163, 22);
            this.end_price_textBox.TabIndex = 40;
            // 
            // order_button
            // 
            this.order_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.order_button.Location = new System.Drawing.Point(2, 710);
            this.order_button.Name = "order_button";
            this.order_button.Size = new System.Drawing.Size(392, 68);
            this.order_button.TabIndex = 41;
            this.order_button.Text = "ЗАКАЗАТЬ ТОВАР";
            this.order_button.UseVisualStyleBackColor = false;
            this.order_button.Click += new System.EventHandler(this.order_button_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightBlue;
            this.label10.Location = new System.Drawing.Point(147, 663);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 17);
            this.label10.TabIndex = 43;
            this.label10.Text = "Скидка %";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sale_in_percent_textBox
            // 
            this.sale_in_percent_textBox.Enabled = false;
            this.sale_in_percent_textBox.Location = new System.Drawing.Point(147, 683);
            this.sale_in_percent_textBox.Name = "sale_in_percent_textBox";
            this.sale_in_percent_textBox.Size = new System.Drawing.Size(83, 22);
            this.sale_in_percent_textBox.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LemonChiffon;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(400, 486);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(334, 31);
            this.label11.TabIndex = 45;
            this.label11.Text = "Отзыв на товар";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // get_reviews_button
            // 
            this.get_reviews_button.BackColor = System.Drawing.Color.LightSalmon;
            this.get_reviews_button.Location = new System.Drawing.Point(400, 520);
            this.get_reviews_button.Name = "get_reviews_button";
            this.get_reviews_button.Size = new System.Drawing.Size(334, 49);
            this.get_reviews_button.TabIndex = 47;
            this.get_reviews_button.Text = "Просмотреть отзывы на выбранный товар";
            this.get_reviews_button.UseVisualStyleBackColor = false;
            this.get_reviews_button.Click += new System.EventHandler(this.get_reviews_button_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.LightSalmon;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(740, 486);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1083, 219);
            this.dataGridView2.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.LemonChiffon;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(400, 572);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(334, 31);
            this.label12.TabIndex = 49;
            this.label12.Text = "Оставить отзыв";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(400, 613);
            this.trackBar2.Maximum = 500;
            this.trackBar2.Minimum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(333, 56);
            this.trackBar2.TabIndex = 50;
            this.trackBar2.Value = 500;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // score_textBox
            // 
            this.score_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score_textBox.Location = new System.Drawing.Point(651, 632);
            this.score_textBox.Name = "score_textBox";
            this.score_textBox.Size = new System.Drawing.Size(53, 24);
            this.score_textBox.TabIndex = 51;
            this.score_textBox.Text = "5,00";
            this.score_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.LemonChiffon;
            this.label13.Location = new System.Drawing.Point(426, 634);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 22);
            this.label13.TabIndex = 52;
            this.label13.Text = "Оценка";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.LemonChiffon;
            this.label14.Location = new System.Drawing.Point(405, 658);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(329, 22);
            this.label14.TabIndex = 53;
            this.label14.Text = "Отзыв";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // review_text_richTextBox
            // 
            this.review_text_richTextBox.Location = new System.Drawing.Point(405, 682);
            this.review_text_richTextBox.Name = "review_text_richTextBox";
            this.review_text_richTextBox.Size = new System.Drawing.Size(329, 57);
            this.review_text_richTextBox.TabIndex = 54;
            this.review_text_richTextBox.Text = "";
            // 
            // insert_review_button
            // 
            this.insert_review_button.BackColor = System.Drawing.Color.Gold;
            this.insert_review_button.Location = new System.Drawing.Point(405, 745);
            this.insert_review_button.Name = "insert_review_button";
            this.insert_review_button.Size = new System.Drawing.Size(328, 33);
            this.insert_review_button.TabIndex = 55;
            this.insert_review_button.Text = "ОСТАВИТЬ ОТЗЫВ";
            this.insert_review_button.UseVisualStyleBackColor = false;
            this.insert_review_button.Click += new System.EventHandler(this.insert_review_button_Click);
            // 
            // back_to_init_button
            // 
            this.back_to_init_button.BackColor = System.Drawing.Color.Crimson;
            this.back_to_init_button.Location = new System.Drawing.Point(740, 706);
            this.back_to_init_button.Name = "back_to_init_button";
            this.back_to_init_button.Size = new System.Drawing.Size(1081, 76);
            this.back_to_init_button.TabIndex = 132;
            this.back_to_init_button.Text = "Вернуться ко входу";
            this.back_to_init_button.UseVisualStyleBackColor = false;
            this.back_to_init_button.Click += new System.EventHandler(this.back_to_init_button_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1833, 781);
            this.Controls.Add(this.back_to_init_button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.insert_review_button);
            this.Controls.Add(this.review_text_richTextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.score_textBox);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.get_reviews_button);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.sale_in_percent_textBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.order_button);
            this.Controls.Add(this.end_price_textBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.sale_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.product_price_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.calculate_price_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.promo_code_button);
            this.Controls.Add(this.promo_code_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.adress_richTextBox);
            this.Controls.Add(this.customer_id_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.color_checkedListBox);
            this.Controls.Add(this.size_CheckBox);
            this.Controls.Add(this.get_products_button);
            this.Controls.Add(this.price_textBox);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.show_table_button);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.brand_checkedListBox);
            this.Name = "CustomerForm";
            this.Text = "Пользователь";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerForm_FormClosed);
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button show_table_button;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox price_textBox;
        private System.Windows.Forms.Button get_products_button;
        private System.Windows.Forms.CheckedListBox size_CheckBox;
        private System.Windows.Forms.CheckedListBox color_checkedListBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckedListBox brand_checkedListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton bolshe_radioButton;
        private System.Windows.Forms.RadioButton menshe_radioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label customer_id_label;
        private System.Windows.Forms.RichTextBox adress_richTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox promo_code_textBox;
        private System.Windows.Forms.Button promo_code_button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button calculate_price_button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox product_price_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox sale_textBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox end_price_textBox;
        private System.Windows.Forms.Button order_button;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox sale_in_percent_textBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button get_reviews_button;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TextBox score_textBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox review_text_richTextBox;
        private System.Windows.Forms.Button insert_review_button;
        private System.Windows.Forms.Button back_to_init_button;
    }
}