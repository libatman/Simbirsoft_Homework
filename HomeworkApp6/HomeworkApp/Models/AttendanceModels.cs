using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeworkApp.Models
{
    public class AttendanceModels
    {
        public int Id { get; set; }
        public int NumberStudents { get; set; }
        public int IdLection { get; set; }

        public LectionModels lectionModels { get; set; }

        [NotMapped]
        public string ThemeLection { get; set; }  
    }
}