using static Web_Coupon.StaticDetails;

namespace Web_Coupon.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }
        public string URL { get; set; }

        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
