using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay
{
    public class Election
    {
        public string Year;
        public List<Race> Races;

        public Election(string year)
        {
            Year = year;
            Races = new List<Race>();
        }

        public void AddRace(Race race)
        {
            Races.Add(race);
        }

        public List<Candidate> AllCandidates()
        {
            var allCandidates = new List<Candidate>();

            foreach(var race in Races)
            {
                foreach(var can in race.Candidates)
                {
                    allCandidates.Add(can);
                }
            }

            return allCandidates;
        }

        public Dictionary<string, int> VoteCounts()
        {
            var voteCounts = new Dictionary<string, int>();

            foreach (var race in Races)
            {
                foreach (var can in race.Candidates)
                {
                    voteCounts.Add(can.Name, can.Votes);
                }
            }

            return voteCounts;
        }
    }
}
