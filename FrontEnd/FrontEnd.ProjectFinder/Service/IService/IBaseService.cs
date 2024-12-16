using FrontEnd.ProjectFinder.Models;

namespace FrontEnd.ProjectFinder.Service.IService;

public interface IBaseService
{
    Task<ResponseDto?> SendAsync(RequestDto requestDto);
}
