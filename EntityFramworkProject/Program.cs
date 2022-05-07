using EntityFrameworkProject;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

DepartamentRepository dr = new DepartamentRepository();
Lecture lecture1 = new Lecture() { Name = "Astronomija" };
Lecture lecture2 = new Lecture() { Name = "Filologija" };
Student student = new Student() { Name = "Kipras" };
Departament departament = new Departament() { Name = "VGTU", Students = new List<Student>() { student }, Lectures = new List<Lecture>() { lecture1, lecture2 } };

//dr.AddDepartament(departament); // Exercise 1

// Exercise 2
List<Lecture> lectureList = new List<Lecture>() { new Lecture() { Name = "Piešimas" }, new Lecture() { Name = "Braižyba" } };
List<Student> studentList = new List<Student>() { new Student() { Name = "Mykolas" } };
//dr.AddStudentsOrLecturesToExistingDepartament("VU", studentList);

//dr.AddLectureToDepartament("SU", new Lecture() { Name = "Anglų kalba" }); //Exercise 3
//dr.AddStudentToDepartamentAndAssignLectures("KTU", new Student() { Name = "Andrius" }); //Exercise 4
//dr.MoveStudentToAnotherDepartament("SU", "Andrius"); //Exercise 5
//dr.ShowAllDepartamentStudents("SU"); // Exercise 6.
//dr.ShowAllDepartamentLessons("VU"); // Exercise 7.
//dr.ShowStudensLessons(); // Exercise 8.

Console.WriteLine("Done.");