namespace LaunchElectionDay
{
    public class Candidate {
        public string Name { get; set; }
        public string Party { get; set; }
        public int Votes { get; set; }

        public Candidate(string name, string party) // creating two variables that will be used in the method (only this method)
        {
            Name = name;
            Party = party;
            Votes = 0;
        }

        public void VoteFor()
        {
            Votes++;
        }
    }
}
