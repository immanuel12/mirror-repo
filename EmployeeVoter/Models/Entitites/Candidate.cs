namespace EmployeeVoter.Models.Entitites
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Candidate_number { get; set; }
        public string? Slogan { get; set; }
        public string? Photo { get; set; }
        public string? Updated_at { get; set; }
        public required Guid Id_election { get; set; }
    }
}
