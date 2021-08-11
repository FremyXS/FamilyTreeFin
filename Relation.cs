using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Relation
    {
        public string _Relation { get; }
        public int IdSecondPerson { get; }
        public Relation(string relation, int idSecondPerson)
        {
            _Relation = relation;
            IdSecondPerson = idSecondPerson;
        }
        public static string GetRelation(int idFirstPerson, int idSecondPerson)
        {
            var firstPerson = Person.Peoples.Single(e => e.Id == idFirstPerson);

            if (firstPerson.Relations.Any(e => e.IdSecondPerson == idSecondPerson))
            {
                var rel = firstPerson.Relations.Single(e => e.IdSecondPerson == idSecondPerson);
                return rel._Relation;
            }
            else
            {
                return GetImplicitRelation(idFirstPerson, idSecondPerson);
            }

        }
        private static string GetImplicitRelation(int idFirstPerson, int idSecondPerson)
        {
            var person = Person.Peoples.Single(e => e.Id == idSecondPerson);

            foreach (var info in person.Relations)
            {
                var thirdPerson = Person.Peoples.Single(e => e.Id == info.IdSecondPerson);

                if (thirdPerson.Relations.Any(e => e.IdSecondPerson == idFirstPerson))
                {
                    return "new Relation";
                }
            }

            return "not Relation";
        }
    }
}
