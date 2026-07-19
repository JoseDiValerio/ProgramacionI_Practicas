namespace Classroom_Booking
{
    public class Teacher {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

        public Teacher(string code, string name, string subject) {
            
            Code = code;
            Name = name;
            Subject = subject;
        }
    }
}
