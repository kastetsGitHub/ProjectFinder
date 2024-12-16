using FrontEnd.ProjectFinder.Models;
using FrontEnd.ProjectFinder.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.ProjectFinder.Controllers;


public class GitHubFinderController : Controller
{
    private readonly IGitHubFinderService _gitHubFinderService;

    public GitHubFinderController(IGitHubFinderService gitHubFinderService)
    {
        _gitHubFinderService = gitHubFinderService;
    }

    public async Task<IActionResult> RepositoriesAsync(string nameFinder)
    {
        List<GitHubFinderDto>? repositories = new();
        ResponseDto? response = await _gitHubFinderService.GetRepositoriesAsync(nameFinder);

        if (response != null && response.IsSuccess)
        {
            repositories = JsonConvert.DeserializeObject<List<GitHubFinderDto>>(Convert.ToString(response.Result));
            return View(repositories);
        }
        else
        {
            TempData["error"] = response?.Message;
        }
        return NotFound();
    }

    public async Task<IActionResult> DeleteRepositoriesAsync(string nameFinder)
    {
        ResponseDto? response = await _gitHubFinderService.GetRepositoriesAsync(nameFinder);

        if (response != null && response.IsSuccess)
        {
            GitHubFinderDto? model = JsonConvert.DeserializeObject<GitHubFinderDto>(Convert.ToString(response.Result));
            return View(model);
        }
        else
        {
            TempData["error"] = response?.Message;
        }
        return NotFound();
    }




}
