using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Person
    {
        public int Id { get; }
        public string LastName { get; }
        public string FirstName { get; }
        public string BirthDate { get; }
        public List<Relation> Relations { get; } = new List<Relation>();
        public Person(int id, string lastName, string firstName, string birthDate)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
        }
        public static List<Person> Peoples { get; } = new List<Person>();
        enum ColumnsName
        {
            Id, LastName, FirstName, BirthDate
        }
        private static Person GetCorrectSequence(string[] columns, string[] strInfo)
            => new Person(int.Parse(strInfo[columns.ToList().IndexOf(ColumnsName.Id.ToString())]),
                strInfo[columns.ToList().IndexOf(ColumnsName.LastName.ToString())],
                strInfo[columns.ToList().IndexOf(ColumnsName.FirstName.ToString())],
                strInfo[columns.ToList().IndexOf(ColumnsName.BirthDate.ToString())]);
        public static void AddPeople(string[] @people)
        {
            for (var i = 1; i < @people.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(@people[i]))
                {
                    AddRelations(i + 1, @people);
                    break;
                }

                var strInfo = @people[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                Peoples.Add(
                    GetCorrectSequence(@people[0].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries),
                    strInfo));
            }
        }
        private static void AddRelations(int ind, string[] @relations)
        {
            for (var i = ind; i < @relations.Length; i++)
            {
                var strInfo = @relations[i].Split(new char[] { '<', '>', '-', '=' }, StringSplitOptions.RemoveEmptyEntries);

                AddOneRelation(strInfo, 0, 1);
                AddOneRelation(strInfo, 1, 0);
            }
        }
        private static void AddOneRelation(string[] strInfo, int indOne, int indTwo)
        {
            var people = Peoples.Single(e => e.Id == int.Parse(strInfo[indOne]));
            Peoples.Remove(people);
            people.Relations.Add(new Relation(strInfo[2], int.Parse(strInfo[indTwo])));
            Peoples.Add(people);
        }

    }
}
