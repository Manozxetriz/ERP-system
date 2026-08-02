using ManufacturingERP.Application.Dtos.Authentication;
using ManufacturingERP.Application.Interfaces;
using ManufacturingERP.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly PasswordHasher<User> _passwordHasher = new();

        public AuthService(
            IUserRepository userRepository,
            IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task RegisterAsync(RegisterRequestDto request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists.");
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                RoleId = request.RoleId,
                IsActive = true

            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception("Invalid email or password.");
            }

            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid email or password.");
            }

            if (!user.IsActive)
            {
                throw new Exception("User account is inactive.");
            }

            var token = _jwtTokenService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(60), 
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Role = user.Role.Name
            };
        }
    }
}
