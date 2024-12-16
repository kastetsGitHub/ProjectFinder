using FrontEnd.ProjectFinder.Models;

namespace FrontEnd.ProjectFinder.Service.IService;

public interface IGitHubFinderService
{
    Task<ResponseDto?> GetRepositoriesAsync(string nameFinder);
    Task<ResponseDto?> SaveRepositoriesAsync(GitHubFinderDto gitHubFinderDto);
    Task<ResponseDto?> DeleteRepositoriesAsync(string nameFinder);
    //Task<ResponseDto?> GetAllRepositoriesAsync();
    //Task<ResponseDto?> UpdateRepositoriesAsync(GitHubFinderDto gitHubFinderDto);
}
