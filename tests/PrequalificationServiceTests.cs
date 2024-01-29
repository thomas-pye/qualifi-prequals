using Services;
using efmodels;
using Moq;
using Moq.EntityFrameworkCore;

namespace tests;

public class Tests
{
    PrequalificationService prequalificationService;

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void TestSalaryTooLow()
    {
        var contextMock = new Mock<Context>();

        var data = new List<Loan>
        {
            new Loan { LoanId = Guid.NewGuid(), ProductName = "Test1", CreditLimit = 1000, LenderName = "Test1"},
            new Loan { LoanId = Guid.NewGuid(), ProductName = "Test2", CreditLimit = 10000, LenderName = "Test2"},
            new Loan { LoanId = Guid.NewGuid(), ProductName = "Test3", CreditLimit = 100000, LenderName = "Test3"},
        }.AsQueryable();

        contextMock.Setup(x => x.Loans).ReturnsDbSet(data);

        prequalificationService = new PrequalificationService(contextMock.Object);

        var loans = prequalificationService.ProcessDetails(new Models.PrequalificationModel() { Name = "Test", Address = "Test", DateOfBirth = DateTime.Now, Salary = 1000 });

        Console.Write(loans.Count());

        Assert.That(loans.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestSalaryReturnsOneLoan()
    {
        var contextMock = new Mock<Context>();

        var data = new List<Loan>
        {
            new Loan { LoanId = Guid.NewGuid(), ProductName = "Test1", CreditLimit = 1000, LenderName = "Test1"},
            new Loan { LoanId = Guid.NewGuid(), ProductName = "Test2", CreditLimit = 10000, LenderName = "Test2"},
            new Loan { LoanId = Guid.NewGuid(), ProductName = "Test3", CreditLimit = 100000, LenderName = "Test3"},
        }.AsQueryable();

        contextMock.Setup(x => x.Loans).ReturnsDbSet(data);

        prequalificationService = new PrequalificationService(contextMock.Object);

        var loans = prequalificationService.ProcessDetails(new Models.PrequalificationModel() { Name = "Test", Address = "Test", DateOfBirth = DateTime.Now, Salary = 1005 });

        Assert.That(loans.Count, Is.EqualTo(1));
    }
}