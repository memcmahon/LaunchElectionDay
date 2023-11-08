using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay.UnitTests
{
    public class ElectionTests
    {
        [Fact]
        public void IsCreatedWithAYearAndNoRaces()
        {
            var election = new Election("2023");

            Assert.Equal("2023", election.Year);
            Assert.Equal(new List<Race>(), election.Races);
        }

        [Fact]
        public void AddRaceAddsARaceToRacesList()
        {
            var election = new Election("2023");
            var race1 = new Race("City Council District 10");
            var race2 = new Race("School Board President");

            election.AddRace(race1);
            election.AddRace(race2);

            Assert.Equal(new List<Race> { race1, race2 }, election.Races);
        }

        [Fact]
        public void AllCandidatesReturnsListOfCandidates()
        {
            var election = new Election("2023");
            var race1 = new Race("City Council District 10");
            var race2 = new Race("School Board President");
            var can1 = new Candidate("Diana D", "Democrat");
            var can2 = new Candidate("Asher", "Democrat");
            var can3 = new Candidate("Sam", "Democrat");
            election.AddRace(race1);
            election.AddRace(race2);
            race1.RegisterCandidate(can3);
            race1.RegisterCandidate(can1);
            race2.RegisterCandidate(can2);

            //var expected = new List<Candidate> { can3, can1, can2 };
            //Assert.Equal(expected, election.AllCandidates());

            Assert.Equal(3, election.AllCandidates().Count);
            Assert.Contains(can1, election.AllCandidates());
            Assert.Contains(can2, election.AllCandidates());
            Assert.Contains(can3, election.AllCandidates());
        }

        [Fact]
        public void VoteCountsReturnsVotesPerCandidateInADictionary()
        {
            var election = new Election("2023");
            var race1 = new Race("City Council District 10");
            var race2 = new Race("School Board President");
            var can1 = new Candidate("Diana D", "Democrat");
            var can2 = new Candidate("Asher", "Democrat");
            var can3 = new Candidate("Sam", "Democrat");
            can1.VoteFor();
            can1.VoteFor();
            can1.VoteFor();
            can2.VoteFor();
            can2.VoteFor();
            can3.VoteFor();
            election.AddRace(race1);
            election.AddRace(race2);
            race1.RegisterCandidate(can3);
            race1.RegisterCandidate(can1);
            race2.RegisterCandidate(can2);

            var expected = new Dictionary<string, int>()
            {
                { can2.Name, 2 },
                { can1.Name, 3 },
                { can3.Name, 1 }
            };

            Assert.Equal(expected, election.VoteCounts());
        }
    }
}
