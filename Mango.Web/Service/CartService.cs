using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.sendAsynch(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                url = SD.ShoppingCartAPIBase + "/api/cart/ApplyCoupon"

            });
        }


        public async Task<ResponseDto?> GetCartbyUserIdAsync(string userId)
        {
            return await _baseService.sendAsynch(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                url = SD.ShoppingCartAPIBase + "/api/cart/GetCart/"+ userId

            });
        }


        public async Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.sendAsynch(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDetailsId,
                url = SD.ShoppingCartAPIBase + "/api/cart/RemoveCart"

            });
        }


        public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.sendAsynch(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                url = SD.ShoppingCartAPIBase + "/api/cart/CartUpsert"

            });
        }
    }
}
