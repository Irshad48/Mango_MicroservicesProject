using Mango.Services.ShoppingCartAPI.Models.Dto;

namespace Mango.Service.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string CouponCode);
    }
}
