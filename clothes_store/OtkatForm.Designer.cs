namespace clothes_store
{
    partial class OtkatForm
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
            this.otkat_tables_listBox = new System.Windows.Forms.ListBox();
            this.otkat_dataGridView = new System.Windows.Forms.DataGridView();
            this.show_otkat_tables_button = new System.Windows.Forms.Button();
            this.stuff_otkat_button = new System.Windows.Forms.Button();
            this.products_otkat_button = new System.Windows.Forms.Button();
            this.customers_otkat_button = new System.Windows.Forms.Button();
            this.booking_otkat_button = new System.Windows.Forms.Button();
            this.delete_otkat_button = new System.Windows.Forms.Button();
            this.formated_out_booking_button = new System.Windows.Forms.Button();
            this.formated_out_products_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.otkat_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // otkat_tables_listBox
            // 
            this.otkat_tables_listBox.BackColor = System.Drawing.Color.LightSalmon;
            this.otkat_tables_listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.otkat_tables_listBox.FormattingEnabled = true;
            this.otkat_tables_listBox.ItemHeight = 25;
            this.otkat_tables_listBox.Items.AddRange(new object[] {
            "booking_otkat",
            "customers_otkat",
            "list_of_products_otkat",
            "stuff_otkat"});
            this.otkat_tables_listBox.Location = new System.Drawing.Point(12, 13);
            this.otkat_tables_listBox.Name = "otkat_tables_listBox";
            this.otkat_tables_listBox.Size = new System.Drawing.Size(276, 104);
            this.otkat_tables_listBox.TabIndex = 0;
            this.otkat_tables_listBox.SelectedIndexChanged += new System.EventHandler(this.otkat_tables_listBox_SelectedIndexChanged);
            // 
            // otkat_dataGridView
            // 
            this.otkat_dataGridView.BackgroundColor = System.Drawing.Color.Coral;
            this.otkat_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otkat_dataGridView.Location = new System.Drawing.Point(294, 13);
            this.otkat_dataGridView.Name = "otkat_dataGridView";
            this.otkat_dataGridView.RowHeadersWidth = 51;
            this.otkat_dataGridView.RowTemplate.Height = 24;
            this.otkat_dataGridView.Size = new System.Drawing.Size(1052, 425);
            this.otkat_dataGridView.TabIndex = 1;
            // 
            // show_otkat_tables_button
            // 
            this.show_otkat_tables_button.BackColor = System.Drawing.Color.Coral;
            this.show_otkat_tables_button.Location = new System.Drawing.Point(13, 123);
            this.show_otkat_tables_button.Name = "show_otkat_tables_button";
            this.show_otkat_tables_button.Size = new System.Drawing.Size(275, 56);
            this.show_otkat_tables_button.TabIndex = 2;
            this.show_otkat_tables_button.Text = "Выбор таблицы для отката";
            this.show_otkat_tables_button.UseVisualStyleBackColor = false;
            this.show_otkat_tables_button.Click += new System.EventHandler(this.show_okkat_tables_button_Click);
            // 
            // stuff_otkat_button
            // 
            this.stuff_otkat_button.BackColor = System.Drawing.Color.CadetBlue;
            this.stuff_otkat_button.Enabled = false;
            this.stuff_otkat_button.Location = new System.Drawing.Point(13, 185);
            this.stuff_otkat_button.Name = "stuff_otkat_button";
            this.stuff_otkat_button.Size = new System.Drawing.Size(275, 45);
            this.stuff_otkat_button.TabIndex = 3;
            this.stuff_otkat_button.Text = "Откат РАБОТНИКОВ";
            this.stuff_otkat_button.UseVisualStyleBackColor = false;
            this.stuff_otkat_button.Click += new System.EventHandler(this.stuff_otkat_button_Click);
            // 
            // products_otkat_button
            // 
            this.products_otkat_button.BackColor = System.Drawing.Color.CadetBlue;
            this.products_otkat_button.Enabled = false;
            this.products_otkat_button.Location = new System.Drawing.Point(12, 338);
            this.products_otkat_button.Name = "products_otkat_button";
            this.products_otkat_button.Size = new System.Drawing.Size(128, 45);
            this.products_otkat_button.TabIndex = 4;
            this.products_otkat_button.Text = "Откат ТОВАРОВ";
            this.products_otkat_button.UseVisualStyleBackColor = false;
            this.products_otkat_button.Click += new System.EventHandler(this.products_otkat_button_Click);
            // 
            // customers_otkat_button
            // 
            this.customers_otkat_button.BackColor = System.Drawing.Color.CadetBlue;
            this.customers_otkat_button.Enabled = false;
            this.customers_otkat_button.Location = new System.Drawing.Point(12, 236);
            this.customers_otkat_button.Name = "customers_otkat_button";
            this.customers_otkat_button.Size = new System.Drawing.Size(276, 45);
            this.customers_otkat_button.TabIndex = 5;
            this.customers_otkat_button.Text = "Откат ПОЛЬЗОВАТЕЛЕЙ";
            this.customers_otkat_button.UseVisualStyleBackColor = false;
            this.customers_otkat_button.Click += new System.EventHandler(this.customers_otkat_button_Click);
            // 
            // booking_otkat_button
            // 
            this.booking_otkat_button.BackColor = System.Drawing.Color.CadetBlue;
            this.booking_otkat_button.Enabled = false;
            this.booking_otkat_button.Location = new System.Drawing.Point(12, 287);
            this.booking_otkat_button.Name = "booking_otkat_button";
            this.booking_otkat_button.Size = new System.Drawing.Size(128, 45);
            this.booking_otkat_button.TabIndex = 6;
            this.booking_otkat_button.Text = "Откат ЗАКАЗОВ";
            this.booking_otkat_button.UseVisualStyleBackColor = false;
            this.booking_otkat_button.Click += new System.EventHandler(this.booking_otkat_button_Click);
            // 
            // delete_otkat_button
            // 
            this.delete_otkat_button.BackColor = System.Drawing.Color.Red;
            this.delete_otkat_button.Location = new System.Drawing.Point(13, 389);
            this.delete_otkat_button.Name = "delete_otkat_button";
            this.delete_otkat_button.Size = new System.Drawing.Size(274, 49);
            this.delete_otkat_button.TabIndex = 7;
            this.delete_otkat_button.Text = "Удалить данные из темпоральной таблицы";
            this.delete_otkat_button.UseVisualStyleBackColor = false;
            this.delete_otkat_button.Click += new System.EventHandler(this.delete_otkat_button_Click);
            // 
            // formated_out_booking_button
            // 
            this.formated_out_booking_button.BackColor = System.Drawing.Color.Gold;
            this.formated_out_booking_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formated_out_booking_button.Location = new System.Drawing.Point(147, 288);
            this.formated_out_booking_button.Name = "formated_out_booking_button";
            this.formated_out_booking_button.Size = new System.Drawing.Size(141, 44);
            this.formated_out_booking_button.TabIndex = 8;
            this.formated_out_booking_button.Text = "Форматированнный вывод заказов ";
            this.formated_out_booking_button.UseVisualStyleBackColor = false;
            this.formated_out_booking_button.Click += new System.EventHandler(this.formated_out_booking_button_Click);
            // 
            // formated_out_products_button
            // 
            this.formated_out_products_button.BackColor = System.Drawing.Color.Gold;
            this.formated_out_products_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formated_out_products_button.Location = new System.Drawing.Point(146, 338);
            this.formated_out_products_button.Name = "formated_out_products_button";
            this.formated_out_products_button.Size = new System.Drawing.Size(141, 44);
            this.formated_out_products_button.TabIndex = 9;
            this.formated_out_products_button.Text = "Форматированнный вывод товаров";
            this.formated_out_products_button.UseVisualStyleBackColor = false;
            this.formated_out_products_button.Click += new System.EventHandler(this.formated_out_products_button_Click);
            // 
            // OtkatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 450);
            this.Controls.Add(this.formated_out_products_button);
            this.Controls.Add(this.formated_out_booking_button);
            this.Controls.Add(this.delete_otkat_button);
            this.Controls.Add(this.booking_otkat_button);
            this.Controls.Add(this.customers_otkat_button);
            this.Controls.Add(this.products_otkat_button);
            this.Controls.Add(this.stuff_otkat_button);
            this.Controls.Add(this.show_otkat_tables_button);
            this.Controls.Add(this.otkat_dataGridView);
            this.Controls.Add(this.otkat_tables_listBox);
            this.Name = "OtkatForm";
            this.Text = "Откат транзакций";
            ((System.ComponentModel.ISupportInitialize)(this.otkat_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox otkat_tables_listBox;
        private System.Windows.Forms.DataGridView otkat_dataGridView;
        private System.Windows.Forms.Button show_otkat_tables_button;
        private System.Windows.Forms.Button stuff_otkat_button;
        private System.Windows.Forms.Button products_otkat_button;
        private System.Windows.Forms.Button customers_otkat_button;
        private System.Windows.Forms.Button booking_otkat_button;
        private System.Windows.Forms.Button delete_otkat_button;
        private System.Windows.Forms.Button formated_out_booking_button;
        private System.Windows.Forms.Button formated_out_products_button;
    }
}