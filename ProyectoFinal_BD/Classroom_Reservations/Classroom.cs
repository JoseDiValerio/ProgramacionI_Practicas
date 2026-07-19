namespace Classroom_Booking
{
    public class Classroom
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Classroom(string code, string name, int capacity)
        {

            Code = code;
            Name = name;
            Capacity = capacity;
        }
    }
}