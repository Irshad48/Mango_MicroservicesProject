using Mango.Services.AuthAPI.Models.Dto;

namespace Mango.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<LoginResponseDto> login(LoginRequestDto loginRequestDto);

    }
}
