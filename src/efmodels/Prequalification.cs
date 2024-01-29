namespace efmodels;

public class Prequalification
{
        public Guid PrequalificationId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; } // For brevity this is one field, realistically I would have a seperate addressmodel
        public DateTime? DateOfBirth { get; set; }
        public decimal? Salary { get; set; }
}