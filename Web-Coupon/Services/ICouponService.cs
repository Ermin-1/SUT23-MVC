using CouponAPI.Models.DTOs;

namespace Web_Coupon.Services
{
    public interface ICouponService
    {
        Task<T> GetAllCoupon<T>();
        Task<T> GetCouponById<T>(int id);
        Task<T> CreateCouponAsync<T>(CouponDTO couponDTO);
        Task<T> UpdateCouponAsync<T>(CouponDTO couponDTO);
        Task<T> DeleteCouponAsync<T>(int id);
    }
}
