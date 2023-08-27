using YOMS.WebApp.Utility;


namespace YOMS.WebApp.Models.DTO
{
    public class RequestDTO
    {
        public SD.APIType APIType { get; set; } = Utility.SD.APIType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
