using AutoMapper;
using CouponAPI.Data;
using CouponAPI.Models;
using CouponAPI.Models.DTOs;
using CouponAPI.Repository;

namespace CouponAPI.EndPoint
{
	public static class CouponEndpoints
	{
		public static void ConfigurationCouponEndPoints(this WebApplication app)
		{
			app.MapGet("/api/coupons",GetAllCoupon).WithName("GetCoupons").Produces<APIResponse>();
			app.MapGet("/api/coupon/{id:int}", GetCoupon).WithDisplayName("GetCoupon").Produces<APIResponse>();
			app.MapPost("/api/coupon", CreateCoupon).WithName("Createcoupon").Accepts<CouponCreateDTO>("application/json").Produces(201).Produces(400);
		}

		private async static Task<IResult> GetAllCoupon(ICouponRepository couponRepository)
		{
			APIResponse response = new APIResponse();

			response.Result = await couponRepository.GetAllAsync();
			response.IsSuccess = true;
			response.StatusCode = System.Net.HttpStatusCode.OK;
			
			return Results.Ok(response);
		}


		private async static Task<IResult> GetCoupon(ICouponRepository couponRepository, int id)
		{
			APIResponse response = new APIResponse();

			response.Result = await couponRepository.GetAsync(id);
			response.IsSuccess = true;
			response.StatusCode = System.Net.HttpStatusCode.OK;

			return Results.Ok(response);
		}

		private async static Task<IResult> CreateCoupon(ICouponRepository couponRepository, IMapper _mapper, CouponCreateDTO couponCreate)
		{
			APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };
			if (couponRepository.GetAsync(couponCreate.Name).GetAwaiter().GetResult() != null)
			{
				response.ErrorMessages.Add("Coupon Name already exists");
				return Results.BadRequest(response);
			}

			Coupon coupon = _mapper.Map<Coupon>(couponCreate);
			await couponRepository.CreateAsync(coupon);
			await couponRepository.SaveAsync();
			CouponDTO couponDTO = _mapper.Map<CouponDTO>(coupon);


			response.Result = couponDTO;
			response.IsSuccess = true;
			response.StatusCode = System.Net.HttpStatusCode.Created; 
			return Results.Ok(response);
		}
	}
}
