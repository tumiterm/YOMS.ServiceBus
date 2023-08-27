using YOMS.WebApp.Models.DTO;

namespace YOMS.WebApp.Services
{
    public interface IService
    {
        Task<ResponseDTO> GetApplicantAsync(ProfillingDTO profillingDTO);
        Task<ResponseDTO> GetApplicantByIdAsync(Guid Id);

        //Add More

    }
}
