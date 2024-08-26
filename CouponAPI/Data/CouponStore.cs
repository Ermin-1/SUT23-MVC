using CouponAPI.Models;

namespace CouponAPI.Data
{
    public static class CouponStore
    {
        public static List<Coupon> couponList = new List<Coupon>
        {
            new Coupon { ID = 101, Name = "10% OFF", Percent = 10, IsActive = true },
            new Coupon { ID = 102, Name = "20% OFF", Percent = 20, IsActive = false },
            new Coupon { ID = 103, Name = "25% OFF", Percent = 25, IsActive = false },
            new Coupon { ID = 104, Name = "30% OFF", Percent = 30, IsActive = false },

        };
    }
}
