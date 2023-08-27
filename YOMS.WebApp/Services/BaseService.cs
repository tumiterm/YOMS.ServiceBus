﻿using Newtonsoft.Json;
using System.Text;
using YOMS.WebApp.Models.DTO;
using static YOMS.WebApp.Utility.SD;
using System.Net;

namespace YOMS.WebApp.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDTO> SendAsync(RequestDTO requestDTO)
        {
            HttpClient client = _httpClientFactory.CreateClient("YomsAPI");

            HttpRequestMessage message = new();

            message.Headers.Add("Accept", "application/json");

            //token

            message.RequestUri = new Uri(requestDTO.Url);

            if(requestDTO.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage? apiResponse = null;

            switch(requestDTO.APIType)
            {
                case APIType.POST:
                    message.Method = HttpMethod.Post;
                    break;

                case APIType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;

                case APIType.PUT:
                    message.Method = HttpMethod.Put;
                    break;

                default:
                    message.Method=HttpMethod.Get;  
                    break;

            }

            apiResponse = await client.SendAsync(message);
            try
            {
                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };

                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Forbidden Request" };

                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unathorized" };

                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };

                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return apiResponseDTO;

                }
            } catch (Exception ex)
            {
                var dto = new ResponseDTO()
                {
                    Message = ex.Message.ToString(),

                    IsSuccess = false,
                };

                return dto;  
            }


        }
    }
}
