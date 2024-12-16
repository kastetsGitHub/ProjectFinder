using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.FindGitHubAPI.Data;
using Service.FindGitHubAPI.Models.Dto;

namespace Service.FindGitHubAPI.Controllers;

[ApiController]
[Route("api/find")]
public class FindGitHubAPIController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    private readonly ResponseDto _response;
    private readonly IHttpClientFactory _httpClientFactory;

    public FindGitHubAPIController(AppDbContext db, IHttpClientFactory httpClientFactory, IMapper mapper)
    {
        _db = db;
        _httpClientFactory = httpClientFactory;
        _mapper = mapper;
        _response = new ResponseDto();
    }

    [HttpGet]
    public async Task<ResponseDto> Get(string finderRequest)
    {
        try
        {
            Finder finder = await _db.Finder.FirstAsync(f => f.FinderName == finderRequest);
            _response.Result = _mapper.Map<FinderDto>(finder);
        }
        catch (Exception ex)
        {
            _response.Message = ex.Message;
            _response.Success = false;
        }

        return _response;
    }

    [HttpPost]
    public async Task<ResponseDto> Post([FromBody] FinderRequestDto finderDto)
    {
        try
        {
            HttpClient client = _httpClientFactory.CreateClient("GitFinder");
            HttpRequestMessage message = new(HttpMethod.Get, finderDto.FinderURL);
            //message.Headers.UserAgent.Add(new ProductInfoHeaderValue("MyGitHubApp", "1.0"));
            message.Headers.Add("User-Agent", "application/vnd.github.v3+json");
            HttpResponseMessage apiResponse = await client.SendAsync(message);
            var apiContent = await apiResponse.Content.ReadAsStringAsync();

            //message.Headers.Add("MyGitHubApp", "application/vnd.github.v3+json");
            //    message.RequestUri = new Uri(finderDto.FinderURL);
            // if (requestDto.Data != null)
            // {
            //     message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            // }

            //  var re = client.GetAsync("https://api.github.com/search/repositories?q=sabway");
            //client.DefaultRequestHeaders.UserAgent.ParseAdd("abdess66/SABWAY-MOROCO");
            
            _response.Result = finderDto;
        }
        catch (Exception ex)
        {
            _response.Message = ex.Message;
            _response.Success = false;
        }

        return _response;
    }
}
