using Web_Coupon.Models;

namespace Web_Coupon.Services
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);

    }
}
