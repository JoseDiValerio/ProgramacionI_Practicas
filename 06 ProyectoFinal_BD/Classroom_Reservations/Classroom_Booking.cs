using Microsoft.Data.SqlClient;

namespace Classroom_Booking
{
    public class ClassroomBooking
    {

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
            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = "SELECT COUNT(*) FROM Classroom WHERE Code = @Code";

                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@Code", code);

                    int cantidad = (int)cmd.ExecuteScalar();

                    return cantidad > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private bool EditClassroomCode(string newCode, string selectedCode)
        {
            try
            {
                if (newCode == selectedCode)
                {
                    return false;
                }

                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = "SELECT COUNT(*) FROM Classroom WHERE Code = @Code";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@Code", newCode);

                    int cantidad = (int)cmd.ExecuteScalar();

                    return cantidad > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool AddTeacherCode(string code)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "SELECT COUNT(*) FROM Teacher WHERE Code = @Code";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Code", code);

                int total = (int)cmd.ExecuteScalar();

                return total > 0;
            }
        }

        private bool EditTeacherCode(string newCode, string selectedCode)
        {
            try
            {
                if (newCode == selectedCode)
                {
                    return false;
                }

                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = "SELECT COUNT(*) FROM Teacher WHERE Code = @Code";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@Code", newCode);

                    int cantidad = (int)cmd.ExecuteScalar();

                    return cantidad > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        // Public functions
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

                if (code.Trim() == "")
                {
                    Console.WriteLine("\nThe code cannot be empty.");
                }
                else if (AddClassroomCode(code))
                {
                    Console.WriteLine("\nCode already exists.");
                }

            } while (code.Trim() == "" || AddClassroomCode(code));

            name = ReadName("\nName: ");

            capacity = ReadNumber("\nCapacity (students): ");

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"INSERT INTO Classroom (Code, Name, Capacity)
                           VALUES (@Code, @Name, @Capacity)";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@Code", code);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Capacity", capacity);

                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("\nClassroom successfully registered.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError registering classroom.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public void EditClassroom()
        {

            Console.Clear();

            Console.WriteLine("===== EDIT CLASSROOM =====");

            List<string> classroomCodes = new List<string>();

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = "SELECT Code, Name, Capacity FROM Classroom";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("\nNo classrooms registered.");
                        Console.ReadKey();
                        return;
                    }

                    int i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine("\nClassroom (" + i + ")");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Code: " + reader["Code"]);
                        Console.WriteLine("Name: " + reader["Name"]);
                        Console.WriteLine("Capacity: " + reader["Capacity"] + " students.");

                        string classroomCode = Convert.ToString(reader["Code"]) ?? "";
                        classroomCodes.Add(classroomCode);

                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError.");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            int option;

            Console.Write("\nSelect the classroom number: ");

            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > classroomCodes.Count)
            {
                Console.Write("\nInvalid option. Please try again: ");
            }

            string selectedCode = classroomCodes[option - 1];

            string code, name;
            int capacity;

            do
            {
                Console.Write("\nNew code: ");
                code = Console.ReadLine() ?? "";

                if (EditClassroomCode(code, selectedCode))
                {
                    Console.WriteLine("Code already exists.");
                }

            } while (EditClassroomCode(code, selectedCode));

            name = ReadName("Name: ");

