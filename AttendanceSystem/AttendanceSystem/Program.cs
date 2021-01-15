using BusinessLogic;
using Common;
using System;

namespace AttendanceSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher teacherLoggedIn; //The TeacherLoggedInID as a Global Variable

            //Linking the Business Logic
            StudentService ss = new StudentService();
            TeacherService ts = new TeacherService();
            LessonService ls = new LessonService();
            GroupService gs = new GroupService();
            StudentAttendanceService sas = new StudentAttendanceService();

            int menuChoice = 0;
            do
            {
                //Try Parsing
                do
                {
                    Console.Clear();
                    ShowMenu();
                    Console.WriteLine("\nEnter Choice: ");

                } while (!int.TryParse(Console.ReadLine(), out menuChoice));

                Console.Clear();

                //Main Menu
                switch (menuChoice)
                {
                    case 1:
                        Console.WriteLine("Login");
                        Console.WriteLine("======");

                        Teacher myTeacher = new Teacher();

                        Console.WriteLine("\nUsername: ");
                        myTeacher.Username = Console.ReadLine().ToLower();

                        if (ts.usernameExists(myTeacher.Username))
                        {
                            Console.WriteLine("\nPasword: ");
                            myTeacher.Password = Console.ReadLine().ToLower();

                            teacherLoggedIn = ts.passwordMatch(myTeacher);
                            if (teacherLoggedIn != null)
                            {
                                int loginChoice = 0;
                                do
                                {
                                    //Try Parsing
                                    do
                                    {
                                        Console.Clear();
                                        ShowLoginChoice();
                                        Console.WriteLine("\nEnter Choice: ");

                                    } while (!int.TryParse(Console.ReadLine(), out loginChoice));

                                    Console.Clear();
                                    //Teacher's Menu
                                    switch (loginChoice)
                                    {
                                        case 1:
                                            //Add Attendance
                                            Student groupStudents = new Student();

                                            Console.WriteLine("Groups:");
                                            Console.WriteLine("==============");

                                            foreach (var g in gs.GetGroups())
                                            {
                                                Console.WriteLine($"\nGroup ID: {g.GroupID}\n Group Name: {g.Name}");
                                            }

                                            Console.WriteLine("\nNew Attendance");
                                            Console.WriteLine("==============");

                                            //Exception
                                            bool incorrectgrouptChoice;
                                            do
                                            {
                                                try
                                                {
                                                    Console.WriteLine("\nGroupID: ");
                                                    groupStudents.GroupID = Convert.ToInt32(Console.ReadLine());
                                                    incorrectgrouptChoice = false;
                                                }
                                                catch
                                                {
                                                    incorrectgrouptChoice = true;
                                                }

                                            } while (incorrectgrouptChoice);

                                            if (gs.groupIDExists(groupStudents.GroupID))
                                            {
                                                StudentAttendance myStudentAttendance = new StudentAttendance();
                                                Lesson myLesson = new Lesson();

                                                myLesson.GroupID = groupStudents.GroupID;
                                                myLesson.DateTime = DateTime.Now.Date;
                                                myLesson.TeacherID = teacherLoggedIn.TeacherID;

                                                myLesson.LessonID = ls.Add(myLesson); //Returns the new LessonID

                                                foreach (var student in ss.GetStudents(groupStudents.GroupID))
                                                {
                                                    Console.WriteLine($"\nStudent ID: {student.StudentID}\n Student Name: {student.Name}\n Student Surname: {student.Surname}\n");
                                                    bool pressence = false;
                                                    bool retry;
                                                    do
                                                    {
                                                        Console.WriteLine("Presence(P/A): ");

                                                        retry = false;

                                                        switch (Console.ReadLine())
                                                        {
                                                            case "p":
                                                                pressence = true;
                                                                break;

                                                            case "a":
                                                                pressence = false;
                                                                break;

                                                            default:
                                                                retry = true;
                                                                break;
                                                        }
                                                    } while (retry);

                                                    myStudentAttendance.LessonID = myLesson.LessonID; //Retreives the current created LessonID
                                                    myStudentAttendance.Pressence = pressence;
                                                    myStudentAttendance.StudentID = student.StudentID;

                                                    sas.Add(myStudentAttendance);
                                                }

                                                Console.WriteLine("\nAttendance was added successfully ");
                                                Console.WriteLine("Press any key to return back to the Main Menu...");
                                                Console.ReadKey();
                                            }

                                            else
                                            {
                                                Console.WriteLine("\nThe entered ID does not exist in our system");
                                                Console.WriteLine("Press any key to return back to the Main Menu...");
                                                Console.ReadKey();
                                            }

                                            break;

                                        case 2:
                                            //Add a New Group
                                            Group myGroup = new Group();

                                            Console.WriteLine("New Group");
                                            Console.WriteLine("==============");

                                            Console.WriteLine("\nGroup Name: ");
                                            myGroup.Name = Console.ReadLine();

                                            Console.WriteLine("\nCourse Name: ");
                                            myGroup.Course = Console.ReadLine();

                                            gs.Add(myGroup);

                                            Console.WriteLine("\nGroup was added successfully ");
                                            Console.WriteLine("Press any key to return back to the Main Menu...");
                                            Console.ReadKey();

                                            break;

                                        case 3:
                                            //Add a New Student
                                            Student myStudent = new Student();

                                            //Exception
                                            bool incorrectGroupID;
                                            do
                                            {
                                                try
                                                {
                                                    Console.WriteLine("New Student");
                                                    Console.WriteLine("==============");
                                                    Console.WriteLine("\nInput the GroupID: ");
                                                    myStudent.GroupID = Convert.ToInt32(Console.ReadLine());
                                                    incorrectGroupID = false;
                                                }
                                                catch
                                                {
                                                    incorrectGroupID = true;
                                                    Console.Clear();
                                                }

                                            } while (incorrectGroupID);

                                            if (gs.groupIDExists(myStudent.GroupID))
                                            {
                                                Console.WriteLine("\nName: ");
                                                myStudent.Name = Console.ReadLine();

                                                Console.WriteLine("\nSurname: ");
                                                myStudent.Surname = Console.ReadLine();

                                                Console.WriteLine("\nEmail: ");
                                                myStudent.Email = Console.ReadLine();

                                                ss.Add(myStudent);
                                                Console.WriteLine("\nStudent was added successfully ");
                                                Console.WriteLine("Press any key to return back to the Main Menu...");
                                                Console.ReadKey();
                                            }

                                            else
                                            {
                                                Console.WriteLine("\nThe entered ID does not exist in our system");
                                                Console.WriteLine("Press any key to return back to the Main Menu...");
                                                Console.ReadKey();
                                            }

                                            break;

                                        case 4:
                                            //Add a New Teacher
                                            Teacher teacher = new Teacher();

                                            Console.WriteLine("New Teacher");
                                            Console.WriteLine("==============");

                                            Console.WriteLine("\nUsername: ");
                                            teacher.Username = Console.ReadLine();

                                            Console.WriteLine("\nPassword: ");
                                            teacher.Password = Console.ReadLine();

                                            Console.WriteLine("\nName: ");
                                            teacher.Name = Console.ReadLine();

                                            Console.WriteLine("\nSurname: ");
                                            teacher.Surname = Console.ReadLine();

                                            Console.WriteLine("\nEmail: ");
                                            teacher.Email = Console.ReadLine();

                                            ts.Add(teacher);

                                            Console.WriteLine("\nTeacher was added successfully ");
                                            Console.WriteLine("Press any key to return back to the Main Menu...");
                                            Console.ReadKey();

                                            break;

                                        case 5:
                                            //Check a student's attendance percentage
                                            StudentAttendance StudentAttendance = new StudentAttendance();

                                            //Exception
                                            bool incorrectSIDChoice;
                                            do
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Check a Student's Attendance Percentage");
                                                    Console.WriteLine("==========================================");
                                                    Console.WriteLine("\nStudentID: ");
                                                    StudentAttendance.StudentID = Convert.ToInt32(Console.ReadLine());
                                                    incorrectSIDChoice = false;
                                                }
                                                catch
                                                {
                                                    incorrectSIDChoice = true;
                                                    Console.Clear();
                                                }

                                            } while (incorrectSIDChoice);

                                            if (ss.studentIDExists(StudentAttendance.StudentID))
                                            {
                                                var total = sas.GetAttendancePercentage(StudentAttendance.StudentID);
                                                Console.WriteLine("\nAverage Percentage of Attendance: " + total + "%");
                                                Console.WriteLine("Press any key to return back to the Main Menu...");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nThe entered ID does not exist in our system");
                                                Console.WriteLine("Press any key to return back to the Main Menu...");
                                                Console.ReadKey();
                                            }

                                            break;

                                        case 6:
                                            bool incorrectDay;
                                            bool incorrectMonth;
                                            bool incorrectYear;
                                            bool incorrectDate;
                                            DateTime date;

                                            do
                                            {
                                                Console.Clear();
                                                date = new DateTime();
                                                incorrectDate = false;

                                                //Get All Attendances Submitted on a Particular Day
                                                StudentAttendance attendanceDate = new StudentAttendance();
                                                Lesson dateAttendance = new Lesson();

                                                Console.WriteLine("Submitted Attendance");
                                                Console.WriteLine("=====================");

                                                Console.WriteLine("\nDay: ");
                                                incorrectDay = !int.TryParse(Console.ReadLine(), out int day);

                                                Console.WriteLine("\nMonth: ");
                                                incorrectMonth = !int.TryParse(Console.ReadLine(), out int month);

                                                Console.WriteLine("\nYear: ");
                                                incorrectYear = !int.TryParse(Console.ReadLine(), out int year);

                                                try
                                                {
                                                    date = Convert.ToDateTime(day + "/" + month + "/" + year);
                                                }
                                                catch
                                                {
                                                    incorrectDate = true;
                                                }
                                            } while (incorrectDay || incorrectMonth || incorrectYear || incorrectDate);

                                            var numberOfAttendancesSubmitted = sas.GetAttendancesForDay(date, teacherLoggedIn.TeacherID);
                                            Console.WriteLine("\nNumber of attendances submitted on given day: " + numberOfAttendancesSubmitted);
                                            Console.WriteLine("Press any key to return back to the Main Menu...");
                                            Console.ReadKey();

                                            break;

                                        case 7:
                                            //Edit Student
                                            Student studentToEdit = new Student();

                                            //Exception
                                            bool incorrectEditChoice;
                                            do
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Edit Student");
                                                    Console.WriteLine("==============");
                                                    Console.WriteLine();
                                                    Console.WriteLine("StudentID: ");
                                                    studentToEdit.StudentID = Convert.ToInt32(Console.ReadLine());
                                                    incorrectEditChoice = false;
                                                }
                                                catch
                                                {
                                                    incorrectEditChoice = true;
                                                    Console.Clear();
                                                }

                                            } while (incorrectEditChoice);

                                            if (ss.studentIDExists(studentToEdit.StudentID))
                                            {
                                                Console.WriteLine("\nName: ");
                                                studentToEdit.Name = Console.ReadLine();

                                                Console.WriteLine("\nSurname: ");
                                                studentToEdit.Surname = Console.ReadLine();

                                                Console.WriteLine("\nEmail: ");
                                                studentToEdit.Email = Console.ReadLine();

                                                ss.Update(studentToEdit.StudentID, studentToEdit.Name, studentToEdit.Surname, studentToEdit.Email);
                                                Console.WriteLine("\nStudent was updated successfully ");
                                                Console.WriteLine("Press any key to return back to the Main Menu...");
                                                Console.ReadKey();
                                            }

                                            else
                                            {
                                                Console.WriteLine("\nThe entered ID does not exist in our system");
                                                Console.WriteLine("Press any key to return back to the Main Menu...");
                                                Console.ReadKey();
                                            }

                                            break;

                                        default:
                                            if (loginChoice == 8)
                                            {
                                                Console.WriteLine("Press any key to return back to the Main Menu...");
                                                Console.ReadKey();
                                            }

                                            Console.Clear();
                                            break;
                                    }

                                } while (loginChoice != 8);

                            }

                            else
                            {
                                Console.WriteLine("\nThe entered ID does not exist in our system");
                                Console.WriteLine("Press any key to return back to the Main Menu...");
                                Console.ReadKey();
                                break;
                            }
                        }

                        else
                        {
                            Console.WriteLine("\nThe entered ID does not exist in our system");
                            Console.WriteLine("Press any key to return back to the Main Menu...");
                            Console.ReadKey();
                            break;
                        }

                        break;

                    default:
                        if (menuChoice == 2)
                        {
                            Console.WriteLine("Press any key to Exit the Application");
                            Console.ReadKey();
                        }

                        break;
                }

            } while (menuChoice != 2);
        }

        static void ShowMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("=========");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
        }

        static void ShowLoginChoice()
        {
            Console.WriteLine("Teacher's Menu");
            Console.WriteLine("=========");
            Console.WriteLine("1. Add Attendance");
            Console.WriteLine("2. Add a New Group");
            Console.WriteLine("3. Add a New Student");
            Console.WriteLine("4. Add a New Teacher");
            Console.WriteLine("5. Check a Student's Attendance Percentage");
            Console.WriteLine("6. Get All Attendances Submitted on a Particular Day");
            Console.WriteLine("7. Edit Student");
            Console.WriteLine("8. Exit");
        }
    }
}