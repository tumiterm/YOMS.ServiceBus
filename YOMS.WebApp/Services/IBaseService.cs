using YOMS.WebApp.Models.DTO;

namespace YOMS.WebApp.Services
{
    public interface IBaseService
    {
        Task<ResponseDTO> SendAsync(RequestDTO responseDTO);
    }
}
