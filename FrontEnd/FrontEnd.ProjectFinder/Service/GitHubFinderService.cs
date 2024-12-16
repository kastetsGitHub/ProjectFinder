using FrontEnd.ProjectFinder.Models;
using FrontEnd.ProjectFinder.Service.IService;
using FrontEnd.ProjectFinder.Utility;

namespace FrontEnd.ProjectFinder.Service;

public class GitHubFinderService : IGitHubFinderService
{
    private readonly IBaseService _baseService;

    public GitHubFinderService(IBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<ResponseDto?> DeleteRepositoriesAsync(string nameFinder)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.GitHubFinderAPIService + "/api/find/" + nameFinder // find не очень уместно но я старался придерживаться ТЗ
        });
    }

    public async Task<ResponseDto?> GetRepositoriesAsync(string nameFinder)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.GitHubFinderAPIService + "/api/find/" + nameFinder
        });
    }

    public async Task<ResponseDto?> SaveRepositoriesAsync(GitHubFinderDto gitHubFinderDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.POST,
            Data = gitHubFinderDto,
            Url = SD.GitHubFinderAPIService + "/api/find/"
        });
    }
}
