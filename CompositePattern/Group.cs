using System.Collections.Generic;

namespace IteratorPattern
{
    internal sealed class Group : IParticipant
    {
        public string Name { get; set; }
        public List<IParticipant> Members { get; set; }

        public Group()
        {
            Members = new List<IParticipant>();
        }

        public double Gold
        {
            get
            {
                double totalGold = 0;
                foreach (IParticipant member in Members)
                {
                    totalGold += member.Gold;
                }

                return totalGold;
            }
            set
            {
                double eachSplit = value / Members.Count;
                double leftOver = value % Members.Count;
                foreach (IParticipant member in Members)
                {
                    member.Gold += eachSplit + leftOver;
                    leftOver = 0;
                }
            }
        }

        public void Stats()
        {
            foreach (IParticipant member in Members)
            {
                member.Stats();
            }
        }
    }
}

