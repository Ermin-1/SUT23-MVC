namespace CouponAPI.Models.DTOs
{
    public class CouponUpdateDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Percent { get; set; }
        public bool IsActive { get; set; }
    }
}
