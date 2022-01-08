using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstApp.Models
{
    public class Student
    {
        int id=0;
        public Student()
        {
            Id = ++this.id;
        }
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
    }
}
