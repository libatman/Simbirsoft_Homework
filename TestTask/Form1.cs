using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog main_file = new OpenFileDialog();
        OpenFileDialog dictionary_file = new OpenFileDialog();
        private void main_file_load_Click(object sender, EventArgs e) //загрузка файла (путь)
        {
            textBox1.Clear();
            main_file.Filter = "Text files (.txt,*.fb2,*.doc,*.docx,*.rtf,*.odt)|*.txt;*.fb2;*.doc;*.docx;*.rtf;*.odt";
            if (main_file.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = main_file.FileName;
            }
        }

        private void dictionary_file_button_Click(object sender, EventArgs e) // загрузка словаря (путь)
        {
            textBox2.Clear();
            dictionary_file.Filter = "Text files (.txt,*.fb2,*.doc,*.docx,*.rtf,*.odt)|*.txt;*.fb2;*.doc;*.docx;*.rtf;*.odt";
            if (dictionary_file.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dictionary_file.FileName;
            }
        }
        
        private void create_html_button_Click(object sender, EventArgs e) // создание самого файла
        {
            FileClass fileclass = new FileClass(); //класс, в котором происходит работа с файлами и записывается новый
            fileclass.Filepath = main_file.FileName; //передача в объект класса путей 2-ух файлов
            fileclass.Dictionarypath = dictionary_file.FileName;

            if (textBox3.Text == "") //если не введено ограничение на кол-во строк в сгенерированном файле
            {
                fileclass.N = 100000;
            }
            else
            {
                fileclass.N = Convert.ToInt32(textBox3.Text);
            }
            try
            {
                fileclass.ProcessFiles(); //вызов метода генерации файла
            }
            catch (Exception ex)
            {

            }
            if (fileclass.Dictionary_check) //если со словарем все в порядке, то оповестить
            {
                MessageBox.Show("Сделано!");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == Convert.ToChar(8))) //разрешен ввод только цифр
                e.KeyChar = (char)0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)0;
        }
    }
}
