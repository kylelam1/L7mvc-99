namespace ContosoUniversity.Models
{
    //tinfo200:[2021-03-11-kylelam-dykstra1] - we use an enum here because the grades are just a group of constants
    public enum Grade
    {
        A, B, C, D, F
    }

    //tinfo200:[2021-03-11-kylelam-dykstra1] - creating the enrollment entity. This helps to combine the student and the course entity into one
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        //tinfo200:[2021-03-11-kylelam-dykstra1] - With the ? mark, we can have a grade be a null. 
        public Grade? Grade { get; set; }
        public Student Student { get; set; }
    }
}