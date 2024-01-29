using Models;
using efmodels;

namespace Services.Interfaces
{
    public interface IPrequalificationService
    {
        List<Loan> ProcessDetails(PrequalificationModel model);
    }
}