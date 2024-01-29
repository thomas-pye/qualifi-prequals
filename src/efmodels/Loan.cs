namespace efmodels;

public class Loan
{
        public Guid LoanId { get; set; }
        
        public string? ProductName { get; set; }

        public decimal? CreditLimit { get; set; }

        public string? LenderName { get; set;}
}