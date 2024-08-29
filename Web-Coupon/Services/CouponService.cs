using CouponAPI.Models.DTOs;

namespace Web_Coupon.Services
{
    public class CouponService : BaseService, ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CouponService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<T> CreateCouponAsync<T>(CouponDTO couponDTO)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = couponDTO,
                URL = StaticDetails.CouponApiBase + "/api/coupon",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteCouponAsync<T>(int id)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Data = id,
                URL = StaticDetails.CouponApiBase + "/api/coupon/" + id,
                AccessToken = ""
            });
        }

        public Task<T> GetAllCoupon<T>()
        {
            return SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                URL = StaticDetails.CouponApiBase + "/api/coupons",
                AccessToken = ""
            });
        }

        public async Task<T> GetCouponById<T>(int id)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.GET,
                URL = StaticDetails.CouponApiBase + "/api/coupon/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateCouponAsync<T>(CouponDTO couponDTO)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = couponDTO,
                URL = StaticDetails.CouponApiBase + "/api/coupon",
                AccessToken = ""
            });
        }
    }
}
