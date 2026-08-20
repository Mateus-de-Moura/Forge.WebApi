using Ardalis.Result;
using Forge.WebApi.Domain.Entities;
using Forge.WebApi.Domain.Interfaces.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.WebApi.Infrastructure.Data.Repositories
{
    public class UserRepository(ForgeWebApiDbContex context) : IUserRepository
    {
        private readonly ForgeWebApiDbContex _context = context;
        public async Task<Result<User>> GetUserByEmail(string email)
        {
            var existingUser = await _context.Users
                .Where(x => x.Email!.Equals(email))              
                .FirstOrDefaultAsync();

            return existingUser != null ? 
                Result.Success(existingUser) : 
                Result.Error("Nenhum Usuário encontrado");
        }

        public async Task<Result<User>> Update(User user)
        {
            var existingUser = await _context.Users.Where(x => x.Id.Equals(user.Id)).FirstOrDefaultAsync();

            if (user == null)
                return Result.Error("Usuário nao foi localizado.");

            existingUser!.Name = user.Name ?? existingUser.Name;
            existingUser.Surname = user.Surname ?? existingUser.Surname;
            existingUser.Email = user.Email ?? existingUser.Email;
            existingUser.UserName = user.UserName ?? existingUser.UserName;
            existingUser.Active = user.Active;          
      
            _context.Users.Update(existingUser);

            var rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected > 0 ?
                Result<User>.Success(existingUser) :
                Result.Error("Erro ao atualizar usuário");

        }
    }
}
