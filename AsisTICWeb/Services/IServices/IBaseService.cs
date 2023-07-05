using AsisTICWeb.Models;

namespace AsisTICWeb.Services.IServices
{
    public interface IBaseService
    {
        public ApiResponse responseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);

    }
}
