using YOMS.WebApp.Models.DTO;

namespace YOMS.WebApp.Services
{
    public class ApplicantService : IService
    {
        private readonly IBaseService _baseService;
        public ApplicantService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO> GetApplicantAsync(ProfillingDTO profillingDTO)
        {

            //basically do this for every service, that should be fine
            return await _baseService.SendAsync(new RequestDTO() 
            { 
                APIType = Utility.SD.APIType.POST,
                Data = profillingDTO,
                Url = Utility.SD.ProfilingAPI + "/api/profiling"
            });
        }

        public async Task<ResponseDTO> GetApplicantByIdAsync(Guid Id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                APIType = Utility.SD.APIType.DELETE,
                Url = Utility.SD.ProfilingAPI + "/api/profiling/" + Id,
            });
        }
    }
}
