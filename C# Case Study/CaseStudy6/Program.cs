using System;

class Program
{
    static void Main()
    {
        MyPlayList mp = new MyPlayList();
        while (true)
        {
            Console.WriteLine("\nEnter:");
            Console.WriteLine("1: Add Song");
            Console.WriteLine("2: Remove Song by Id");
            Console.WriteLine("3: Get Song By Id");
            Console.WriteLine("4: Get Song by Name");
            Console.WriteLine("5: Get All Songs");
            Console.WriteLine("0: Exit");

            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Song s = new Song();
                    Console.Write("Enter Id: ");
                    s.Id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    s.Nm = Console.ReadLine();
                    Console.Write("Enter Genre: ");
                    s.Gn = Console.ReadLine();
                    mp.Add(s);
                    break;

                case 2:
                    Console.Write("Enter Id to remove: ");
                    int id = int.Parse(Console.ReadLine());
                    mp.Remove(id);
                    break;

                case 3:
                    Console.Write("Enter Id: ");
                    Song sid = mp.GetById(int.Parse(Console.ReadLine()));
                    if (sid != null)
                        Console.WriteLine($"{sid.Id} {sid.Nm} {sid.Gn}");
                    else Console.WriteLine("Not found.");
                    break;

                case 4:
                    Console.Write("Enter Name: ");
                    Song snm = mp.GetByName(Console.ReadLine());
                    if (snm != null)
                        Console.WriteLine($"{snm.Id} {snm.Nm} {snm.Gn}");
                    else Console.WriteLine("Not found.");
                    break;

                case 5:
                    var all = mp.GetAll();
                    if (all.Count == 0)
                        Console.WriteLine("No songs.");
                    else
                        foreach (var x in all)
                            Console.WriteLine($"{x.Id} {x.Nm} {x.Gn}");
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Invalid.");
                    break;
            }
        }
    }
}
