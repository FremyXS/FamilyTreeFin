using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var i in File.ReadAllLines(@"../../../personfile.txt"))
            {
                if (String.IsNullOrWhiteSpace(i)) break;

                Console.WriteLine(i);
            }
            Person.AddPeople(File.ReadAllLines(@"../../../personfile.txt"));

            Console.WriteLine("Введите id первого и второго человека");
            var idPersonOne = int.Parse(Console.ReadLine());
            var idPersonTwo = int.Parse(Console.ReadLine());

            Console.WriteLine(Relation.GetRelation(idPersonOne, idPersonTwo)); 
        }
    }
    
    
}
