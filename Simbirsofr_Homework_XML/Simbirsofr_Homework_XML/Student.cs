using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Simbirsofr_Homework_XML
{
    public class Student
    {
        public Student(string name, string course, string specialty)
        {
            name_st = name;
            course_st = course;
            specialty_st = specialty;
        }
        public Student() { }
        string name_st;
        string course_st;
        string specialty_st;
        public string Name_student {
            get
            { return name_st; }
            set
            { name_st = value; }
        }
        public string Course_student {
            get
            { return course_st; }
            set
            { course_st = value; }
        }
        public string Specialty {
            get
            { return specialty_st; }
            set
            { specialty_st = value; }
        }

        
    }

    public class List_of_students
    {
        public List_of_students() 
        {
 
        }
        public List<Student> listStudents;
    }
}