            capacity = ReadNumber("Capacity (students): ");

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"UPDATE Classroom
                       SET Code = @NewCode,
                           Name = @Name,
                           Capacity = @Capacity
                       WHERE Code = @SelectedCode";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@NewCode", code);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Capacity", capacity);
                    cmd.Parameters.AddWithValue("@SelectedCode", selectedCode);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        Console.WriteLine("\nClassroom successfully edited.");
                    }
                    else
                    {
                        Console.WriteLine("\nThe classroom could not be found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError editing classroom.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public void ListClassrooms()
        {

            Console.Clear();

            Console.WriteLine("===== LIST OF CLASSROOMS =====");

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = "SELECT Code, Name, Capacity FROM Classroom";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("\nNo classrooms are registered.");
                        Console.ReadKey();
                        return;
                    }

                    int i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine("\nClassroom #" + i);
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Code: " + reader["Code"]);
                        Console.WriteLine("Name: " + reader["Name"]);
                        Console.WriteLine("Capacity (students): " + reader["Capacity"]);

                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError listing classrooms.");
                Console.WriteLine(ex.Message);
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

                if (code.Trim() == "")
                {
                    Console.WriteLine("\nThe code cannot be empty.");
                }
                else if (AddTeacherCode(code))
                {
                    Console.WriteLine("\nCode already exists.");
                }

            } while (code.Trim() == "" || AddTeacherCode(code));

            name = ReadName("\nName: ");

            do
            {
                Console.Write("\nSubject: ");
                subject = Console.ReadLine() ?? "";

                if (subject.Trim() == "")
                {
                    Console.WriteLine("\nYou must enter a subject.");
                }

            } while (subject.Trim() == "");

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"INSERT INTO Teacher (Code, Name, Subject)
                           VALUES (@Code, @Name, @Subject)";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@Code", code);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Subject", subject);

                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("\nProfessor successfully registered.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError registering professor.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public void EditProfessor()
        {
            Console.Clear();

            Console.WriteLine("===== EDIT TEACHER =====");

            List<string> teacherCodes = new List<string>();

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = "SELECT Code, Name, Subject FROM Teacher";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("\nThere are no registered teachers.");
                        Console.ReadKey();
                        return;
                    }

                    int i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine("\nTeacher (" + i + ")");
                        Console.WriteLine("---------------------------");
                        Console.WriteLine("Code: " + reader["Code"]);
                        Console.WriteLine("Name: " + reader["Name"]);
                        Console.WriteLine("Subject: " + reader["Subject"]);

                        string teacherCode = Convert.ToString(reader["Code"]) ?? "";
                        teacherCodes.Add(teacherCode);

                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError loading teachers.");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            int option;

            Console.Write("\nSelect the teacher: ");

            while (!int.TryParse(Console.ReadLine(), out option) ||
                   option < 1 ||
                   option > teacherCodes.Count)
            {
                Console.Write("\nInvalid option. Please try again: ");
            }

            string selectedCode = teacherCodes[option - 1];

            string code, name, subject;

            do
            {
                Console.Write("\nNew code: ");
                code = Console.ReadLine() ?? "";

                if (code.Trim() == "")
                {
                    Console.WriteLine("\nThe code cannot be empty.");
                }
                else if (EditTeacherCode(code, selectedCode))
                {
                    Console.WriteLine("\nCode already exists.");
                }

            } while (code.Trim() == "" || EditTeacherCode(code, selectedCode));

            name = ReadName("\nName: ");

            do
            {
                Console.Write("\nNew subject: ");
                subject = Console.ReadLine() ?? "";

                if (subject.Trim() == "")
                {
                    Console.WriteLine("\nYou must enter a subject.");
                }

            } while (subject.Trim() == "");

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"UPDATE Teacher
                           SET Code = @NewCode,
                               Name = @Name,
                               Subject = @Subject
                           WHERE Code = @SelectedCode";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@NewCode", code);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Subject", subject);
                    cmd.Parameters.AddWithValue("@SelectedCode", selectedCode);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        Console.WriteLine("\nProfessor successfully updated.");
                    }
                    else
                    {
                        Console.WriteLine("\nTeacher not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError updating teacher.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public void ListProfessors()
        {
            Console.Clear();

            Console.WriteLine("===== LIST OF TEACHERS =====");

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = "SELECT Code, Name, Subject FROM Teacher";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("\nThere are no registered teachers.");
                        Console.ReadKey();
                        return;
                    }

                    int i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine("\nTeacher #" + i);
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Code: " + reader["Code"]);
                        Console.WriteLine("Name: " + reader["Name"]);
                        Console.WriteLine("Subject: " + reader["Subject"]);

                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError listing teachers.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public void RegisterReservation()
        {
            Console.Clear();

            Console.WriteLine("===== REGISTER RESERVATION =====");

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sqlClassroom = "SELECT COUNT(*) FROM Classroom";

                    SqlCommand cmdClassroom = new SqlCommand(sqlClassroom, cn);

                    int totalClassrooms = (int)cmdClassroom.ExecuteScalar();

                    string sqlTeacher = "SELECT COUNT(*) FROM Teacher";

                    SqlCommand cmdTeacher = new SqlCommand(sqlTeacher, cn);

                    int totalTeachers = (int)cmdTeacher.ExecuteScalar();

                    if (totalClassrooms == 0 && totalTeachers == 0)
                    {
                        Console.WriteLine("\nYou must register at least one classroom and one teacher.");
                        Console.ReadKey();
                        return;
                    }
                    else if (totalClassrooms == 0)
                    {
                        Console.WriteLine("\nYou must register at least one classroom.");
                        Console.ReadKey();
                        return;
                    }
                    else if (totalTeachers == 0)
                    {
                        Console.WriteLine("\nYou must register at least one teacher.");
                        Console.ReadKey();
                        return;
                    }

                    List<string> classroomCodes = new List<string>();

                    Console.WriteLine("\nAVAILABLE CLASSROOMS\n");

                    string sql = "SELECT Code, Name FROM Classroom";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    int i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine(i + ". " + reader["Name"] + " (" + reader["Code"] + ")");

                        classroomCodes.Add(Convert.ToString(reader["Code"]) ?? "");

                        i++;
                    }

                    reader.Close();

                    int optionClassroom;

                    Console.Write("\nSelect a classroom: ");

                    while (!int.TryParse(Console.ReadLine(), out optionClassroom) || optionClassroom < 1 || optionClassroom > classroomCodes.Count)
                    {
                        Console.Write("\nSelect the correct classroom: ");
                    }

                    List<string> teacherCodes = new List<string>();

                    Console.WriteLine("\nAVAILABLE TEACHERS\n");

                    string sqlTeacherList = "SELECT Code, Name, Subject FROM Teacher";

                    SqlCommand cmdTeacherList = new SqlCommand(sqlTeacherList, cn);

                    reader = cmdTeacherList.ExecuteReader();

                    i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine(i + ". " +
                                          reader["Name"] +
                                          " - Subject: " +
                                          reader["Subject"]);

                        teacherCodes.Add(Convert.ToString(reader["Code"]) ?? "");

                        i++;
                    }

                    reader.Close();

                    int teacherOption;

                    Console.Write("\nSelect a teacher: ");

                    while (!int.TryParse(Console.ReadLine(), out teacherOption) || teacherOption < 1 || teacherOption > teacherCodes.Count)
                    {
                        Console.Write("\nSelect the correct teacher: ");
                    }

                    string schedule;

                    do
                    {
                        Console.Write("\nRESERVATION HOURS: ");
                        schedule = Console.ReadLine() ?? "";

                        if (schedule.Trim() == "")
                        {
                            Console.WriteLine("You must enter the schedule.");
                        }

                    } while (schedule.Trim() == "");

                    string classroomCode = classroomCodes[optionClassroom - 1];

                    string teacherCode = teacherCodes[teacherOption - 1];

                    string sqlInsert = @"INSERT INTO Booking (ClassroomCode, TeacherCode, Schedule)
                                       VALUES (@ClassroomCode, @TeacherCode, @Schedule)";

                    SqlCommand cmdInsert = new SqlCommand(sqlInsert, cn);

                    cmdInsert.Parameters.AddWithValue("@ClassroomCode", classroomCode);
                    cmdInsert.Parameters.AddWithValue("@TeacherCode", teacherCode);
                    cmdInsert.Parameters.AddWithValue("@Schedule", schedule);

                    cmdInsert.ExecuteNonQuery();

                    Console.WriteLine("\nReservation successfully recorded.");
                    Console.ReadKey();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("\nError registering the reservation.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public void EditReservation()
        {
            Console.Clear();

            Console.WriteLine("===== EDIT RESERVATION =====");

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = "SELECT COUNT(*) FROM Booking";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    int totalReservations = (int)cmd.ExecuteScalar();

                    if (totalReservations == 0)
                    {
                        Console.WriteLine("\nThere are no recorded reservations.");
                        Console.ReadKey();
                        return;
                    }

                    List<int> bookingIds = new List<int>();

                    Console.WriteLine("\nREGISTERED RESERVATIONS\n");

                    string sqlReservations = @" SELECT B.BookingId, T.Name AS Teacher, C.Name AS Classroom, T.Subject, B.Schedule FROM Booking B
                                                INNER JOIN Teacher T
                                                ON B.TeacherCode = T.Code
                                                INNER JOIN Classroom C
                                                ON B.ClassroomCode = C.Code";

                    SqlCommand cmdReservations = new SqlCommand(sqlReservations, cn);

                    SqlDataReader reader = cmdReservations.ExecuteReader();

                    int i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine(i + ". " + reader["Teacher"] + " - " + reader["Classroom"] + " - (" + reader["Subject"] + ") - " + reader["Schedule"]);

                        bookingIds.Add((int)reader["BookingId"]);

                        i++;
                    }

                    reader.Close();

                    int reservationOption;

                    Console.Write("\nSelect the reservation: ");

                    while (!int.TryParse(Console.ReadLine(), out reservationOption) || reservationOption < 1 || reservationOption > bookingIds.Count)
                    {
                        Console.Write("Select the correct reservation: ");
                    }

                    int bookingId = bookingIds[reservationOption - 1];

                    List<string> classroomCodes = new List<string>();

                    Console.WriteLine("\nAVAILABLE CLASSROOMS\n");

                    string sqlClassrooms = "SELECT Code, Name FROM Classroom";

                    SqlCommand cmdClassrooms = new SqlCommand(sqlClassrooms, cn);

                    reader = cmdClassrooms.ExecuteReader();

                    i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine(i + ". " + reader["Name"] + " (" + reader["Code"] + ")");

                        classroomCodes.Add(Convert.ToString(reader["Code"]) ?? "");

                        i++;
                    }

                    reader.Close();

                    int optionClassroom;

                    Console.Write("\nSelect a classroom: ");

                    while (!int.TryParse(Console.ReadLine(), out optionClassroom) || optionClassroom < 1 || optionClassroom > classroomCodes.Count)
                    {
                        Console.Write("Select the correct classroom: ");
                    }

                    string classroomCode = classroomCodes[optionClassroom - 1];

                    List<string> teacherCodes = new List<string>();

                    Console.WriteLine("\nAVAILABLE TEACHERS\n");

                    string sqlTeachers = "SELECT Code, Name, Subject FROM Teacher";

                    SqlCommand cmdTeachers = new SqlCommand(sqlTeachers, cn);

                    reader = cmdTeachers.ExecuteReader();

                    i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine(i + ". " + reader["Name"] + " - Subject: " + reader["Subject"]);

                        teacherCodes.Add(Convert.ToString(reader["Code"]) ?? "");

                        i++;
                    }

                    reader.Close();

                    int teacherOption;

                    Console.Write("\nSelect a teacher: ");

                    while (!int.TryParse(Console.ReadLine(), out teacherOption) || teacherOption < 1 || teacherOption > teacherCodes.Count)
                    {
                        Console.Write("Select the correct teacher: ");
                    }

                    string teacherCode = teacherCodes[teacherOption - 1];

                    string schedule;

                    do
                    {
                        Console.Write("\nNEW SCHEDULE: ");
                        schedule = Console.ReadLine() ?? "";

                        if (schedule.Trim() == "")
                        {
                            Console.WriteLine("You must enter the schedule.");
                        }

                    } while (schedule.Trim() == "");

                    string sqlUpdate = @"UPDATE Booking SET ClassroomCode = @ClassroomCode, TeacherCode = @TeacherCode, Schedule = @Schedule
                                        WHERE BookingId = @BookingId";

                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, cn);

                    cmdUpdate.Parameters.AddWithValue("@ClassroomCode", classroomCode);
                    cmdUpdate.Parameters.AddWithValue("@TeacherCode", teacherCode);
                    cmdUpdate.Parameters.AddWithValue("@Schedule", schedule);
                    cmdUpdate.Parameters.AddWithValue("@BookingId", bookingId);

                    int rows = cmdUpdate.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        Console.WriteLine("\nReservation successfully updated.");
                    }
                    else
                    {
                        Console.WriteLine("\nReservation not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError editing the reservation.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public void ListReservations()
        {
            Console.Clear();

            Console.WriteLine("===== LIST OF RESERVATIONS =====");

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"SELECT
                              T.Name AS Teacher,
                              C.Name AS Classroom,
                              T.Subject,
                              B.Schedule
                           FROM Booking B
                           INNER JOIN Teacher T
                               ON B.TeacherCode = T.Code
                           INNER JOIN Classroom C
                               ON B.ClassroomCode = C.Code";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("\nThere are no reservations.");
                        Console.ReadKey();
                        return;
                    }

                    int i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine("\nBooking #" + i);
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Teacher   : " + reader["Teacher"]);
                        Console.WriteLine("Classroom : " + reader["Classroom"]);
                        Console.WriteLine("Subject   : " + reader["Subject"]);
                        Console.WriteLine("Schedule  : " + reader["Schedule"]);

                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError listing reservations.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public void DeleteClassroom()
        {
            Console.Clear();

            Console.WriteLine("===== DELETE CLASSROOM =====");

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sqlCount = "SELECT COUNT(*) FROM Classroom";

                    SqlCommand cmdCount = new SqlCommand(sqlCount, cn);

                    int total = (int)cmdCount.ExecuteScalar();

                    if (total == 0)
                    {
                        Console.WriteLine("\nThere are no classrooms registered.");
                        Console.ReadKey();
                        return;
                    }

                    List<string> classroomCodes = new List<string>();

                    Console.WriteLine("\nREGISTERED CLASSROOMS\n");

                    string sqlList = "SELECT Code, Name, Capacity FROM Classroom";

                    SqlCommand cmdList = new SqlCommand(sqlList, cn);

                    SqlDataReader reader = cmdList.ExecuteReader();

                    int i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine(i + ". Code: " + reader["Code"] + " - Name: " + reader["Name"] + " - Capacity: " + reader["Capacity"]);

                        classroomCodes.Add(Convert.ToString(reader["Code"]) ?? "");

                        i++;
                    }

                    reader.Close();

                    int option;

                    Console.Write("\nSelect the classroom to delete: ");

                    while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > classroomCodes.Count)
                    {
                        Console.Write("Invalid option. Try again: ");
                    }

                    string classroomCode = classroomCodes[option - 1];

                    string sqlCheck = @"SELECT COUNT(*)
                                FROM Booking
                                WHERE ClassroomCode = @Code";

                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, cn);

                    cmdCheck.Parameters.AddWithValue("@Code", classroomCode);

                    int totalReservations = (int)cmdCheck.ExecuteScalar();

                    if (totalReservations > 0)
                    {
                        Console.WriteLine("\nThis classroom cannot be deleted because it has reservations.");
                        Console.ReadKey();
                        return;
                    }

                    Console.Write("\nAre you sure you want to delete this classroom? (Y/N): ");

                    string answer = Console.ReadLine() ?? "";

                    if (answer.ToUpper() != "Y")
                    {
                        Console.WriteLine("\nOperation cancelled.");
                        Console.ReadKey();
                        return;
                    }

                    string sqlDelete = "DELETE FROM Classroom WHERE Code = @Code";

                    SqlCommand cmdDelete = new SqlCommand(sqlDelete, cn);

                    cmdDelete.Parameters.AddWithValue("@Code", classroomCode);

                    int rows = cmdDelete.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        Console.WriteLine("\nClassroom deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("\nThe classroom could not be deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError deleting classroom.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public void DeleteTeacher()
        {
            Console.Clear();

            Console.WriteLine("===== DELETE TEACHER =====");

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sqlCount = "SELECT COUNT(*) FROM Teacher";

                    SqlCommand cmdCount = new SqlCommand(sqlCount, cn);

                    int total = (int)cmdCount.ExecuteScalar();

                    if (total == 0)
                    {
                        Console.WriteLine("\nThere are no teachers registered.");
                        Console.ReadKey();
                        return;
                    }

                    // Mostrar profesores
                    List<string> teacherCodes = new List<string>();

                    Console.WriteLine("\nREGISTERED TEACHERS\n");

                    string sqlList = "SELECT Code, Name, Subject FROM Teacher";

                    SqlCommand cmdList = new SqlCommand(sqlList, cn);

                    SqlDataReader reader = cmdList.ExecuteReader();

                    int i = 1;

                    while (reader.Read())
                    {
                        Console.WriteLine(i + ". Code: " + reader["Code"] + " - Name: " + reader["Name"] +

                                            " - Subject: " + reader["Subject"]);

                        teacherCodes.Add(Convert.ToString(reader["Code"]) ?? "");

                        i++;
                    }

                    reader.Close();

                    int option;

                    Console.Write("\nSelect the teacher to delete: ");

                    while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > teacherCodes.Count)
                    {
                        Console.Write("Invalid option. Try again: ");
                    }

                    string teacherCode = teacherCodes[option - 1];

                    string sqlCheck = @"SELECT COUNT(*)
                                FROM Booking
                                WHERE TeacherCode = @Code";

                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, cn);

                    cmdCheck.Parameters.AddWithValue("@Code", teacherCode);

                    int totalReservations = (int)cmdCheck.ExecuteScalar();

                    if (totalReservations > 0)
                    {
                        Console.WriteLine("\nThis teacher cannot be deleted because it has reservations.");
                        Console.ReadKey();
                        return;
                    }

                    Console.Write("\nAre you sure you want to delete this teacher? (Y/N): ");

                    string answer = Console.ReadLine() ?? "";

                    if (answer.ToUpper() != "Y")
                    {
                        Console.WriteLine("\nOperation cancelled.");
                        Console.ReadKey();
                        return;
                    }

                    string sqlDelete = "DELETE FROM Teacher WHERE Code = @Code";

                    SqlCommand cmdDelete = new SqlCommand(sqlDelete, cn);

                    cmdDelete.Parameters.AddWithValue("@Code", teacherCode);

                    int rows = cmdDelete.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        Console.WriteLine("\nTeacher deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("\nThe teacher could not be deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError deleting teacher.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
