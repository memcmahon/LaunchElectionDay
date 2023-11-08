using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay
{
    public class Race
    {
        public string Office;
        public List<Candidate> Candidates;
        public bool IsOpen;
        public bool IsTie;
        public Candidate? Outcome;

        public Race(string office)
        {
            Office = office;
            Candidates = new List<Candidate>();
            IsOpen = true;
            IsTie = false;
        }

        public void RegisterCandidate(Candidate candidate)
        {
            Candidates.Add(candidate);
        }

        public void Close()
        {
            IsOpen = false;
        }

        public object Winner()
        {
            if (IsOpen)
            {
                return false;
            }

            SetOutcome();


            return Outcome;
        }

        private void SetOutcome()
        {
            var maxVotes = MaxVotes();
            var winners = new List<Candidate>();

            foreach (var can in Candidates)
            {
                if (can.Votes ==  maxVotes)
                {
                    winners.Add(can);
                }
            }

            if (winners.Count > 1)
            {
                IsTie = true;
            }

            Outcome = winners[0];
        }

        private int MaxVotes()
        {
            var maxVoteCount = 0;

            foreach (var can in Candidates)
            {
                if (can.Votes > maxVoteCount)
                {
                    maxVoteCount = can.Votes;
                }
            }

            return maxVoteCount;
        }
    }
}
