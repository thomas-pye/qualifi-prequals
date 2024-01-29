using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]

public class PrequalificationController : ControllerBase
{
    private IPrequalificationService _prequalificationService;
    private ILogger<PrequalificationController> _logger;

    public PrequalificationController(
        IPrequalificationService prequalificationService,
        ILogger<PrequalificationController> logger)
    {
        _prequalificationService = prequalificationService;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PrequalificationModel model)
    {
        // Rudimentary model validation, with more time I would create a validator wrapper and inject it into the controller
        List<string> validationErrors = new List<string>();

        if (string.IsNullOrEmpty(model.Name))
            validationErrors.Add("Name is required");

        if (string.IsNullOrEmpty(model.Address))
            validationErrors.Add("Address is required");

        if (model.DateOfBirth == null)
            validationErrors.Add("Date of birth is required");

        if (model.Salary == null || model.Salary < 0)
            validationErrors.Add("Salary is required and must be greater than 0");

        if (validationErrors.Count > 0)
            return BadRequest(validationErrors);

        var loans = _prequalificationService.ProcessDetails(model);

        return Ok(loans);
    }
}