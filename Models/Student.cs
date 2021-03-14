using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    //tinfo200:[2021-03-11-kylelam-dykstra1] - creating the student entity, the database of students and all the features of a student. 
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        //tinfo200:[2021-03-11-kylelam-dykstra1] - This holds other entities that are closely realted to this one. This also shows that this is a list, that is how enrollment is working. 
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
