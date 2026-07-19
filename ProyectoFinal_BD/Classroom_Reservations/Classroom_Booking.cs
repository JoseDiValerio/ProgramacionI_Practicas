namespace Classroom_Booking
{
    public class ClassroomBooking
    {

        private List<Classroom> classroom = new List<Classroom>();
        private List<Teacher> teachers = new List<Teacher>();
        private List<Booking> booking = new List<Booking>();

        // Validation methods
        private string ReadName(string message)
        {

            string fact;

            do
            {
                Console.Write(message);

                fact = Console.ReadLine() ?? "";

                if (fact == "")
                {
                    Console.WriteLine("The data field cannot be left empty.");
                }

            } while (fact == "");

            return fact;
        }

        private int ReadNumber(string message)
        {

            int number;

            Console.Write(message);

            while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.Write("\nEnter an integer greater than 0: ");
            }

            return number;
        }

        private bool AddClassroomCode(string code)
        {

            foreach (Classroom classroom in classroom)
            {

                if (classroom.Code == code)
                {
                    return true;
                }
            }

            return false;
        }

        private bool EditClassroomCode(string code, Classroom currentClassroom)
        {

            foreach (Classroom classroom in classroom)
            {

                if (classroom != currentClassroom && classroom.Code == code)
                {
                    return true;
                }
            }

            return false;
        }

        private bool AddTeacherCode(string code)
        {

            foreach (Teacher teacher in teachers)
            {

                if (teacher.Code == code)
                {
                    return true;
                }
            }

            return false;
        }

        private bool EditTeacherCode(string code, Teacher currentProfessor)
        {

            foreach (Teacher teachers in teachers)
            {

                if (teachers != currentProfessor && teachers.Code == code)
                {
                    return true;
                }
            }

            return false;
        }

        // Main functions
        public void RegisterClassroom()
        {

            Console.Clear();

            string code, name;
            int capacity;

            Console.WriteLine("===== REGISTER CLASSROOM =====");

            do
            {
                Console.Write("\nCode: ");
                code = Console.ReadLine() ?? "";

                if (AddClassroomCode(code))
                {
                    Console.WriteLine("\nCode already exists.");
                }

            } while (AddClassroomCode(code));

            name = ReadName("\nName: ");

            capacity = ReadNumber("\nCapacity (students): ");

            Classroom newClassroom = new Classroom(code, name, capacity);

            classroom.Add(newClassroom);

            Console.WriteLine("\nClassroom successfully registered.");
            Console.ReadKey();
        }

        public void EditClassroom()
        {

            Console.Clear();

            Console.WriteLine("===== EDIT CLASSROOM =====");

            if (classroom.Count == 0)
            {
                Console.WriteLine("\nNo classrooms registered.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < classroom.Count; i++)
            {

                Console.WriteLine("\nClassroom (" + (i + 1) + ") " + "Code: " + classroom[i].Code + " - " + classroom[i].Name + " - "
                                    + "Capacity: " + classroom[i].Capacity + " students.");
            }

            int option;

            Console.Write("\nSelect the classroom number: ");

            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > classroom.Count)
            {
                Console.Write("\nInvalid option. Please try again: ");
            }

            Classroom classrooms = classroom[option - 1];

            string code, name;
            int capacity;

            do
            {
                Console.Write("\nNew code: ");
                code = Console.ReadLine() ?? "";

                if (EditClassroomCode(code, classrooms))
                {
                    Console.WriteLine("Code already exists.");
                }

            } while (EditClassroomCode(code, classrooms));

            name = ReadName("Name: ");

            capacity = ReadNumber("Capacity (students): ");

            classrooms.Code = code;
            classrooms.Name = name;
            classrooms.Capacity = capacity;

            Console.WriteLine("\nClassroom successfully edited.");
            Console.ReadKey();
        }

        public void ListClassrooms()
        {

            Console.Clear();

            Console.WriteLine("===== LIST OF CLASSROOMS =====");

            if (classroom.Count == 0)
            {
                Console.WriteLine("\nNo classrooms are registered.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < classroom.Count; i++)
            {

                Console.WriteLine("\nClassrooms #" + (i + 1));
                Console.WriteLine("\nCode: " + classroom[i].Code);
                Console.WriteLine("Name: " + classroom[i].Name);
                Console.WriteLine("Capacity (students): " + classroom[i].Capacity);
            }

            Console.ReadKey();
        }

        public void RegisterProfessor()
        {
            Console.Clear();

            Console.WriteLine("===== REGISTER TEACHER =====");

            string code, name;
            string subject;

            do
            {
                Console.Write("\nCode: ");
                code = Console.ReadLine() ?? "";

                if (AddTeacherCode(code))
                {
                    Console.WriteLine("\nCode already exists.");
                }

            } while (AddTeacherCode(code));

            name = ReadName("\nName: ");

            do
            {
                Console.Write("\nSubject: ");
                subject = Console.ReadLine() ?? "";

                if (subject == "")
                {
                    Console.WriteLine("You must enter a subject.");
                }

            } while (subject == "");

            Teacher newTeacher = new Teacher(code, name, subject);

            teachers.Add(newTeacher);

            Console.WriteLine("\nProfessor successfully registered.");
            Console.ReadKey();
        }

        public void EditProfessor()
        {

            Console.Clear();

            Console.WriteLine("===== EDIT TEACHER =====");

            if (teachers.Count == 0)
            {
                Console.WriteLine("\nThere are no registered teachers.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < teachers.Count; i++)
            {
                Console.WriteLine("\nTeacher: (" + (i + 1) + ") " + "Code: " + teachers[i].Code + " - " + "Name: " + teachers[i].Name +
                                  " - " + "Subject: " + teachers[i].Subject);
            }

            int option;

            Console.Write("\nSelect the teacher: ");

            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > teachers.Count)
            {
                Console.Write("\nInvalid option. Please try again: ");
            }

            Teacher teacher = teachers[option - 1];

            string code, name;
            string subject;

            do
            {
                Console.Write("\nNew code: ");
                code = Console.ReadLine() ?? "";

                if (EditTeacherCode(code, teacher))
                {
                    Console.WriteLine("\nCode already exists.");
                }

            } while (EditTeacherCode(code, teacher));

            name = ReadName("\nName: ");

            do
            {
                Console.Write("\nNew subject: ");
                subject = Console.ReadLine() ?? "";

                if (subject == "")
                {
                    Console.WriteLine("You must enter a subject.");
                }

            } while (subject == "");

            teacher.Code = code;
            teacher.Name = name;
            teacher.Subject = subject;

            Console.WriteLine("\nProfessor successfully updated.");
            Console.ReadKey();
        }

        public void ListProfessors()
        {

            Console.Clear();

            Console.WriteLine("===== LIST OF TEACHERS =====");

            if (teachers.Count == 0)
            {
                Console.WriteLine("\nThere are no registered teachers.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < teachers.Count; i++)
            {

                Console.WriteLine("\nTeacher#" + (i + 1));
                Console.WriteLine("\nCode: " + teachers[i].Code);
                Console.WriteLine("Name: " + teachers[i].Name);
                Console.WriteLine("Subject: " + teachers[i].Subject);
            }

            Console.ReadKey();
        }

        public void RegisterReservation()
        {

            Console.Clear();

            Console.WriteLine("===== REGISTER RESERVATION =====");

            if (classroom.Count == 0 && teachers.Count == 0)
            {
                Console.WriteLine("\nYou must register at least one classroom and one teacher.");
                Console.ReadKey();
                return;

            }
            else if (classroom.Count == 0)
            {
                Console.WriteLine("\nYou must register at least one classroom.");
                Console.ReadKey();
                return;

            }
            else if (teachers.Count == 0)
            {
                Console.WriteLine("\nYou must register at least one teacher.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nAVAILABLE CLASSROOMS\n");

            for (int i = 0; i < classroom.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + classroom[i].Name + " (" + classroom[i].Code + ")");
            }

            int optionClassroom;

            Console.Write("\nSelect a classroom: ");

            while (!int.TryParse(Console.ReadLine(), out optionClassroom) || optionClassroom < 1 || optionClassroom > classroom.Count)
            {
                Console.Write("\nSelect the correct classroom: ");
            }

            Console.WriteLine("\nAVAILABLE TEACHERS\n");

            for (int i = 0; i < teachers.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + teachers[i].Name + " - " + "Subject: " + teachers[i].Subject);
            }

            int teacherOption;

            Console.Write("\nSelect a teacher: ");

            while (!int.TryParse(Console.ReadLine(), out teacherOption) || teacherOption < 1 || teacherOption > teachers.Count)
            {
                Console.Write("\nSelect the correct teacher: ");
            }

            string schedule;

            do
            {
                Console.Write("\nRESERVATION HOURS: ");
                schedule = Console.ReadLine() ?? "";

                if (schedule == "")
                {
                    Console.WriteLine("You must enter the schedule..");
                }

            } while (schedule == "");

            Booking newReservation = new Booking(classroom[optionClassroom - 1], teachers[teacherOption - 1], schedule);

            booking.Add(newReservation);

            Console.WriteLine("\nReservation successfully recorded.");
            Console.ReadKey();
        }

        public void EditReservation()
        {

            Console.Clear();

            Console.WriteLine("===== EDIT RESERVATION =====");

            if (booking.Count == 0)
            {
                Console.WriteLine("\nThere are no recorded reservations.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nREGISTERED RESERVATIONS\n");

            for (int i = 0; i < booking.Count; i++)
            {

                Console.WriteLine((i + 1) + ". " + booking[i].Teacher.Name + " - " + booking[i].Classroom.Name + " - ("
                                    + booking[i].Teacher.Subject + ") - " + booking[i].Schedule);
            }

            int reservationOption;

            Console.Write("\nSelect the reservation: ");

            while (!int.TryParse(Console.ReadLine(), out reservationOption) || reservationOption < 1 || reservationOption > booking.Count)
            {
                Console.Write("\nSelect the correct reservation: ");
            }

            Booking bookings = booking[reservationOption - 1];

            Console.WriteLine("\nCLASSROOMS\n");

            for (int i = 0; i < classroom.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + classroom[i].Name);
            }

            int optionClassroom;

            Console.Write("\nSelect a classroom: ");

            while (!int.TryParse(Console.ReadLine(), out optionClassroom) || optionClassroom < 1 || optionClassroom > classroom.Count)
            {
                Console.Write("\nSelect the correct classroom: ");
            }

            Console.WriteLine("\nTEACHERS\n");

            for (int i = 0; i < teachers.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + teachers[i].Name);
            }

            int teacherOption;

            Console.Write("\nSelect a teacher: ");

            while (!int.TryParse(Console.ReadLine(), out teacherOption) || teacherOption < 1 || teacherOption > teachers.Count)
            {
                Console.Write("\nSelect the correct teacher: ");
            }

            string schedule;

            do
            {

                Console.Write("\nNEW SCHEDULE: ");
                schedule = Console.ReadLine() ?? "";

                if (schedule == "")
                {
                    Console.WriteLine("You must enter the schedule.");
                }

            } while (schedule == "");

            bookings.Classroom = classroom[optionClassroom - 1];
            bookings.Teacher = teachers[teacherOption - 1];
            bookings.Schedule = schedule;

            Console.WriteLine("\nReservation successfully updated.");
            Console.ReadKey();
        }

        public void ListReservations()
        {

            Console.Clear();

            Console.WriteLine("===== LIST OF RESERVATIONS =====");

            if (booking.Count == 0)
            {
                Console.WriteLine("\nThere are no reservations.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < booking.Count; i++)
            {

                Console.WriteLine("\nBooking #" + (i + 1));
                Console.WriteLine("\nTeacher : " + booking[i].Teacher.Name);
                Console.WriteLine("Classroom     : " + booking[i].Classroom.Name);
                Console.WriteLine("Subject  : " + booking[i].Teacher.Subject);
                Console.WriteLine("Schedule  : " + booking[i].Schedule);
            }

            Console.ReadKey();
        }
    }
}
