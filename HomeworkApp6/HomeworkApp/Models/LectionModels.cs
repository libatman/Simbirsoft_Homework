using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeworkApp.Models
{
    public class LectionModels
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Theme { get; set; }

        public List<AttendanceModels> attendanceModels { get; set; }
    }
}