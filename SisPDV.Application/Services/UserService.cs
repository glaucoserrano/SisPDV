using Microsoft.EntityFrameworkCore;
using SisPDV.Application.DTOs.Users;
using SisPDV.Application.Interfaces;
using SisPDV.Domain.Entities;
using SisPDV.Domain.Helpers;
using SisPDV.Infrastructure.Persistence;
using System.Transactions;

namespace SisPDV.Application.Services
{
    public class UserService : IUserService
    {
        private readonly PDVDbContext _context;
        
        public UserService(PDVDbContext context)
        {
            _context = context;
            
        }

        public async Task<User?> AuthenticateUserAsync(string login, string password)
        {
            var passwordHash = PasswordHelper.ComputeSha256Hash(rawData: password);

            return await _context.users.FirstOrDefaultAsync(
                user => user.Login == login &&
                user.Password == passwordHash &&
                user.Active);
        }

        public async Task ChangeUserPassword(string login, string oldPassword, string newPassword)
        {
            var user = await _context.users.FirstOrDefaultAsync(user => user.Login == login);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            if (!PasswordHelper.Verify(user.Password, oldPassword))
                throw new Exception("Senha atual incorreta");

            user.Password = PasswordHelper.ComputeSha256Hash(newPassword);

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.users.Update(user);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }   

        public async Task CreateUserAsync(UserRegisterDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                var exists = await _context.users.AnyAsync(user => user.Login == request.Login);

                if (exists)
                    throw new Exception("Já existe um usuário com este login.");

                var user = new User
                {
                    Name = request.Name,
                    Login = request.Login,
                    Password = PasswordHelper.ComputeSha256Hash(rawData: request.Password),
                    Active = request.Active
                };
                _context.users.Add(user);

                await _context.SaveChangesAsync();
                await transactions.CommitAsync();

            }catch
            {
                await transactions.RollbackAsync();
                throw;
            }
        }

        public async Task<List<UserSearchResponseDTO>> FilterUsersAsync(string? name, string? login, bool active)
        {
            var query = _context.users
                .AsNoTracking()
                .Where(user => user.Login != "admin");

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(user => EF.Functions.ILike(user.Name, $"{name}%"));

            if(!string.IsNullOrEmpty(login))
                query = query.Where(user => EF.Functions.ILike(user.Login, $"{login}%"));

            if(active)
                query = query.Where(user => user.Active);

            var result = await query
                .Select(user => new UserSearchResponseDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Login = user.Login,
                    Active = user.Active
                })
                .ToListAsync();

            return result;
        }

        public async Task<List<UserSearchResponseDTO>> GetAllActiveExceptAdminAsync()
        {
            return await _context.users
                .Where(user => user.Active && user.Login.ToLower() != "admin")
                .Select(user => new UserSearchResponseDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Login = user.Login
                })
                .OrderBy(user => user.Name)
                .ToListAsync();
        }

        public async Task<User?> GetById(int? id)
        {
            return await _context.users
                .FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task UpdateUserAsync(UserUpdateDTO request)
        {
            using var transactions = await _context.Database.BeginTransactionAsync();

            try
            {
                var user = await _context.users.FirstOrDefaultAsync(user => user.Id == request.Id);

                if (user == null)
                    throw new Exception("Usuário não encontrado");

                if (!string.Equals(user.Login, request.Login, StringComparison.OrdinalIgnoreCase)) ;
                {
                    var loginExists = await _context.users
                        .AsNoTracking()
                        .AnyAsync(user => user.Login.ToLower() == request.Login.ToLower()
                        && user.Id != request.Id);

                    if (loginExists)
                        throw new Exception("Já existe um usuário com esse login!");
                }
                user.Name = request.Name;
                user.Login = request.Login;
                user.Active = request.Active;

                await _context.SaveChangesAsync();
                await transactions.CommitAsync();

            }
            catch
            {
                await transactions.RollbackAsync();
                throw;
            }
        }
    }
}
