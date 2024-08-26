using AutoMapper;
using CouponAPI.Models;
using CouponAPI.Models.DTOs;

namespace CouponAPI
{
    public class MappingConfig : Profile 
    {
        public MappingConfig()
        {
            CreateMap<Coupon, CouponCreateDTO>().ReverseMap();    
            CreateMap<Coupon, CouponDTO>().ReverseMap();
            CreateMap<Coupon, CouponUpdateDTO>().ReverseMap();
        }
    }
}
