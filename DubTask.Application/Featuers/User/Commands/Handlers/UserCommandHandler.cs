using DubTask.Application.Featuers.User.Commands.Models;
using DubTask.Application.Repositories;
using DubTask.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Featuers.User.Commands.Handlers
{
    public class UserCommandHandler : IRequestHandler<RegisterUserCommand,Response<int>>,
        IRequestHandler<LoginUserCommand, Response<string>>
    {
        private readonly IUserRepository _repo;
        private readonly ITokenRepository _tokenService;

        public UserCommandHandler(IUserRepository repo, ITokenRepository tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        public async Task<Response<int>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmPassword)
                throw new ArgumentException("Passwords do not match");

            if (await _repo.GetByEmailAsync(request.Email) is not null)
                throw new Exception("Email is already registered");

            var hmac = new HMACSHA512();
            var user = new Domain.Models.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password))
            };

            await _repo.AddAsync(user);
            await _repo.SaveChangesAsync();
            return new Response<int>
            {
                Data = user.Id,
                Message = "User registered successfully",
                Succeeded = true
            };
        }
        public async Task<Response<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetByEmailAsync(request.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid email or password");

            var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

            if (!computedHash.SequenceEqual(user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid email or password");

            var token= _tokenService.GenerateToken(user);
            return new Response<string>
            {
                Data = token,
                Message = "Login successful",
                Succeeded = true
            };
        }
    }
}
