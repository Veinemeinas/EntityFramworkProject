using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    internal class DepartamentRepository
    {
        public void AddDepartament(Departament departament)
        {
            using (var context = new SchoolContext())
            {
                var lectures = context.Lectures;

                foreach (var lecture in departament.Lectures)
                {
                    bool found = false;
                    foreach (var lectureFromDb in lectures)
                    {
                        if (lecture.Name == lectureFromDb.Name)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"{lecture.Name} - tokia paskaita neegzistuoja duomenų bazėje");
                        Environment.Exit(0);
                    }
                }
            }

            using (var context = new SchoolContext())
            {
                context.Departaments.Add(departament);
                context.SaveChanges();
            }
        }

        public void AddStudentsOrLecturesToExistingDepartament<T>(string departamentName, List<T> studentsOrLectures) // Exercise 2
        {
            using (SchoolContext context = new SchoolContext())
            {
                var departamentFaund = context.Departaments.FirstOrDefault(d => d.Name == departamentName);

                if (departamentFaund != null)
                {
                    if (studentsOrLectures.GetType() == typeof(List<Student>))
                    {
                        departamentFaund.Students.AddRange((IEnumerable<Student>)studentsOrLectures);
                    }

                    if (studentsOrLectures.GetType() == typeof(List<Lecture>))
                    {
                        departamentFaund.Lectures.AddRange((IEnumerable<Lecture>)studentsOrLectures);
                    }
                    context.SaveChanges();
                }
            }
        }

        public void AddLectureToDepartament(string departamentName, Lecture lecture) // Exercise 3
        {
            using (SchoolContext context = new SchoolContext())
            {
                var departamentFaund = context.Departaments.FirstOrDefault(d => d.Name == departamentName);

                if (departamentFaund != null)
                {
                    departamentFaund.Lectures.Add(lecture);
                    context.SaveChanges();
                }
            }
        }

        public void AddStudentToDepartamentAndAssignLectures(string departamentName, Student student) // Exercise 4
        {
            using (SchoolContext context = new SchoolContext())
            {
                var departamentFaund = context.Departaments.FirstOrDefault(d => d.Name == departamentName);

                if (departamentFaund != null)
                {
                    departamentFaund.Students.Add(student);
                    context.SaveChanges();
                }
            }
        }

        public void MoveStudentToAnotherDepartament(string departamentName, string studentName) // Exercise 5
        {
            Student student = new Student();
            using (var context = new SchoolContext())
            {
                var deparatments = context.Departaments.Include(d => d.Students);

                foreach (var departament in deparatments)
                {
                    for (int i = 0; i < departament.Students.Count; i++)
                    {
                        if (departament.Students[i].Name == studentName)
                        {
                            student = departament.Students[i];
                        }
                    }
                }
            }

            using (var context = new SchoolContext())
            {
                var departamentFound = context.Departaments.FirstOrDefault(d => d.Name == departamentName);
                if (departamentFound != null)
                {
                    departamentFound.Students.Add(student);
                    context.SaveChanges();
                }
            }
        }

        public void ShowAllDepartamentStudents(string departamentName) // Exercise 6.
        {
            using (SchoolContext context = new SchoolContext())
            {
                var departamentFaund = context.Departaments.Include(s => s.Students).FirstOrDefault(d => d.Name == departamentName);
                if (departamentFaund != null)
                {
                    departamentFaund.Students.ForEach(s => Console.WriteLine($"{s.Name} - {departamentFaund.Name} departamentas"));
                }
                else
                {
                    Console.WriteLine($"Nerastas \"{departamentName}\" departamentas");
                }
            }
        }

        public void ShowAllDepartamentLessons(string departamentName) // Exercose 7.
        {
            using (SchoolContext context = new SchoolContext())
            {
                var departamentFaund = context.Departaments.Include(l => l.Lectures).FirstOrDefault(d => d.Name == departamentName);
                if (departamentFaund != null)
                {
                    departamentFaund.Lectures.ForEach(l => Console.WriteLine($"{l.Name} - {departamentFaund.Name} departamentas"));
                }
                else
                {
                    Console.WriteLine($"Nerastas \"{departamentName}\" departamentas");
                }
            }
        }

        public void ShowStudensLessons() // Exercise 8.
        {
            using (var context = new SchoolContext())
            {
                var deparatments = context.Departaments.Include(d => d.Lectures).Include(d => d.Students);

                foreach (var departament in deparatments)
                {
                    foreach (var student in departament.Students)
                    {
                        Console.WriteLine($"{student.Name} studijuoja:", Console.ForegroundColor = ConsoleColor.Red);
                        departament.Lectures.ForEach(l => Console.WriteLine($"    {l.Name}", Console.ForegroundColor = ConsoleColor.White));
                    }
                }
            }
        }
    }
}