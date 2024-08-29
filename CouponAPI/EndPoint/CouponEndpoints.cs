using CouponAPI.Models;
using CouponAPI.Repository;

namespace CouponAPI.EndPoint
{
	public static class CouponEndpoints
	{
		public static void ConfigurationCouponEndPoints(this WebApplication app)
		{
			app.MapGet("/api/coupons",GetAllCoupon).WithName("GetCoupons").Produces<APIResponse>();
		}

		private async static Task<IResult> GetAllCoupon(ICouponRepository couponRepository)
		{
			APIResponse response = new APIResponse();

			response.Result = await couponRepository.GetAllAsync();
			response.IsSuccess = true;
			response.StatusCode = System.Net.HttpStatusCode.OK;
			
			return Results.Ok(response);
		}
	}
}
