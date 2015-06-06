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
using System.Xml.Serialization;

namespace Simbirsofr_Homework_XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List_of_students listS = new List_of_students();
        private void button1_Click(object sender, EventArgs e)
        {
            listS.listStudents = list2;
            serList(listS);
            MessageBox.Show("Done!");
        }
        List<Student> list2 = new List<Student>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Student student = new Student("Иванов Иван", "2", "Программная инженерия");
            list2.Add(student);
            student = new Student("Петров Петр", "1", "Управление персоналом");
            list2.Add(student);
            student = new Student("Роберт Чейз", "1", "Кардиология");
            list2.Add(student);
            student = new Student("Грегори Хаус", "4", "Неврология");
            list2.Add(student);
            student = new Student("Эрик Форман", "1", "Венерология");
            list2.Add(student);
            student = new Student("Элисон Кэмерон", "3", "Лечебное дело");
            list2.Add(student);
            student = new Student("Сидоров Алексей", "1", "Приборостроение");
            list2.Add(student);
            student = new Student("Алехин Валентин", " 2", "Налоги");
            list2.Add(student);
            student = new Student("Сонин Артем", "1", "Бизнес-информатика");
            list2.Add(student);
            student = new Student("Самолина Екатерина", "4", "Гостиничное дело");
            list2.Add(student);
            for (int i = 0; i < list2.Count; i++)
            {
                listBox1.Items.Add(list2[i].Name_student + ". " + list2[i].Course_student + ". " + list2[i].Specialty);
            }
        }

        private void serList(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            FileStream f = new FileStream("file.xml", FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(f))
            {
                serializer.Serialize(sw, obj);
            }
        }
    }
}
