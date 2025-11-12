using IcecreamMAUI.Shared.DTOS;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcecreamMaui.Services
{
    public interface IAuthApi
    {
        [Post("/api/signup")]
        Task<ResultWithDataDTO<AuthResponseDTO>> SignupAsync(SignupRegisterDT0 dto);

        [Post("/api/signin")]
        Task<ResultWithDataDTO<AuthResponseDTO>> SigninAsync(SigninRequestDTO dto);
    }
}
