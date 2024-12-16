using System.ComponentModel.DataAnnotations;

namespace ProjectFinder.Web.Models;

public class GitHubFinderDto
{
    [Required(ErrorMessage = "требуется ввести название проекта без пробелов")]
    public string ProjectName { get; set; }
    public string Repositories { get; set; }
}
