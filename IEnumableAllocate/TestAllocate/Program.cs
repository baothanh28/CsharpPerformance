using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestAllocate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Loop!");
            Console.WriteLine("");
            Console.WriteLine("");
            RunLoop();
            Console.WriteLine("Hello NoLoop!");
            Console.WriteLine("");
            Console.WriteLine("");
            RunNoLoop();
        }

        private static void RunLoop()
        {
            var data = GetListLoop();
            Console.WriteLine($"data -->> {data.Count()}");
            foreach (var i in data)
            {
                Console.WriteLine($"${i} -->> {i.Name}");
            }
        }

        public static IEnumerable<NA> GetListLoop()
        {
            var lines = File.ReadAllLines("./Data.txt");
            return lines.Select(l =>
            {
                Console.WriteLine("Run read line");
                var arrRs = l.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                return new NA(arrRs[0], arrRs[1]);
            });
        }
        private static void RunNoLoop()
        {
            var data = GetListNoLoop();
            Console.WriteLine($"data -->> {data.Count()}");
            foreach (var i in data)
            {
                Console.WriteLine($"${i} -->> {i.Name}");
            }
        }
        public static IEnumerable<NA> GetListNoLoop()
        {
            List<NA> rs = new List<NA>();
            var lines = File.ReadAllLines("./Data.txt");
            foreach (var l in lines)
            {
                Console.WriteLine("Run read line");
                var arrRs = l.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                rs.Add(new NA(arrRs[0], arrRs[1]));
            }
            return rs;
        }
    }
    
    public class NA
    {
        public NA(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
