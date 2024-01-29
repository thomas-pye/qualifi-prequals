using Models;
using Services.Interfaces;
using efmodels;

namespace Services
{
    public class PrequalificationService: IPrequalificationService
    {
        Context _context;

        public PrequalificationService(Context context)
        {
            _context = context;
        }

        public List<Loan> ProcessDetails(PrequalificationModel model)
        {
            // Store request in database
            _context.Add(new Prequalification() { 
                Name = model.Name, 
                Address = model.Address, 
                DateOfBirth = model.DateOfBirth, 
                Salary = model.Salary });

            _context.SaveChanges();

            // Call database for loan service, 
            // This has been trivialised for the purpose of this exercise and we are just comparing CreditLimit to Salaries
            return _context.Loans
                .OrderBy(b => b.LoanId)
                .Where(loan => loan.CreditLimit < model.Salary)
                .ToList();
        }
    }
}