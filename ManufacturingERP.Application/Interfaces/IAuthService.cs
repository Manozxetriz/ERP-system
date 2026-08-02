using ManufacturingERP.Application.Dtos.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP.Application.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterRequestDto request);

        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
