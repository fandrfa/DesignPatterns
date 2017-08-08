using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            double goldForKill = 1023;
            Console.WriteLine("You have killed the Monster and gained {0} coins!", goldForKill);

            Player andy = new Player { Name = "Andy" };
            Player jane = new Player { Name = "Jane" };
            Player eve = new Player { Name = "Eve" };
            Player ann = new Player { Name = "Ann" };
            Player edith = new Player { Name = "Edith" };
            Group developers = new Group { Name = "Developers", Members = { andy, jane, eve } };

            List<Player> individuals = new List<Player> { ann, edith };
            List<Group> groups = new List<Group> { developers };

            double totalToSplitBy = individuals.Count + groups.Count;
            double amountForEach = goldForKill / totalToSplitBy;
            double leftOver = goldForKill % totalToSplitBy;

            foreach (Player individual in individuals)
            {
                individual.Gold += amountForEach + leftOver;
                leftOver = 0;
                individual.Stats();
            }

            foreach (Group group in groups)
            {
                double amountForEachGroupMember = amountForEach / group.Members.Count;
                double leftOverForGroup = amountForEachGroupMember % group.Members.Count;
                foreach (Player member in group.Members)
                {
                    member.Gold += amountForEachGroupMember + leftOverForGroup;
                    leftOverForGroup = 0;
                    member.Stats();
                }
            }

            Console.ReadKey();
        }
    }
}

