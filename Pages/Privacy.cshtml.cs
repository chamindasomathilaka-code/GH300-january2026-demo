using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace GH300_january2026_demo.Pages;

public class Employee
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string HiringDate { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
}

public class PrivacyModel : PageModel
{
    private readonly IWebHostEnvironment _environment;

    public PrivacyModel(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public List<Employee> Employees { get; set; } = new List<Employee>();

    public void OnGet()
    {
        var jsonPath = Path.Combine(_environment.ContentRootPath, "sampledata.json");
        if (System.IO.File.Exists(jsonPath))
        {
            var jsonString = System.IO.File.ReadAllText(jsonPath);
            Employees = JsonSerializer.Deserialize<List<Employee>>(jsonString) ?? new List<Employee>();
        }
    }
}

