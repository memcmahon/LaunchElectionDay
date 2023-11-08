using LaunchElectionDay;
var race = new Race("City Council District 10");

Console.WriteLine(race.Office);
// Output => "City Council District 10"

foreach (var candidate in race.Candidates)
{
    Console.WriteLine(candidate.Name);
}
// Output => ""

var diana = new Candidate("Diana D", "Democrat");
race.RegisterCandidate(diana);

foreach (var candidate in race.Candidates)
{
    Console.WriteLine(candidate.Name);
}
// Output => "Diana D"