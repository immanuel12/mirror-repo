namespace EmployeeVoter.Models.Entitites
{
    public class ChoiceVoter
    {
        public Guid Id { get; set; }
        public required int Choice { get; set; }
        public required string Updated_at { get; set; }
        public required Guid Id_voter { get; set; }
    }
}
