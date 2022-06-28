using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace difzach_var1
{
    public class Stran
    {
        public int Id { get; set; }
        public string Des { get; set; }
    }
    public class group
    {
        public int InvNumb { get; set; }
        public int Id { get; set; }
        public int Prices { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var w = new List<string>{
            "Турция",
            "Египет",
            "Россия",
            "Китай"};
            List<Stran> List_Tovars = new List<Stran>
            {
               new Stran {Id = 1, Des = "Германия"}, new Stran {Id = 2, Des ="Турция"}, new Stran {Id = 3, Des ="Египет"},
               new Stran {Id = 4, Des ="Россия"}, new Stran {Id = 5, Des ="Казахстан"}
            };
            List<group> ListGroup = new List<group>
            {
               new group {InvNumb=0, Id = 3, Prices = 800 }, new group {InvNumb=1, Id = 5, Prices = 650 }, new group {InvNumb=2, Id = 3, Prices = 900 }, new group {InvNumb=3, Id = 4, Prices = 700 },
               new group {InvNumb=4, Id = 3, Prices = 900 }, new group {InvNumb=5, Id = 4, Prices = 650 }, new group {InvNumb=6, Id = 1, Prices = 458 }
            };

            var Grupps = from perm in ListGroup
                         join i in List_Tovars on perm.Id equals i.Id into a
                         from b in a.DefaultIfEmpty()
                         select new
                         {
                             Number = b.Id,
                             Name = b.Des,
                             Price = perm.Prices
                         };
            Console.WriteLine("Идентификатор Стран        Название Стран             Покупка Цена");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var informs in Grupps)
            {
                Console.WriteLine(informs.Number + "\t\t\t\t" + informs.Name + "\t\t\t\t" + informs.Price);
            }
            Console.WriteLine("Турция\nЕгипет\nРоссия\nГермания");
            Console.WriteLine("Введите \n1 - сортировка по букве\n2 - сортировка в обратном направлении\n3 - сортировка на удаления слова имеющая букву");
            int h = Convert.ToInt32(Console.ReadLine());
            switch (h)
            {
                case 1:
                    Console.WriteLine("Введите букву");
                    char t = Convert.ToChar(Console.ReadLine().ToUpper());

                    var r = w.Where(x => x.Contains(t));
                    foreach (var pet in r)
                    {
                        Console.WriteLine(pet);
                        StreamWriter st1 = File.CreateText("Буква.txt");
                        st1.WriteLine(pet);
                        st1.Close();
                    }
                    break;
                case 2:
                    var s = w.OrderBy(e => e);
                    int i = 1;
                    var q = w.Select(x => $"{i++} {x}");
                    foreach (var pet in s)
                    {

                        Console.WriteLine(pet);
                        StreamWriter st1 = File.CreateText("Обратное_направление.txt");
                        st1.WriteLine(pet);
                        st1.Close();
                    }
                    foreach (var pet in q)
                    {
                        Console.WriteLine(pet);
                        StreamWriter st1 = File.AppendText("Обратное_направление.txt");
                        st1.WriteLine(pet);
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите букву");
                    char o = Convert.ToChar(Console.ReadLine());
                    var p = w.Where(x => !x.Contains(o));
                    foreach (var pet in p)
                    {
                        Console.WriteLine(pet);
                        StreamWriter st1 = File.CreateText("Удаление.txt");
                        st1.WriteLine(pet);
                        st1.Close();
                    }
                    break;
            }
        }
    }
}