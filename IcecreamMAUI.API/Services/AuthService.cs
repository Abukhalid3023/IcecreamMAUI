using IcecreamMAUI.API.Data;
using IcecreamMAUI.API.Data.Entities;
using IcecreamMAUI.Shared.DTOS;
using Microsoft.EntityFrameworkCore;

namespace IcecreamMAUI.API.Services
{
    public class AuthService(DataContext context, Tokenservice tokenservice , PasswordService passwordservice)
    {
        private readonly DataContext _context = context;
        private readonly Tokenservice _tokenservice = tokenservice;
        private readonly PasswordService _passwordservice = passwordservice;

        public async Task<ResultWithDataDTO<AuthResponseDTO>> SignupAsync(SignupRegisterDT0 dto)
        {
            if (await _context.Users.AsNoTracking().AnyAsync(u => u.Email == dto.Email))
            {
                return ResultWithDataDTO<AuthResponseDTO>.Failure("Email Already Exits");
            }

            var user = new User
            {
                Email = dto.Email,
                Address = dto.Address,
                Name = dto.Name,
            };

            (user.Salt, user.Hash) = _passwordservice.GenerateSaltAndHash(dto.Password);

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return GenerateAuthResponse(user);
            }
            catch (Exception ex)
            {
                return ResultWithDataDTO<AuthResponseDTO>.Failure(ex.Message);
            }
        }
        public async Task<ResultWithDataDTO<AuthResponseDTO>> SigninAsync(SigninRequestDTO dto)
        {
            var dbUser = await _context.Users
                               .AsNoTracking()
                               .FirstOrDefaultAsync(u=> u.Email == dto.Email);
            if (dbUser is null)
                return ResultWithDataDTO<AuthResponseDTO>.Failure("User doest not Exists");

            if (!_passwordservice.AreEqual(dto.Password, dbUser.Salt, dbUser.Hash))
                return ResultWithDataDTO<AuthResponseDTO>.Failure("Incorrect Password");

            return GenerateAuthResponse(dbUser);
        }
        private ResultWithDataDTO<AuthResponseDTO> GenerateAuthResponse(User user)
        {
            var loggedInUser = new LoggedInUser(user.Id, user.Name, user.Email, user.Address);

            var token = _tokenservice.GenerateJwt(loggedInUser);

            var authResponse = new AuthResponseDTO(loggedInUser,token);

            return ResultWithDataDTO<AuthResponseDTO>.Success(authResponse);
        }
    }
}
