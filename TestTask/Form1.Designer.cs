namespace TestTask
{
    partial class Form1
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
            this.main_file_load = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dictionary_file_button = new System.Windows.Forms.Button();
            this.create_html_button = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // main_file_load
            // 
            this.main_file_load.BackColor = System.Drawing.Color.Azure;
            this.main_file_load.Location = new System.Drawing.Point(12, 13);
            this.main_file_load.Name = "main_file_load";
            this.main_file_load.Size = new System.Drawing.Size(150, 30);
            this.main_file_load.TabIndex = 0;
            this.main_file_load.Text = "Загрузить файл";
            this.main_file_load.UseVisualStyleBackColor = false;
            this.main_file_load.Click += new System.EventHandler(this.main_file_load_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(169, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(446, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(169, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(446, 23);
            this.textBox2.TabIndex = 3;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // dictionary_file_button
            // 
            this.dictionary_file_button.BackColor = System.Drawing.Color.Azure;
            this.dictionary_file_button.Location = new System.Drawing.Point(12, 54);
            this.dictionary_file_button.Name = "dictionary_file_button";
            this.dictionary_file_button.Size = new System.Drawing.Size(150, 30);
            this.dictionary_file_button.TabIndex = 2;
            this.dictionary_file_button.Text = "Загрузить словарь";
            this.dictionary_file_button.UseVisualStyleBackColor = false;
            this.dictionary_file_button.Click += new System.EventHandler(this.dictionary_file_button_Click);
            // 
            // create_html_button
            // 
            this.create_html_button.BackColor = System.Drawing.Color.Azure;
            this.create_html_button.Location = new System.Drawing.Point(397, 102);
            this.create_html_button.Name = "create_html_button";
            this.create_html_button.Size = new System.Drawing.Size(217, 30);
            this.create_html_button.TabIndex = 4;
            this.create_html_button.Text = "Создать html-файл";
            this.create_html_button.UseVisualStyleBackColor = false;
            this.create_html_button.Click += new System.EventHandler(this.create_html_button_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(232, 102);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(93, 23);
            this.textBox3.TabIndex = 5;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Максимальное кол-во строк";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(651, 144);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.create_html_button);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dictionary_file_button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.main_file_load);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form1";
            this.Text = "Генерация файла";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button main_file_load;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button dictionary_file_button;
        private System.Windows.Forms.Button create_html_button;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
    }
}

