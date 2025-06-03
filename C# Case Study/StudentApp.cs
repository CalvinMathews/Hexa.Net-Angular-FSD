using System;
using System.Collections.Generic;

namespace StudentApp
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class StudentManager
    {
        private List<Student> list = new List<Student>();

        public void Add(int id, string name)
        {
            list.Add(new Student { ID = id, Name = name });
            Console.WriteLine("Student added");
        }

        public void ShowAll()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No student records");
                return;
            }

            Console.WriteLine("Student List:");
            foreach (Student s in list)
            {
                Console.WriteLine($"ID: {s.ID}, Name: {s.Name}");
            }
        }

        public void Search(int id)
        {
            bool found = false;
            foreach (Student s in list)
            {
                if (s.ID == id)
                {
                    Console.WriteLine($"Found: ID={s.ID}, Name={s.Name}");
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine("Student not found");
        }

        public void Remove(int id)
        {
            Student temp=null;
            foreach (Student s in list)
            {
                if (s.ID == id)
                {
                    temp=s;
                    break;
                }
            }

            if (temp!= null)
            {
                list.Remove(temp);
                Console.WriteLine("Student removed");
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }

        public void Count()
        {
            Console.WriteLine($"Total students:  { list.Count}");
        }
    }

    class Program
    {
        static void Main()
        {
            StudentManager sm = new StudentManager();
            sm.Add(1, "Ajay");
            sm.Add(2, "Bob");
            sm.Add(3, "Charlie");

            while (true)
            {
                Console.WriteLine("\n----- Menu -----");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show All");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Remove Student");
                Console.WriteLine("5. Count Students");
                Console.WriteLine("6. Exit");
                Console.Write("Choose: ");

                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.Write("Enter ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        sm.Add(id, name);
                        break;

                    case 2:
                        sm.ShowAll();
                        break;

                    case 3:
                        Console.Write("Enter ID to search: ");
                        int sid = Convert.ToInt32(Console.ReadLine());
                        sm.Search(sid);
                        break;

                    case 4:
                        Console.Write("Enter ID to remove: ");
                        int rid = Convert.ToInt32(Console.ReadLine());
                        sm.Remove(rid);
                        break;

                    case 5:
                        sm.Count();
                        break;

                    case 6:
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
