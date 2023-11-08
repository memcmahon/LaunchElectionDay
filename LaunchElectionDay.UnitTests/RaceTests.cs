using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay.UnitTests
{
    public class RaceTests
    {
        [Fact]
        public void IsCreatedWithDistrictNameAndEmptyCandidates()
        {
            var race = new Race("City Council District 10");

            Assert.Equal("City Council District 10", race.Office);
            Assert.Equal(new List<Candidate>(), race.Candidates);
            Assert.True(race.IsOpen);
            Assert.False(race.IsTie);
            Assert.Null(race.Outcome);
        }

        [Fact]
        public void RegisterCandidateAddsCandidateToRace()
        {
            var race = new Race("City Council District 10");
            var diana = new Candidate("Diana D", "Democrat");
            var lance = new Candidate("Lance", "Democrat");

            race.RegisterCandidate(diana);
            race.RegisterCandidate(lance);

            Assert.Equal(diana, race.Candidates[0]);
            Assert.Equal(lance, race.Candidates[1]);

        }

        [Fact]
        public void CloseMakesItNotOpen()
        {
            var race = new Race("City Council District 10");

            race.Close();

            Assert.False(race.IsOpen);
        }

        [Fact]
        public void WinnerReturnsFalseIfRaceStillOpen()
        {
            var race = new Race("City Council District 10");

            Assert.Equal(false, race.Winner());
        }

        [Fact]
        public void WinnerReturnsWinningCandidateIfRaceClosed()
        {
            var race = new Race("City Council District 10");
            var diana = new Candidate("Diana D", "Democrat");
            var lance = new Candidate("Lance", "Democrat");

            race.RegisterCandidate(diana);
            race.RegisterCandidate(lance);

            diana.VoteFor();
            lance.VoteFor();
            lance.VoteFor();

            race.Close();

            Assert.Equal(lance, race.Winner());
        }

        [Fact]
        public void WinnerReturnsOneOfTiedCandidates()
        {
            var race = new Race("City Council District 10");
            var diana = new Candidate("Diana D", "Democrat");
            var lance = new Candidate("Lance", "Democrat");

            race.RegisterCandidate(diana);
            race.RegisterCandidate(lance);

            diana.VoteFor();
            diana.VoteFor();
            lance.VoteFor();
            lance.VoteFor();

            race.Close();

            Assert.Equal(diana, race.Winner());
        }
    }
}
