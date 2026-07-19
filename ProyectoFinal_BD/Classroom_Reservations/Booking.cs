namespace Classroom_Booking
{
    public class Booking
    {
        public Classroom Classroom { get; set; }
        public Teacher Teacher { get; set; }
        public string Schedule { get; set; }

        public Booking(Classroom classroom, Teacher teacher, string schedule)
        {

            Classroom = classroom;
            Teacher = teacher;
            Schedule = schedule;
        }
    }
}
